using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Potion", menuName="Inventory/Medicine")]
public class Potion : Item
{
    public float lifeAmount = 5.0f;
    public float effectiveness = 10f;
    public override void Use()
    {
        base.Use();
        // subirme la vida
        Debug.Log($"Aumentado la vida en {lifeAmount} unidades");
    }
}
