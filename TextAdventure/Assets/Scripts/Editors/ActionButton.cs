using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour, ButtonEditor
{
    private EditorController controller;

    private Node parentNode;
    private int parentIndex;

    private Action action;
    private int index;

    private ButtonEditorType type;

    public ActionButton(Node node, int nodeIndex, Action target, int targetIndex, EditorController controllerReference)
    {
        parentNode = node;
        parentIndex = nodeIndex;
        action = target;
        index = targetIndex;
        type = ButtonEditorType.INTERACTABLE;
        controller = controllerReference;
    }

    public void OnButtonClick()
    {

    }

    public ButtonEditorType GetButtonEditorType()
    {
        return type;
    }

    public void SetController(EditorController editorController)
    {
        controller = editorController;
    }

    public void SetParentNode(Node newParentNode)
    {
        parentNode = newParentNode;

    }
    public Node GetParentNode()
    {
        return parentNode;
    }

    public void SetParentIndex(int newParentIndex)
    {
        parentIndex = newParentIndex;

    }
    public int GetParentIndex()
    {
        return parentIndex;
    }

    public void SetAction(Action newAction)
    {
        action = newAction;
    }

    public Action GetAction()
    {
        return action;
    }

    public void SetIndex(int newIndex)
    {
        index = newIndex;

    }
    public int GetIndex()
    {
        return index;
    }

}
