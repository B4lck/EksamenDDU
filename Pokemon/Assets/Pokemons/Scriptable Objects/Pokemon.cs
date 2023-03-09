using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pokemon", menuName = "Pokemon")]
public class Pokemon : ScriptableObject
{
    public enum PokemonType
    {
        Normal,
        Fire,
        Water,
        Grass,
        Electric,
        Rock,
        Ground,
        Steel,
        Bug, 
        Poison,
        Flying,
        Fighting,
        Dark,
        Ice,
        Ghost,
        Dragon,
        Fairy,
        Psychic
    }
    public string Name;
    public List<PokemonType> Type;
    public int Level;
    public string[] Attacks;
    public float Health;

    public Sprite img;
    public Mesh mesh;
}
