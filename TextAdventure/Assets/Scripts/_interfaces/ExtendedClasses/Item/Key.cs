using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Item
{
    private string itemDescription;
    private string itemName;
    private List<Action> itemUsabilities;

    public Key()
    {
        itemDescription = "Chave comum";
        itemName = "chave";

        ActionFactory factory = new ActionFactory();

        itemUsabilities = new List<Action>();
        itemUsabilities.Add(factory.instance().Create(ActionType.Pegar));
        itemUsabilities.Add(factory.instance().Create(ActionType.Arremessar));
        itemUsabilities.Add(factory.instance().Create(ActionType.Abrir));
        itemUsabilities.Add(factory.instance().Create(ActionType.Fechar));
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
                    message = "VOCE PEGOU ESSA CHAVE BEM DEMAIS COLEGA";
                else if (result == Results.SUCESS)
                    message = "Voce pegou essa chave";
                else if (result == Results.FAIL)
                    message = "Voce nao conseguiu pegar a chave";
                else
                {
                    message = "A chave explodiu, todo mundo morreu";
                    GameController.instance().GameOver();
                }
            }
        }

        return message;
    }

    public bool CheckAction(string type)
    {
        for(int i = 0; i < itemUsabilities.Count; i++)
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
        return itemName;
    }
}
