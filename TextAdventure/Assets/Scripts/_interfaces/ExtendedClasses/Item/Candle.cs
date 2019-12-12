using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, Item
{
    private string itemDescription;
    private List<Action> itemUsabilities;

    public Candle()
    {
        itemDescription = "Vela comum";

        itemUsabilities = new List<Action>();
        itemUsabilities.Add(new Pic());
        itemUsabilities.Add(new Throw());
        itemUsabilities.Add(new Inspect());
    }

    public string ExecuteAction(ActionType action)
    {
        string message = "Não é possivel realizar tal ação com este item";

        for(int i = 0; i < itemUsabilities.Count; i++)
        {
            if(action == itemUsabilities[i].GetActionType())
            {
                Results result = itemUsabilities[i].Execute();

                if (result == Results.OUTSTANDING)
                    message = "Mensagem";
                else if (result == Results.SUCESS)
                    message = "Mensagem";
                else if (result == Results.FAIL)
                    message = "Mensagem";
                else
                    message = "Mensagem";
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
}
