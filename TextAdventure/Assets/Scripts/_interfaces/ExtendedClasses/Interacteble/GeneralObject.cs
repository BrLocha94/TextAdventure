﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObject : MonoBehaviour, Interacteble
{
    private InteractebleType type;
    private string characterName;

    private string associatedDialog;
    private string emptyDialog;

    private Trigger associatedEvent;
    private bool retrievedEvent;

    public GeneralObject()
    {
        type = InteractebleType.OBJECT;
        associatedDialog = "";
        emptyDialog = "";
        characterName = "";
        associatedEvent = null;
        retrievedEvent = false;
    }

    #region Interface Methods

    public string Interact()
    {
        if (retrievedEvent == false)
            return associatedDialog;

        return emptyDialog;
    }

    public Trigger HasEventAssociated()
    {
        if (retrievedEvent == false)
        {
            retrievedEvent = true;
            return associatedEvent;
        }
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

    #region Sets and Gets

    public void SetAssociatedDialog(string newDialog)
    {
        associatedDialog = newDialog;
    }

    public string GetAssociatedDialog()
    {
        return associatedDialog;
    }

    public void SetEmptyDialog(string newDialog)
    {
        emptyDialog = newDialog;
    }

    public string GetEmptyDialog()
    {
        return emptyDialog;
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
