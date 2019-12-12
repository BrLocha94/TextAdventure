using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, Interacteble
{
    private InteractebleType type;
    private string characterName;

    private List<string> dialogSequence;
    private int currentDialog;

    private Trigger associatedEvent;
    private bool retrievedEvent;

    public Character()
    {
        type = InteractebleType.CHARACTER;
        characterName = "";
        dialogSequence = new List<string>();
        currentDialog = 0;
        associatedEvent = null;
        retrievedEvent = false;
    }

    #region Interface Methods

    public string Interact()
    {
        if (currentDialog < dialogSequence.Count)
        {
            string dialog = dialogSequence[currentDialog];
            currentDialog++;
            return dialog;
        }
        currentDialog = 0;

        return "";
    }

    public Trigger HasEventAssociated()
    {
        if (retrievedEvent == true)
            return associatedEvent;
        else
            return null;
    }

    public InteractebleType GetInteractableType()
    {
        return type;
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    #endregion

    public void AddDialog(string newDialog)
    {
        dialogSequence.Add(newDialog);
    }

    public void RemoveDialog(int index)
    {
        dialogSequence.RemoveAt(index);
    }

    #region Sets and Gets

    public List<string> GetDialogSequence()
    {
        return dialogSequence;
    }

    public Trigger GetAssociatedEvent()
    {
        return associatedEvent;
    }

    public void SetAssociatedEvent(Trigger newEvent)
    {
        associatedEvent = newEvent;
    }

    #endregion
}

