using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public List<Pokemon> pokemons = new List<Pokemon>();

    public Pokemon StartPokemon;

    private void Awake() // Lav en singleton
    {
        if (player == null)
            player = this;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        pokemons.Add(pokemon);
    }

    public void RemovePokemon(Pokemon pokemon)
    {
        if (pokemons.Contains(pokemon))
            pokemons.Remove(pokemon);
        else
            Debug.Log("Player does not have pokemon");
    }
    public void Start()
    {
        pokemons.Add(StartPokemon);
    }

}
