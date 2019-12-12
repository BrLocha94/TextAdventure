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

    void Start ()
    {
        AssignInterfaces();

        listNodes = GameDatabase.instance().GetNodeList();

        if (listNodes != null)
            InitiateGame();
        else
            Debug.Log("listNodes from GameDatabase is null");
    }

    public void CheckInput()
    {
        currentInputOrder = input.text;
        input.text = "";

        string [] inputList = currentInputOrder.Split(' ');

        if (inputList.Length > 1 && inputList.Length < 4)
        {
            if(inputList.Length == 2)
            {
                for(int i = 0; i < currentNode.GetListActions().Count; i++)
                {
                    if (inputList[0].Equals(currentNode.GetListActions()[i].GetActionType().ToString()))
                    {
                        currentNodeAction = currentNode.GetListActions()[i];
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
        
        for(int i = 0; i < title.Length; i++)
        {
            title[i].text = adventureTitle;
        }

        currentNode = listNodes[0];
        gameText.text = currentNode.GetDescription();
    }

    #region PopupMethods

    public void PopMenu()
    {
        block.InTransition();
        popupMenu.InTransition();
    }

    public void RetrieveMenu()
    {
        block.OutTransition();
        popupMenu.OutTransition();
    }

    public void PopConfirmation()
    {
        block.InTransition();
        popupConfirmation.InTransition();
    }

    public void RetrieveConfirmation()
    {
        block.OutTransition();
        popupConfirmation.OutTransition();
    }

    private void AssignInterfaces()
    {
        if (blockObject != null)
            block = blockObject.GetComponent<PopUp>();
        else
            Debug.Log("Block is not assigned in the inspector");

        if (popupMenuObject != null)
            popupMenu = popupMenuObject.GetComponent<PopUp>();
        else
            Debug.Log("PopUpMenu is not assigned in the inspector");

        if (popupConfirmationObject != null)
            popupConfirmation = popupConfirmationObject.GetComponent<PopUp>();
        else
            Debug.Log("PopUpConfirmation is not assigned in the inspector");
    }

    #endregion
}
