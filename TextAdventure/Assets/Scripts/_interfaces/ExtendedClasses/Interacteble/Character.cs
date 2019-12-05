using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, Interacteble
{
    private List<string> dialogSequence = new List<string>();
    private int currentDialog = 0;

    private Trigger associatedEvent = null;
    private bool retrievedEvent = false;

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

        return null;
    }

    public Trigger HasEventAssociated()
    {
        if (retrievedEvent == true)
            return associatedEvent;
        else
            return null;
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

