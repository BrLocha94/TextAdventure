using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;

public class GameController : MonoBehaviour
{
    public Lean.Gui.LeanWindow block;
    public Lean.Gui.LeanWindow popupMenu;

    bool toogleState = false;

	void Start ()
    {
		
	}
	
    public void PopMenu()
    {
        toogleState = !toogleState;

        block.GetComponent<CanvasGroup>().blocksRaycasts = toogleState;
        block.Toggle();
        popupMenu.Toggle();
    }

    
}
