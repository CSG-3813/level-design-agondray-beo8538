using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Items Item;
    
    void PickUp()
    {
        InventoryManager.Instance.Add(Item); //add item to inventory
        Destroy(gameObject); //destroy item
    }

    private void OnMouseDown()
    {
        PickUp(); //pick up item
    }
}
