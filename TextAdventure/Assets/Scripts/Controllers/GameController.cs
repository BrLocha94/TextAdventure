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
    Item currentNodeItem = null;

    bool gameOver = false;

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

        if (gameOver == false)
        {
            string[] inputList = _instance.currentInputOrder.Split(' ');

            if (_instance.currentNodeInteractable != null)
            {
                if (inputList.Length > 1 && inputList.Length < 4)
                {
                    if (inputList.Length == 2)
                    {
                        string order = inputList[0] + " " + inputList[1];

                        if (order.Equals("ver descrição"))
                        {
                            _instance.gameText.text = _instance.currentNode.GetDescription();
                        }
                        else
                        {
                            for (int i = 0; i < _instance.currentNode.GetListItens().Count; i++)
                            {
                                if (_instance.currentNode.GetListItens()[i].CheckAction(inputList[0]) && _instance.currentNode.GetListItens()[i].GetItemName().Equals(inputList[1]))
                                {
                                    _instance.currentNodeItem = _instance.currentNode.GetListItens()[i];
                                    break;
                                }
                            }

                            if (_instance.currentNodeItem != null)
                            {
                                string result = _instance.currentNodeItem.ExecuteAction(inputList[0]);
                                _instance.gameText.text = result;
                                _instance.currentNodeItem = null;
                            }
                        }
                    }
                    else
                    {
                        string order = inputList[0] + " " + inputList[1];

                        if (order.Equals("ir para"))
                        {
                            if (inputList[2].Equals("frente"))
                            {
                                if (_instance.currentNode.GetFrontPath() != null)
                                    ChangeNode(_instance.currentNode.GetFrontPath());
                                else
                                    _instance.gameText.text = "Não é possivel ir para frente";
                            }
                            else if (inputList[2].Equals("tras"))
                            {
                                if (_instance.currentNode.GetBackPath() != null)
                                    ChangeNode(_instance.currentNode.GetBackPath());
                                else
                                    _instance.gameText.text = "Não é possivel ir para tras";
                            }
                            else if (inputList[2].Equals("direita"))
                            {
                                if (_instance.currentNode.GetRightPath() != null)
                                    ChangeNode(_instance.currentNode.GetRightPath());
                                else
                                    _instance.gameText.text = "Não é possivel ir para direita";
                            }
                            else if (inputList[2].Equals("esquerda"))
                            {
                                if (_instance.currentNode.GetLeftPath() != null)
                                    ChangeNode(_instance.currentNode.GetLeftPath());
                                else
                                    _instance.gameText.text = "Não é possivel ir para esquerda";
                            }
                        }
                        else if (order.Equals("falar com"))
                        {
                            for (int i = 0; i < _instance.currentNode.GetListInteractions().Count; i++)
                            {
                                if (inputList[2].Equals(_instance.currentNode.GetListInteractions()[i]))
                                {
                                    _instance.currentNodeInteractable = _instance.currentNode.GetListInteractions()[i];
                                    _instance.gameText.text = _instance.currentNodeInteractable.Interact();
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                    Debug.Log("Input null or < 2 words or > 3 words");
            }
            else
            {
                string interactionDialog = _instance.currentNodeInteractable.Interact();
                if(interactionDialog != "")
                    _instance.gameText.text = interactionDialog;
                else
                    _instance.gameText.text = _instance.currentNode.GetDescription();
            }
        }
        else
        {
            _instance.gameText.text = "YOU DIED!!!";
        }
    }

    private void InitiateGame()
    {
        string adventureTitle = GameDatabase.instance().GetAdventureName();
        
        for(int i = 0; i < _instance.title.Length; i++)
        {
            _instance.title[i].text = adventureTitle;
        }

        _instance.currentNode = _instance.listNodes[0];
        _instance.gameText.text = _instance.currentNode.GetDescription();
    }

    private void ChangeNode(Node node)
    {
        _instance.currentNode = node;
        _instance.gameText.text = _instance.currentNode.GetDescription();
    }

    public void GameOver()
    {
        _instance.gameOver = true;
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
