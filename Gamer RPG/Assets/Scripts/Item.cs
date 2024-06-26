using UnityEngine;
[CreateAssetMenu(fileName = "Name Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public virtual void Use()
    {
        Debug.Log("Using" + name);  
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this);
        }
    }
}
