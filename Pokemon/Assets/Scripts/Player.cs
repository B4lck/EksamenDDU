using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public List<GameObject> pokemons = new List<GameObject>();

    public PokemonController GetControllerFromPokemon(GameObject pokemon)
    {
        return pokemons[pokemons.IndexOf(pokemon)].GetComponent<PokemonController>();
    }


    private void Awake() // Lav en singleton
    {
        if (player == null)
            player = this;
    }

    public void AddPokemon(GameObject pokemon)
    {
        pokemons.Add(pokemon);
    }

    public void RemovePokemon(GameObject pokemon)
    {
        if (pokemons.Contains(pokemon))
            pokemons.Remove(pokemon);
        else
            Debug.Log("Player does not have pokemon");
    }

}
