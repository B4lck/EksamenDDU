using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public List<Pokemon> pokemons = new List<Pokemon>();

    public Pokemon StartPokemon;

    private void Awake()
    {
        if (player == null)
            player = this;
        else
            Debug.LogError("Too many player scripts");
    }

    public void AddPokemon(Pokemon pokemon)
    {
        pokemons.Add(pokemon);
    }

    public void Start()
    {
        player.AddPokemon(StartPokemon);
    }

}
