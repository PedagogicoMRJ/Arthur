using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour, IInteractable
{
    public Item item;

    public void Interact(){
        Collect();
    }
    public void Collect(){
        Debug.Log("Collected a " + item.name);
        bool wasCollected = Inventory.instance.Add(item);
        if(wasCollected){
            Destroy(gameObject);
        }
    }    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
