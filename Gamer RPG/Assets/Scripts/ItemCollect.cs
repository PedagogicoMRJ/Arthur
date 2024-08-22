using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour, IInteractable
{
    public Item item;
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            Collect();
        }
    }
    public void Collect()
    {
        Debug.Log("Collect a " + item.name);
        bool wasCollected = Inventory.instance.Add(item);
        if (wasCollected)
        {
            Destroy(gameObject);
        }
    }
}
