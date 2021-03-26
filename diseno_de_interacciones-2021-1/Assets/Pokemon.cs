using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokemonType
{
    Water, Fire, Plant
}

[CreateAssetMenu(fileName= "New Pokemon", menuName="Inventory/Pokemon")]
public class Pokemon : Item
{
    public PokemonType pokemonType = PokemonType.Water;

}
