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

    void Start()
    {
        listNodes = GameDatabase.instance().GetNodeList();
        listInteractions = new List<Interacteble>();
        listActions = new List<Action>();

        nodeButtonList = new List<GameObject>();
        interactionButtonList = new List<GameObject>();
        actionButtonList = new List<GameObject>();
    }

    private void PopulateListNode()
    {
        for(int i = 0; i < listNodes.Count; i++)
        {
            GameObject newObject = Instantiate(buttonsPrefabs[0], panelNode.transform);
            NodeButton pointer = newObject.GetComponent<NodeButton>();

            pointer.SetController(this);
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

}
