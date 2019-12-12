using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour, ButtonEditor
{
    private EditorController controller;

    private Node parentNode;
    private int parentIndex;

    private Item item;
    private int index;

    private ButtonEditorType type;

    public ItemButton(Node node, int nodeIndex, Item target, int targetIndex, EditorController controllerReference)
    {
        parentNode = node;
        parentIndex = nodeIndex;
        item = target;
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

    public void SetItem(Item newitem)
    {
        item = newitem;
    }

    public Item GetItem()
    {
        return item;
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
