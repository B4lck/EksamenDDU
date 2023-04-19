using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]
public class Attack : ScriptableObject
{
    public string Name;
    public Pokemon.PokemonType AttackType;
    public float Damage;
    public Texture Icon;
}
