using UnityEngine;

public enum ItemType
{
    Equip, Weapon, Medicine
}

[CreateAssetMenu(fileName= "New Item", menuName="Inventory/Generic")]
public class Item : ScriptableObject
{
    public ItemType itemType = ItemType.Equip;
    public Sprite icon = null;

    public virtual void Use()
    {
        Debug.Log($"Usando item {name}");
    }
}
