using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeButton : ButtonEditor
{
    private Node node;
    private int index;

    private ButtonEditorType type;

    public NodeButton(Node newNode, int newIndex)
    {
        node = newNode;
        index = newIndex;
        type = ButtonEditorType.NODE;
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
