using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDatabase : MonoBehaviour
{
    GameData gameData;

    int actualScore = 0;

    #region INSTANCE

    private static GameDatabase _instance;
    public static GameDatabase instance()
    {
        if (_instance != null)
            return _instance;

        _instance = GameObject.FindObjectOfType<GameDatabase>();

        if (_instance == null)
        {
            GameObject instanceResource = Resources.Load("GameDatabase") as GameObject;
            if (instanceResource != null)
            {
                GameObject instanceObject = Instantiate(instanceResource);
                _instance = instanceObject.GetComponent<GameDatabase>();
                DontDestroyOnLoad(instanceObject);
            }
            else
                Debug.Log("Failed to load SoundController resource ");
        }

        return _instance;
    }

    #endregion

    void Start ()
    {
        Initializer();
        //ReadDataOnStreamingAssets();
    }

    void Initializer()
    {
        _instance.gameData = new GameData();
        WriteDataOnStreamingAssets();
    }

    public void AddNode(Node node)
    {
        _instance.gameData.AddNode(node);
    }

    public void RemoveNode(Node node)
    {
        _instance.gameData.RemoveNode(node);
    }

    public void AddScore(int score)
    {
        _instance.actualScore += score;
    }

    public void RemoveScore(int score)
    {
        _instance.actualScore -= score;
    }

    #region IO READER AND WRITER

    void ReadDataOnStreamingAssets()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "game-data.json");
        //string path = Path.Combine(Application.streamingAssetsPath, "patients-data.json");

        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            string data_text = reader.ReadToEnd();
            //Debug.Log(data_text);
            GameData data = JsonUtility.FromJson<GameData>(data_text);
            _instance.gameData = data;
            reader.Close();
            Debug.Log("Load Complete");
        }
        else
            Debug.Log("File not found, can't load game data");
    }

    public void WriteDataOnStreamingAssets()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "game-data.json");

        if (File.Exists(path))
        {
            StreamWriter writer = new StreamWriter(path, false);
            string jsonData = JsonUtility.ToJson(_instance.gameData, true);
            writer.Write(jsonData);
            writer.Close();
            Debug.Log("Save Complete");
        }
        else
            Debug.Log("File not found, can't write game data");
    }

    #endregion

    #region Gets And Sets

    public void SetActualScore(int score)
    {
        _instance.actualScore = score;
    }

    public int GetActualScore()
    {
        return _instance.actualScore;
    }

    #endregion
}