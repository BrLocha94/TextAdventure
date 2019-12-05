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

    }

    public void Delete()
    {

    }

    public ButtonEditorType GetButtonEditorType()
    {
        return type;
    }
}
