using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : MonoBehaviour, ButtonEditor
{
    private EditorController controller;

    private Node parentNode;
    private int parentIndex;

    private Interacteble interaction;
    private int index;

    private ButtonEditorType type;

    public InteractionButton(Node node, int nodeIndex, Interacteble target, int targetIndex, EditorController controllerReference)
    {
        parentNode = node;
        parentIndex = nodeIndex;
        interaction = target;
        index = targetIndex;
        type = ButtonEditorType.INTERACTABLE;
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
