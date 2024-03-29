﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, Item
{
    private string itemDescription;
    private string itemName;
    private List<Action> itemUsabilities;

    public Knife()
    {
        itemDescription = "Faca comum";
        itemName = "faca";

        itemUsabilities = new List<Action>();

        ActionFactory factory = new ActionFactory();

        itemUsabilities.Add(factory.instance().Create(ActionType.Cortar));
        itemUsabilities.Add(factory.instance().Create(ActionType.Pegar));
        itemUsabilities.Add(factory.instance().Create(ActionType.Arremessar));
    }

    public string ExecuteAction(string action)
    {
        string message = "Não é possivel realizar tal ação com este item";

        for (int i = 0; i < itemUsabilities.Count; i++)
        {
            if (action.Equals(itemUsabilities[i].GetActionType().ToString()))
            {
                Results result = itemUsabilities[i].Execute();

                if (result == Results.OUTSTANDING)
                    message = "Mensagem";
                else if (result == Results.SUCESS)
                    message = "Mensagem";
                else if (result == Results.FAIL)
                    message = "Mensagem";
                else
                {
                    message = "Mensagem";
                    GameController.instance().GameOver();
                }
            }
        }

        return message;
    }

    public bool CheckAction(string type)
    {
        for (int i = 0; i < itemUsabilities.Count; i++)
        {
            if (itemUsabilities[i].GetActionType().ToString().Equals(type))
                return true;
        }

        return false;
    }

    public string GetDescription()
    {
        return itemDescription;
    }

    public List<Action> GetUsabilities()
    {
        return itemUsabilities;
    }

    public string GetItemDescription()
    {
        return itemDescription;
    }

    public void SetItemDescription(string description)
    {
        itemDescription = description;
    }

    public string GetItemName()
    {
        return name;
    }
}
