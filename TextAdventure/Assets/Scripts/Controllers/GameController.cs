using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject blockObject;
    public GameObject popupMenuObject;
    public GameObject popupConfirmationObject;

    private PopUp block;
    private PopUp popupMenu;
    private PopUp popupConfirmation;

	void Start ()
    {
        AssignInterfaces();
    }
	
    public void PopMenu()
    {
        block.InTransition();
        popupMenu.InTransition();
    }

    public void RetrieveMenu()
    {
        block.OutTransition();
        popupMenu.OutTransition();
    }

    public void PopConfirmation()
    {
        block.InTransition();
        popupConfirmation.InTransition();
    }

    public void RetrieveConfirmation()
    {
        block.OutTransition();
        popupConfirmation.OutTransition();
    }

    private void AssignInterfaces()
    {
        if (blockObject != null)
            block = blockObject.GetComponent<PopUp>();
        else
            Debug.Log("Block is not assigned in the inspector");

        if (popupMenuObject != null)
            popupMenu = popupMenuObject.GetComponent<PopUp>();
        else
            Debug.Log("PopUpMenu is not assigned in the inspector");

        if (popupConfirmationObject != null)
            popupConfirmation = popupConfirmationObject.GetComponent<PopUp>();
        else
            Debug.Log("PopUpConfirmation is not assigned in the inspector");
    }
}
