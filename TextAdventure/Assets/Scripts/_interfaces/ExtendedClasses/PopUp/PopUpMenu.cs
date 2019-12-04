﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMenu : MonoBehaviour, PopUp
{
	public void InTransition()
    {
        gameObject.GetComponent<Lean.Gui.LeanWindow>().TurnOn();
    }

    public void OutTransition()
    {
        gameObject.GetComponent<Lean.Gui.LeanWindow>().TurnOff();
    }
}
