using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonSpawner : MonoBehaviour
{
    public GameObject PokemonPrefab;
    public Pokemon[] SpawnAblePokemons;
    public GameObject[] CurrentPokemons;

    public float TimeUntilNextSpawn;
    
    void SpawnPokemon()
    {
        // Sæt variablerne
        Pokemon pokemon = SpawnAblePokemons[(int)Random.Range(0f, SpawnAblePokemons.Length-1)];
        GameObject pokemonObject = Instantiate(PokemonPrefab, transform.position, Quaternion.identity, transform);
        PokemonController pokemonController = pokemonObject.GetComponent<PokemonController>();
        
        // Definer pokemon til controlleren
        pokemonController.pokemon = pokemon;
        pokemonController.meshFilter.mesh = pokemon.mesh;
        pokemonController.meshRenderer.material = pokemon.Material;

        // Tilføj til listen
        AddPokemonToList(pokemonObject);
    }

    void AddPokemonToList(GameObject pokemon)
    {
        for (int i = 0; i < CurrentPokemons.Length; i++)
        {

        }
    }

    void RemoveFromList(GameObject pokemon)
    {

    }
}
