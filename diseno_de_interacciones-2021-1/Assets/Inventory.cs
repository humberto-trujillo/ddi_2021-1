using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static protected Inventory s_InventoryInstance;
    static public Inventory InventoryInstance { get { return s_InventoryInstance; } }
    public int space = 10;
    public List<Item> items = new List<Item>();

    void Awake()
    {
        s_InventoryInstance = this;
    }

    public void Add(Item newItem)
    {
        if (items.Count < space)
        {
            items.Add(newItem);
        }
        else
        {
            Debug.Log("No hay espacio disponible");
        }
    }

    public void Remove(Item itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
        }
        else
        {
            Debug.Log("No esta el item");
        }
    }
}
