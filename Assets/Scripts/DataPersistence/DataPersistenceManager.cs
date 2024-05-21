using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField]
    private bool initialiazeDataIfNull = false;
    [SerializeField]
    private bool disableDataPersistence = false;
    [SerializeField]
    private bool overrideSelectedProfileID = false;
    [SerializeField]
    private string testSelectedID = "test";


    [Header("File Storage Config")]
    [SerializeField]
    private string fileName;
    [SerializeField]
    private bool useEncryption;

    private GameData gameData; 

    private List<IDataPersistence> dataPersistances;

    private FileDataHandler fileDataHandler;

    private string selectedProfileID = "";

    public static DataPersistenceManager Instance { get;private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("There are more than one instance of " + gameObject.name + ". Destroying newest one!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (disableDataPersistence)
        {
            Debug.LogWarning("DataPersitence is disalbed");
        }

        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        selectedProfileID = fileDataHandler.GetMostRecentlyUpdatedProfileID();

        if (overrideSelectedProfileID)
        {
            selectedProfileID = testSelectedID;
            Debug.LogWarning("ID is overriden");
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dataPersistances = FindAllDataPersistences();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void ChangeSelectedProfileID(string newProfileID)
    {
        selectedProfileID = newProfileID;
        LoadGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void SaveGame()
    {
        if (disableDataPersistence)
        {
            return;
        }

        if (gameData == null)
        {
            Debug.LogWarning("No data found. Start new game");
            return;
        }

        foreach (IDataPersistence dataPersistence in dataPersistances)
        {
            dataPersistence.SaveData(ref gameData);
        }

        gameData.lastUpdated = System.DateTime.Now.ToBinary();

        fileDataHandler.Save(gameData,selectedProfileID);
    }

    public void LoadGame() 
    {
        if(disableDataPersistence)
        {
            return;
        }    

        gameData = fileDataHandler.Load(selectedProfileID);

        if(gameData == null && initialiazeDataIfNull)
        {
            NewGame();
        }

        if(gameData == null)
        {
            Debug.Log("No game data found. A new game must be started");
            return;
        }

        foreach(IDataPersistence dataPersistence in dataPersistances)
        {
            dataPersistence.LoadData(gameData); 
        }
    }

    private List<IDataPersistence> FindAllDataPersistences()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistences);
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return fileDataHandler.LoadAllProfiles();
    }

    public bool HasGameData()
    {
        return gameData != null;
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}
