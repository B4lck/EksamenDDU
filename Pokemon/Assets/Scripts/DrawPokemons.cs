using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawPokemons : MonoBehaviour
{
    public List<PokemonController[]> Pages = new List<PokemonController[]>();
    public RawImage[] Images = new RawImage[6];


    public int PageId = 0;

    public void DisplayPage(int PageId)
    {
        for (int i = 0; i < Images.Length; i++)
        {
            Images[i].gameObject.SetActive(false);
        }
        int j = 0;
        foreach (PokemonController pokemon in Pages[PageId])
        {
            if (pokemon == null) {
                continue;
            }
            Images[j].gameObject.SetActive(true);
            Images[j].texture = pokemon.pokemon.img;
            j++;
        }
    }

    public PokemonController GetPokemonFromPageAndPlace(int placeId)
    {
        return Pages[PageId][placeId];
    }

    void GetPlayerPokemonsAndSetPages()
    {
        //  Slet alle pokemons og gå igennem igen.
        Pages.Clear();
        int i = 0;
        foreach (GameObject pokemon in Player.player.pokemons) // Gå igennem alle spillerens pokemons
        {
            //Tjek om der er flere sider
            if ((int)Mathf.Floor(i / 6) >= Pages.Count)
                Pages.Add(new PokemonController[6]); // Hvis der ikke er det, så lav en ny
            Pages[(int)Mathf.Floor(i / 6)][i % 6] = pokemon.GetComponent<PokemonController>(); // Tilføj pokemon til side
            i++;
        }

        //Hvis der ikke er nogen pokemons, lav en side alligevel.
        if (Pages.Count == 0)
            Pages.Add(new PokemonController[6]);
    }

    private void Update()
    {
        GetPlayerPokemonsAndSetPages();
        DisplayPage(PageId);
    }
}
