using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonController : MonoBehaviour
{
    static Pokemon.PokemonType Normal = Pokemon.PokemonType.Normal;
    static Pokemon.PokemonType Fire = Pokemon.PokemonType.Fire;
    static Pokemon.PokemonType Water = Pokemon.PokemonType.Water;
    static Pokemon.PokemonType Grass = Pokemon.PokemonType.Grass;
    static Pokemon.PokemonType Electric = Pokemon.PokemonType.Electric;
    static Pokemon.PokemonType Ice = Pokemon.PokemonType.Ice;
    static Pokemon.PokemonType Fighting = Pokemon.PokemonType.Fighting;
    static Pokemon.PokemonType Poison = Pokemon.PokemonType.Poison;
    static Pokemon.PokemonType Ground = Pokemon.PokemonType.Ground;
    static Pokemon.PokemonType Flying = Pokemon.PokemonType.Flying;
    static Pokemon.PokemonType Psychic = Pokemon.PokemonType.Psychic;
    static Pokemon.PokemonType Bug = Pokemon.PokemonType.Bug;
    static Pokemon.PokemonType Rock = Pokemon.PokemonType.Rock;
    static Pokemon.PokemonType Ghost = Pokemon.PokemonType.Ghost;
    static Pokemon.PokemonType Dragon = Pokemon.PokemonType.Dragon;
    static Pokemon.PokemonType Dark = Pokemon.PokemonType.Dark;
    static Pokemon.PokemonType Steel = Pokemon.PokemonType.Steel;
    static Pokemon.PokemonType Fairy = Pokemon.PokemonType.Fairy;


    static Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>> TypeWeaknesses = new Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>>()
    {
        {Normal, new List<Pokemon.PokemonType>() { Rock, Steel} },
        {Fire, new List<Pokemon.PokemonType>() { Fire, Water, Rock, Dragon} },
        {Water, new List<Pokemon.PokemonType>() { Water, Grass,Dragon} },
        {Grass, new List<Pokemon.PokemonType>() { Fire, Grass,Poison, Flying, Bug, Dragon, Steel} },
        {Electric, new List<Pokemon.PokemonType>() { Grass, Electric,Dragon} },
        {Ice, new List<Pokemon.PokemonType>() { Fire, Water,Ice, Steel} },
        {Fighting, new List<Pokemon.PokemonType>() { Poison, Flying,Psychic, Bug, Fairy} },
        {Poison, new List<Pokemon.PokemonType>() { Poison, Ground,Bug, Ghost} },
        {Ground, new List<Pokemon.PokemonType>() { Grass, Bug} },
        {Flying, new List<Pokemon.PokemonType>() { Electric, Rock, Steel} },
        {Psychic, new List<Pokemon.PokemonType>() { Psychic, Steel} },
        {Bug, new List<Pokemon.PokemonType>() { Fire, Fighting, Poison, Flying, Ghost, Steel, Fairy} },
        {Rock, new List<Pokemon.PokemonType>() { Fighting, Ground, Steel} },
        {Ghost, new List<Pokemon.PokemonType>() { Dragon} },
        {Dragon, new List<Pokemon.PokemonType>() { Steel} },
        {Dark, new List<Pokemon.PokemonType>() { Fighting, Dark, Fairy} },
        {Steel, new List<Pokemon.PokemonType>() { Fire, Water, Electric, Steel} },
        {Fairy, new List<Pokemon.PokemonType>() { Fire, Poison, Steel} },
    };

    static Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>> TypeAmplifier = new Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>>()
    {
        {Normal, new List<Pokemon.PokemonType>() { } },
        {Fire, new List<Pokemon.PokemonType>() { Grass, Ice, Bug, Steel} },
        {Water, new List<Pokemon.PokemonType>() { Water, Ground, Rock} },
        {Grass, new List<Pokemon.PokemonType>() { Water, Ground, Rock} },
        {Electric, new List<Pokemon.PokemonType>() { Water, Flying} },
        {Ice, new List<Pokemon.PokemonType>() { Grass, Ground, Flying, Dragon} },
        {Fighting, new List<Pokemon.PokemonType>() { Normal, Ice, Rock, Dark, Steel} },
        {Poison, new List<Pokemon.PokemonType>() { Grass, Fairy} },
        {Ground, new List<Pokemon.PokemonType>() { Fire, Electric, Poison, Rock, Steel} },
        {Flying, new List<Pokemon.PokemonType>() { Grass, Fighting, Bug } },
        {Psychic, new List<Pokemon.PokemonType>() { Fighting, Poison,  } },
        {Bug, new List<Pokemon.PokemonType>() { Grass, Psychic, Dragon} },
        {Rock, new List<Pokemon.PokemonType>() { Fire, Ice, Ground, Bug} },
        {Ghost, new List<Pokemon.PokemonType>() { Psychic, Ghost} },
        {Dragon, new List<Pokemon.PokemonType>() { Dragon} },
        {Dark, new List<Pokemon.PokemonType>() { Psychic, Rock} },
        {Steel, new List<Pokemon.PokemonType>() { Ice, Rock, Fairy} },
        {Fairy, new List<Pokemon.PokemonType>() { Fighting, Dragon, Dark} },
    };

    static Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>> TypeZero = new Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>>()
    {
        {Normal, new List<Pokemon.PokemonType>() { Ghost } },
        {Fire, new List<Pokemon.PokemonType>() { } },
        {Water, new List<Pokemon.PokemonType>() { } },
        {Grass, new List<Pokemon.PokemonType>() { } },
        {Electric, new List<Pokemon.PokemonType>() { Ground} },
        {Ice, new List<Pokemon.PokemonType>() { } },
        {Fighting, new List<Pokemon.PokemonType>() { Ghost} },
        {Poison, new List<Pokemon.PokemonType>() { Steel} },
        {Ground, new List<Pokemon.PokemonType>() { Flying} },
        {Flying, new List<Pokemon.PokemonType>() { } },
        {Psychic, new List<Pokemon.PokemonType>() { Dark} },
        {Bug, new List<Pokemon.PokemonType>() { } },
        {Rock, new List<Pokemon.PokemonType>() { } },
        {Ghost, new List<Pokemon.PokemonType>() { Normal} },
        {Dragon, new List<Pokemon.PokemonType>() { Fairy} },
        {Dark, new List<Pokemon.PokemonType>() { } },
        {Steel, new List<Pokemon.PokemonType>() { } },
        {Fairy, new List<Pokemon.PokemonType>() { } },
    };

    public Pokemon pokemon;
    public Animator animator;

    public bool Capture()
    {
        if (Random.Range(1, 3) != 123) // Skal laves om til 50/50
        {
            animator.SetTrigger("InCapture");
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool Contains(List<Pokemon.PokemonType> types, Pokemon.PokemonType type)
    {
        return types.Contains(type);
    }

    public float Mitigate(float Damage, Pokemon.PokemonType type)
    {
        float MitigatedDamage = Damage;
        foreach (Pokemon.PokemonType _type in TypeWeaknesses[type])
        {
            if (Contains(pokemon.Type, _type))
            {
                MitigatedDamage /= 2;
            }
        }
        foreach (Pokemon.PokemonType _type in TypeAmplifier[type])
        {
            if (Contains(pokemon.Type, _type))
            {
                MitigatedDamage *= 2;
            }
        } 
        foreach (Pokemon.PokemonType _type in TypeZero[type])
        {
            if (Contains(pokemon.Type, _type))
            {
                MitigatedDamage = 0;
            }
        }
        return MitigatedDamage;
    }

    public void TakeDamage(float Damage, Pokemon.PokemonType DamageType)
    {
        pokemon.Health -= Mitigate(Damage, DamageType);
    }
}
