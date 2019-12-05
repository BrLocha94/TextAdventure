using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, Item
{
    private string itemDescription;
    private List<ActionType> itemUsabilities;

    public Knife()
    {
        itemDescription = "Faca comum";

        itemUsabilities = new List<ActionType>();
        itemUsabilities.Add(ActionType.CUT);
        itemUsabilities.Add(ActionType.PIC);
        itemUsabilities.Add(ActionType.THROW);
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
