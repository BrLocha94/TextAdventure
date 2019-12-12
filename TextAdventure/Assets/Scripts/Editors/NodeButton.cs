using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeButton : MonoBehaviour, ButtonEditor
{
    private EditorController controller;

    private Node node;
    private int index;

    private ButtonEditorType type;

    public NodeButton(Node newNode, int newIndex, EditorController controllerReference)
    {
        node = newNode;
        index = newIndex;
        type = ButtonEditorType.NODE;
        controller = controllerReference;
    }

    public void OnButtonClick()
    {
        controller.SelectNode(node, index);
    }

    public ButtonEditorType GetButtonEditorType()
    {
        return type;
    }

    public void SetController(EditorController editorController)
    {
        controller = editorController;
    }

    public void SetNode(Node nodeReference)
    {
        node = nodeReference;
    }

    public Node GetNode()
    {
        return node;
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
