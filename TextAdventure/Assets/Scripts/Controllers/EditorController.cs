using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttonsPrefabs; //ORDER: NODE, INTERACTION, ACTION 
    [SerializeField]
    private GameObject panelNode;
    [SerializeField]
    private GameObject panelInteraction;
    [SerializeField]
    private GameObject panelAction;

    [SerializeField]
    private GameObject[] screens;

    List<Node> listNodes;
    List<Interacteble> listInteractions;
    List<Action> listActions;

    List<GameObject> nodeButtonList;
    List<GameObject> interactionButtonList;
    List<GameObject> actionButtonList;

    Node currentNode = null;
    int currentNodeIndex = 0;

    void Start()
    {
        listNodes = GameDatabase.instance().GetNodeList();
        listInteractions = new List<Interacteble>();
        listActions = new List<Action>();

        nodeButtonList = new List<GameObject>();
        interactionButtonList = new List<GameObject>();
        actionButtonList = new List<GameObject>();

        PopulateListNode();
    }

    public void CreateNode()
    {
        GameDatabase.instance().AddNode(new Node());
        listNodes = GameDatabase.instance().GetNodeList();
        FlushListNodes();
        PopulateListNode();
    }

    //public void 

    public void SelectNode(Node node, int index)
    {
        currentNode = node;
        currentNodeIndex = index;
        ChangeScreen(1);
    }

    #region FlushLists

    private void FlushListNodes()
    {
        for(int i = nodeButtonList.Count - 1; i >= 0; i--)
        {
            GameObject node = nodeButtonList[i];
            nodeButtonList.RemoveAt(i);
            Destroy(node);
        }
    }

    private void FlushListInteraction()
    {
        for (int i = interactionButtonList.Count - 1; i >= 0; i--)
        {
            GameObject interaction = interactionButtonList[i];
            interactionButtonList.RemoveAt(i);
            Destroy(interaction);
        }
    }

    private void FlushListAction()
    {
        for (int i = actionButtonList.Count - 1; i >= 0; i--)
        {
            GameObject action = actionButtonList[i];
            actionButtonList.RemoveAt(i);
            Destroy(action);
        }
    }

    #endregion

    #region PopulateLists

    private void PopulateListNode()
    {
        for(int i = 0; i < listNodes.Count; i++)
        {
            GameObject newObject = Instantiate(buttonsPrefabs[0], panelNode.transform);
            NodeButton pointer = newObject.GetComponent<NodeButton>();

            pointer.SetController(gameObject.GetComponent<EditorController>());
            pointer.SetNode(listNodes[i]);
            pointer.SetIndex(i);

            nodeButtonList.Add(newObject);
        }
    }

    private void PopulateListInteraction(Node node, int nodeIndex)
    {
        listInteractions = node.GetListInteractions();

        for (int i = 0; i < listInteractions.Count; i++)
        {
            GameObject newObject = Instantiate(buttonsPrefabs[1], panelInteraction.transform);
            InteractionButton pointer = newObject.GetComponent<InteractionButton>();

            pointer.SetController(this);
            pointer.SetParentNode(listNodes[i]);
            pointer.SetParentIndex(nodeIndex);
            pointer.SetInteraction(listInteractions[i]);
            pointer.SetIndex(i);

            interactionButtonList.Add(newObject);
        }
    }

    private void PopulateListAction(Node node, int nodeIndex)
    {
        listActions = node.GetListActions();

        for (int i = 0; i < listActions.Count; i++)
        {
            GameObject newObject = Instantiate(buttonsPrefabs[1], panelInteraction.transform);
            ActionButton pointer = newObject.GetComponent<ActionButton>();

            pointer.SetController(this);
            pointer.SetParentNode(listNodes[i]);
            pointer.SetParentIndex(nodeIndex);
            pointer.SetAction(listActions[i]);
            pointer.SetIndex(i);

            actionButtonList.Add(newObject);
        }
    }

    #endregion

    private void ChangeScreen(int param)
    {
        if(param == 0)
        {
            screens[0].SetActive(true);
            screens[1].SetActive(false);
            screens[2].SetActive(false);
        }
        else if (param == 1)
        {
            screens[0].SetActive(false);
            screens[1].SetActive(true);
            screens[2].SetActive(false);
        }
        else if (param == 2)
        {
            screens[0].SetActive(false);
            screens[1].SetActive(false);
            screens[2].SetActive(true);
        }
    }

    private void UpdateScreen(int param)
    {
        if(param == 0)
        {
            FlushListNodes();
            PopulateListNode();
        }
        else if(param == 1)
        {
            FlushListInteraction();
            FlushListAction();
            PopulateListInteraction(currentNode, currentNodeIndex);
            PopulateListAction(currentNode, currentNodeIndex);
        }
    }
}
