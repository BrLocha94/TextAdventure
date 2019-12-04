using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBlock : MonoBehaviour, PopUp
{
    public void InTransition()
    {
        gameObject.GetComponent<Lean.Gui.LeanWindow>().TurnOn();
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OutTransition()
    {
        gameObject.GetComponent<Lean.Gui.LeanWindow>().TurnOff();
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
