using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawPokemons : MonoBehaviour
{
    [SerializeField]
    public List<Pokemon[]> Pages = new List<Pokemon[]>();
    [SerializeField]
    public RawImage[] Images = new RawImage[6];


    public int PageId = 0;

    public void DisplayPage(int PageId)
    {
        for (int i = 0; i < Images.Length; i++)
        {
            if (Pages.Count == 0) break;

            Pokemon pokemon = Pages[PageId][i];
                        
            if (pokemon != null) // Hvis pokemonen findes
                // Sæt texturen til pokemonens billede
                Images[i].texture = pokemon.img;
            else
                // Ellers giv ingen texture
                Images[i].texture = null;
        }
    }


    void GetPlayerPokemonsAndSetPages()
    {
        //  Slet alle pokemons og gå igennem igen.
        Pages.Clear();
        int i = 0;
        foreach (PokemonController pokemon in Player.player.pokemons) // Gå igennem alle spillerens pokemons
        {
            //Tjek om der er flere sider
            if ((int)Mathf.Floor(i / 6) >= Pages.Count)
                Pages.Add(new Pokemon[6]); // Hvis der ikke er det, så lav en ny
            Pages[(int)Mathf.Floor(i / 6)][i % 6] = pokemon.pokemon; // Tilføj pokemon til side
            i++;
        }
    }

    private void Update()
    {
        GetPlayerPokemonsAndSetPages();
        DisplayPage(PageId);
    }
}
