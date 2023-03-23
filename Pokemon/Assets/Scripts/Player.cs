using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public List<PokemonController> pokemons = new List<PokemonController>();


    private void Awake() // Lav en singleton
    {
        if (player == null)
            player = this;
    }

    public void AddPokemon(PokemonController pokemon)
    {
        pokemons.Add(pokemon);
    }

    public void RemovePokemon(PokemonController pokemon)
    {
        if (pokemons.Contains(pokemon))
            pokemons.Remove(pokemon);
        else
            Debug.Log("Player does not have pokemon");
    }

}
