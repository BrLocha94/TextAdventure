using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : ButtonEditor
{
    private Node parentNode;
    private int parentIndex;

    private Action action;
    private int index;

    private ButtonEditorType type;

    public ActionButton(Node node, int nodeIndex, Action target, int targetIndex)
    {
        parentNode = node;
        parentIndex = nodeIndex;
        action = target;
        index = targetIndex;
        type = ButtonEditorType.INTERACTABLE;
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
