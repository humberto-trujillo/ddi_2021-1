using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//añadir objeto al inventario
public class PickUpObject : Interactable
{
    public Item item;
    public override void Interact()
    {
        // base.Interact();
        // refer al invetario, llamar metodo de insert
        Inventory.InventoryInstance.Add(item);
        Destroy(this.gameObject);
    }
}
