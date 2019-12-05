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

    public void SetInteraction(Interacteble newInteractable)
    {
        interaction = newInteractable;
    }

    public Interacteble GetInteraction()
    {
        return interaction;
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
