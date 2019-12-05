using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region INSTANCE

    private static SceneController _instance;
    public static SceneController instance()
    {
        if (_instance != null)
            return _instance;

        _instance = GameObject.FindObjectOfType<SceneController>();

        if (_instance == null)
        {
            GameObject instanceResource = Resources.Load("SceneController") as GameObject;
            if (instanceResource != null)
            {
                GameObject instanceObject = Instantiate(instanceResource);
                _instance = instanceObject.GetComponent<SceneController>();
                DontDestroyOnLoad(instanceObject);
            }
            else
                Debug.Log("Failed to load SoundController resource ");
        }

        return _instance;
    }

    #endregion

    public void LoadOpen()
    {
        SoundController.instance().PlayOpenBackground();
        SceneManager.LoadScene("Open", LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        SoundController.instance().PlayGameBackground();
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void LoadEditor()
    {
        SceneManager.LoadScene("Editor", LoadSceneMode.Single);
    }
}
