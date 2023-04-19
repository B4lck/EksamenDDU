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

    public bool DoesEvovle;
    public Pokemon EvolveTo;
    public int EvolveLevel;

    public Texture img;
    public Mesh mesh;
    public Material Material;

    public Texture[] TypeImages;
}
