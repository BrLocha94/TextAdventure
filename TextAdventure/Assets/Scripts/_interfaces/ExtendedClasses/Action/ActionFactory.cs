using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFactory : MonoBehaviour
{
    private static ActionFactory _instance;
    public ActionFactory instance()
    {
        if (_instance == null)
            _instance = this;

        return _instance;
    }

    public Action Create(ActionType type)
    {
        if (type == ActionType.Pegar)
            return new Pic();
        else if (type == ActionType.Arremessar)
            return new Throw();
        else if (type == ActionType.Abrir)
            return new Open();
        else if (type == ActionType.Fechar)
            return new Close();
        else if (type == ActionType.Cortar)
            return new Cut();
        else if (type == ActionType.Inspecionar)
            return new Inspect();

        return null;
    }
}
