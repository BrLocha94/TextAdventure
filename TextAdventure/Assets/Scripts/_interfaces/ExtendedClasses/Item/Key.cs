using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Item
{
    private string itemDescription;
    private List<ActionType> itemUsabilities;

    public Key()
    {
        itemDescription = "Chave comum";

        itemUsabilities = new List<ActionType>();
        itemUsabilities.Add(ActionType.PIC);
        itemUsabilities.Add(ActionType.THROW);
        itemUsabilities.Add(ActionType.OPEN);
        itemUsabilities.Add(ActionType.CLOSE);
    }

    public string GetDescription()
    {
        return itemDescription;
    }

    public List<ActionType> GetUsabilities()
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
}
