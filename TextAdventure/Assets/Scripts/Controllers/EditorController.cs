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

    List<Node> listNodes;
    List<Interacteble> listInteractions;
    List<Action> listActions;

    void Start()
    {
        listNodes = GameDatabase.instance().GetNodeList();
        listInteractions = new List<Interacteble>();
        listActions = new List<Action>();
    }

    private void PopulateListNode()
    {
        for(int i = 0; i < listNodes.Count; i++)
        {
            GameObject newObject = Instantiate(buttonsPrefabs[0], panelNode.transform);
            NodeButton pointer = newObject.GetComponent<NodeButton>();

        }
    }

}
