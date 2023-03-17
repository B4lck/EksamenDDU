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
                        
            if (pokemon != null)
                Images[i].texture = pokemon.img;
            else
                Images[i].texture = null;
        }
    }


    void GetPlayerPokemonsAndSetPages()
    {
        Pages.Clear();
        int i = 0;
        foreach (Pokemon pokemon in Player.player.pokemons)
        {
            if ((int)Mathf.Floor(i / 6) >= Pages.Count)
                Pages.Add(new Pokemon[6]);
            Pages[(int)Mathf.Floor(i / 6)][i % 6] = pokemon;
            i++;
        }
    }

    private void Update()
    {
        GetPlayerPokemonsAndSetPages();
        DisplayPage(PageId);
    }
}
