using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonSpawner : MonoBehaviour
{
    public GameObject PokemonPrefab;
    public float TimeUntilNextSpawn = 5f;

    public List<Pokemon> pokemons = new List<Pokemon>();

    public GameObject[] CurrentPokemons = new GameObject[7];

    public void SpawnPokemon(Pokemon pokemon, int level = 1)
    {
        GameObject InstantiatedPokemonPrefab = Instantiate(PokemonPrefab, transform.position, Quaternion.identity, transform);
        AddPokemon(InstantiatedPokemonPrefab);
        PokemonController pokemonController = InstantiatedPokemonPrefab.GetComponent<PokemonController>();
        pokemonController.pokemon = pokemon;
        pokemonController.Level = level;
        pokemonController.meshFilter.mesh = pokemon.mesh;
        pokemonController.meshRenderer.material = pokemon.Material;



        TimeUntilNextSpawn = Random.Range(4f, 20f);
    }

    void AddPokemon(GameObject pokemon)
    {
        for (int i = 0; i < CurrentPokemons.Length; i++)
        {
            if (CurrentPokemons[i] == null)
            {
                CurrentPokemons[i] = pokemon;
                return;
            }
        }
    }

    bool RoomForMore()
    {
        for (int i = 0; i < CurrentPokemons.Length; i++)
        {
            if (CurrentPokemons[i] == null) return true;
        }
        return false;
    }

    void RemoveAllDeadPokemons()
    {
        for (int i = 0; i < CurrentPokemons.Length; i++)
        {
            if (CurrentPokemons[i] == null)
                continue;

            if (CurrentPokemons[i].activeInHierarchy == false)
            {
                CurrentPokemons[i] = null;
            }
        }
    }

    private void Update()
    {
        RemoveAllDeadPokemons();
        TimeUntilNextSpawn -= Time.deltaTime;
        if (TimeUntilNextSpawn <= 0 && RoomForMore())
        {
            Pokemon RandomPokemon = pokemons[(int)Mathf.Floor(Random.Range(0f, pokemons.Count))];
            SpawnPokemon(RandomPokemon, (int)Random.Range(1f, 4f) + 1);
        }
    }
}
