using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text[] title;
    [SerializeField]
    private Text gameText;
    [SerializeField]
    private InputField input;

    string currentInputOrder;

    public GameObject blockObject;
    public GameObject popupMenuObject;
    public GameObject popupConfirmationObject;

    private PopUp block;
    private PopUp popupMenu;
    private PopUp popupConfirmation;

    List<Node> listNodes;
    Node currentNode = null;
    Interacteble currentNodeInteractable = null;
    Action currentNodeAction = null;

    private static GameController _instance;
    public static GameController instance()
    {
        if (_instance != null)
            return _instance;

        _instance = FindObjectOfType<GameController>();

        return _instance;
    }

    void Start ()
    {
        instance();

        _instance.AssignInterfaces();

        _instance.listNodes = GameDatabase.instance().GetNodeList();

        if (_instance.listNodes != null)
            _instance.InitiateGame();
        else
            Debug.Log("listNodes from GameDatabase is null");
    }

    public void CheckInput()
    {
        _instance.currentInputOrder = input.text;
        _instance.input.text = "";

        string [] inputList = _instance.currentInputOrder.Split(' ');

        if (inputList.Length > 1 && inputList.Length < 4)
        {
            if(inputList.Length == 2)
            {
                for(int i = 0; i < _instance.currentNode.GetListActions().Count; i++)
                {
                    if (inputList[0].Equals(_instance.currentNode.GetListActions()[i].GetActionType().ToString()))
                    {
                        _instance.currentNodeAction = _instance.currentNode.GetListActions()[i];
                    }
                }
            }
            else
            {

            }
        }
        else
            Debug.Log("Input null or < 2 words or > 3 words");
    }

    private void InitiateGame()
    {
        string adventureTitle = GameDatabase.instance().GetAdventureName();
        
        for(int i = 0; i < _instance.title.Length; i++)
        {
            _instance.title[i].text = adventureTitle;
        }

        _instance.currentNode = listNodes[0];
        _instance.gameText.text = currentNode.GetDescription();
    }

    #region PopupMethods

    public void PopMenu()
    {
        _instance.block.InTransition();
        _instance.popupMenu.InTransition();
    }

    public void RetrieveMenu()
    {
        _instance.block.OutTransition();
        _instance.popupMenu.OutTransition();
    }

    public void PopConfirmation()
    {
        _instance.block.InTransition();
        _instance.popupConfirmation.InTransition();
    }

    public void RetrieveConfirmation()
    {
        _instance.block.OutTransition();
        _instance.popupConfirmation.OutTransition();
    }

    private void AssignInterfaces()
    {
        if (_instance.blockObject != null)
            _instance.block = _instance.blockObject.GetComponent<PopUp>();
        else
            Debug.Log("Block is not assigned in the inspector");

        if (_instance.popupMenuObject != null)
            _instance.popupMenu = _instance.popupMenuObject.GetComponent<PopUp>();
        else
            Debug.Log("PopUpMenu is not assigned in the inspector");

        if (_instance.popupConfirmationObject != null)
            _instance.popupConfirmation = _instance.popupConfirmationObject.GetComponent<PopUp>();
        else
            Debug.Log("PopUpConfirmation is not assigned in the inspector");
    }

    #endregion
}
