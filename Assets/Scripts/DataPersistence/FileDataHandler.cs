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

    public FileDataHandler(string dataDirPath, string dataFilePath)
    {
        this.dataDirPath = dataDirPath;
        this.dataFilePath = dataFilePath;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFilePath);

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

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {

                Debug.LogError("Error when loading from file : " + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(GameData gameData)
    {
        string fullPath = Path.Combine(dataDirPath, dataFilePath);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(gameData, true);

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
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
}
