using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Unity.VisualScripting;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFilePath = "";

    [Header("Encryption")]
    private bool useEncryption = false;

    private readonly string encryptionCode = "etniefntmoleiaiBrPnaToownlCep";

    public FileDataHandler(string dataDirPath, string dataFilePath, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFilePath = dataFilePath;
        this.useEncryption = useEncryption;
    }

    public GameData Load(string profileID)
    {
        if(profileID == null)
        {
            return null;
        }

        string fullPath = Path.Combine(dataDirPath, profileID, dataFilePath);

        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {

                Debug.LogError("Error when loading from file : " + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(GameData gameData, string profileID)
    {
        if (profileID == null)
        {
            return;
        }

        string fullPath = Path.Combine(dataDirPath, profileID, dataFilePath);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(gameData, true);

            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {

            Debug.LogError("Error when trying to save data to file : " + fullPath + "\n" + e);
        }
    }

    public Dictionary<string, GameData> LoadAllProfiles()
    {
        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();

        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();

        foreach(DirectoryInfo dirInfo in dirInfos)
        {
            string profileID = dirInfo.Name;

            string fullPath = Path.Combine(dataDirPath, profileID, dataFilePath);

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping directory beacuse it doesn't contain save data : " + profileID);
                continue;
            }

            GameData profileData = Load(profileID);

            if(profileData != null)
            {
                profileDictionary.Add(profileID, profileData);
            }
            else
            {
                Debug.LogError("Tried to load data, but something went wrong, profileID : " + profileID);
            }
        }

        return profileDictionary;
    }

    public void Delete(string profileID)
    {
        if (profileID == null)
            return;

        string fullpath = Path.Combine(dataDirPath, profileID, dataFilePath);

        try
        {
            if (File.Exists(fullpath))
            {
                Directory.Delete(Path.GetDirectoryName(fullpath), true);
            }
            else
            {
                Debug.LogWarning("Data to delete wasn't found in " + fullpath);
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Failed to delete data for ID : " + profileID + " in : " + fullpath + "\n" + e);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";

        for(int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCode[i % encryptionCode.Length]);
        }

        return modifiedData;
    }

    public string GetMostRecentlyUpdatedProfileID()
    {
        Dictionary<string, GameData> profilesGameData = LoadAllProfiles();

        string mostRecentProfileID = null;

        foreach (KeyValuePair<string, GameData> kvp in profilesGameData)
        {
            string profileID = kvp.Key;
            GameData gameData = kvp.Value;

            if (gameData == null)
            {
                continue;
            }

            if (mostRecentProfileID == null)
            {
                mostRecentProfileID = profileID;
            }
            else
            {
                DateTime mostRecentDateTime = DateTime.FromBinary(profilesGameData[mostRecentProfileID].lastUpdated);
                DateTime newDateTime = DateTime.FromBinary(gameData.lastUpdated);

                if (newDateTime > mostRecentDateTime)
                {
                    mostRecentProfileID = profileID;
                }
            }
        }

        return mostRecentProfileID;
    }
}
