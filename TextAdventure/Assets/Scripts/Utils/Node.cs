﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    [SerializeField]
    private Node frontPath;
    [SerializeField]
    private Node backPath;
    [SerializeField]
    private Node leftPath;
    [SerializeField]
    private Node rightPath;

    private string title;
    private string description;

    private List<Interacteble> possibleInteractions;
    private List<Action> possibleActions;

    public Node()
    {
        title = "empty";
        description = "empty";

        possibleInteractions = new List<Interacteble>();
        possibleActions = new List<Action>();
    }

    public void AddInteraction(Interacteble newInteraction)
    {
        possibleInteractions.Add(newInteraction);
    }

    public void RemoveInteraction(int index)
    {
        possibleInteractions.RemoveAt(index);
    }

    public void AddAction(Action newAction)
    {
        possibleActions.Add(newAction);
    }

    public void RemoveAction(int index)
    {
        possibleActions.RemoveAt(index);
    }

    #region Gets and Sets

    public List<Interacteble> GetListInteractions()
    {
        return possibleInteractions;
    }

    public List<Action> GetListActions()
    {
        return possibleActions;
    }

    public void SetDescription(string newDescription)
    {
        description = newDescription;
    }

    public string GetDescription()
    {
        return description;
    }

    public void SetTitle(string newTitle)
    {
        title = newTitle;
    }

    public string GetTitle()
    {
        return title;
    }

    public void SetFrontPath(Node target)
    {
        frontPath = target;
    }

    public Node GetFrontPath()
    {
        return frontPath;
    }

    public void SetBackPath(Node target)
    {
        backPath = target;
    }

    public Node GetBackPath()
    {
        return backPath;
    }

    public void SetLeftPath(Node target)
    {
        leftPath = target;
    }

    public Node GetLeftPath()
    {
        return leftPath;
    }

    public void SetRightPath(Node target)
    {
        rightPath = target;
    }

    public Node GetRightPath()
    {
        return rightPath;
    }

    #endregion
}
