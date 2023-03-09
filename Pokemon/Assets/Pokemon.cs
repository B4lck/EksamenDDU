using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
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
    public int Health;

    public Animator Animator;

    public bool Capture()
    {
        if (Random.Range(1, 3) == 1)
        {
            Animator.SetTrigger("InCapture");
            return true;
        }
        else
        {
            return false;
        }
    }
}
