using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpInteraction : MonoBehaviour, PopUp
{ 

    [SerializeField]
    private GameObject firstPanel;

    [SerializeField]
    private GameObject secondPanel;

    public void InTransition()
    {
        gameObject.GetComponent<Lean.Gui.LeanWindow>().TurnOn();
    }

    public void OutTransition()
    {
        gameObject.GetComponent<Lean.Gui.LeanWindow>().TurnOff();
    }

    public void OpenFirstPanel()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);

    }

    public void OpenSecondPanel()
    {
        secondPanel.SetActive(true);
        firstPanel.SetActive(false);
    }

}
