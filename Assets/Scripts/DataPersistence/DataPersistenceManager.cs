using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField]
    private string fileName;
    [SerializeField]
    private bool useEncryption;

    private GameData gameData; 

    private List<IDataPersistence> dataPersistances;

    private FileDataHandler fileDataHandler;

    public static DataPersistenceManager Instance { get;private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There are more than one instance of " + gameObject.name);
        }
        Instance = this;
    }

    private void Start()
    {
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        dataPersistances = FindAllDataPersistences();
        LoadGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistence in dataPersistances)
        {
            dataPersistence.SaveData(ref gameData);
        }

        fileDataHandler.Save(gameData);
    }

    public void LoadGame() 
    {
        gameData = fileDataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("No game data found. Initializing to defaults");
            NewGame();
        }

        foreach(IDataPersistence dataPersistence in dataPersistances)
        {
            dataPersistence.LoadData(gameData); 
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistences()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistences);
    }
}
