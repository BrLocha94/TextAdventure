using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDatabase : MonoBehaviour
{
    GameData gameData;

    int actualScore = 0;
    int currentNode = 0;

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

        _instance.gameData.adventureName = "A volta de Feddie Mercury";

        for (int i = 0; i < 3; i++)
        {
            _instance.gameData.AddNode(new Node());
        }

        _instance.gameData.nodeList[0].SetDescription("Voce está nas Montanhas de Carazu\n" +
                                                      "A direita temos as Planices do asfalto em todo seu resplendor\n" +
                                                      "A esquerda o pantano de Mordor surge ao fundo\n" +
                                                      "Nao há ninguém por perto");
        _instance.gameData.nodeList[0].SetLeftPath(_instance.gameData.nodeList[2]);
        _instance.gameData.nodeList[0].SetRightPath(_instance.gameData.nodeList[1]);

        _instance.gameData.nodeList[1].SetDescription("As Planices do asfaltos se estendem por todo o horizonte\n" +
                                                      "Olhando para trás, é possivel ver as Montanhas de Carazu\n" +
                                                      "Há um mercador parado no meio da estrada principal");
        _instance.gameData.nodeList[1].SetBackPath(_instance.gameData.nodeList[0]);
        Character newCharacter = new Character();
        newCharacter.SetCharacterName("mercador");
        newCharacter.AddDialog("EEEEEEEEEEEEEEERRRRRROOOOOOOOOOOOOOO");
        newCharacter.AddDialog("IRO IRO ERO");
        newCharacter.AddDialog("ERO");
        newCharacter.AddDialog("EEEEEEEROOOOOOO");
        newCharacter.AddDialog("UNDER PRESSUREEEEEEEEEEEEEEEEEE......PUSHING DOWN ON ME");

        _instance.gameData.nodeList[1].AddInteraction(newCharacter);


        _instance.gameData.nodeList[2].SetDescription("O Pantano de Mordor é um lugar extremamente sombrio\n" +
                                                      "A sua direita, a Montanha de Carazu surge ao fundo\n" +
                                                      "Há uma chave no chao a sua frente");
        _instance.gameData.nodeList[2].SetRightPath(_instance.gameData.nodeList[0]);
        Key newKey = new Key();
        _instance.gameData.nodeList[2].AddItem(newKey);


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

    public void AdvanceNode()
    {
        _instance.currentNode++;
        if(_instance.currentNode >= _instance.gameData.nodeList.Count)
        {
            Debug.Log("Cant advance node because out off bounds");
            _instance.currentNode--;
        }
    }

    public void BackNode()
    {
        _instance.currentNode--;
        if (_instance.currentNode <= 0)
        {
            Debug.Log("Cant back node because out off bounds");
            _instance.currentNode++;
        }
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

    public List<Node> GetNodeList()
    {
        return _instance.gameData.nodeList;
    }

    public Node GetCurrentNode()
    {
        if(_instance.gameData.nodeList.Count > 0)
        {
            if(_instance.currentNode < _instance.gameData.nodeList.Count)
            {
                return _instance.gameData.nodeList[_instance.currentNode];
            }
            else
            {
                Debug.Log("Current node is out off bounds");
                return null;
            }
        }
        else
        {
            Debug.Log("There is no node in game data list");
            return null;
        }
    }

    public void SetCurrentNodeIndex(int index)
    {
        if (index > -1 && index < _instance.gameData.nodeList.Count)
        {
            _instance.currentNode = index;
        }
        else
            Debug.Log("Cant set node because out off bounds");
    }

    public int GetCurrentNodeIndex()
    {
        return _instance.currentNode;
    }

    public void SetActualScore(int score)
    {
        _instance.actualScore = score;
    }

    public int GetActualScore()
    {
        return _instance.actualScore;
    }

    public string GetAdventureName()
    {
        return _instance.gameData.adventureName;
    }

    #endregion
}