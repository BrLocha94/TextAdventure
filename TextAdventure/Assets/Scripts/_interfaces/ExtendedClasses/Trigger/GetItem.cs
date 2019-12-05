using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour, Trigger
{
    private Item associatedItem;

    public void Execute()
    {

    }

    public Item HasAssociatedItem()
    {
        return associatedItem;
    }

    public void SetAssociatedItem(Item newItem)
    {
        associatedItem = newItem;
    }

    public Item GetAssociatedItem()
    {
        return associatedItem;
    }
}
