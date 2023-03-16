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
    


    public void DisplayPage(int PageId)
    {
        for (int i = 0; i < Images.Length; i++)
        {
            if (Pages.Count == 0) { continue; }
            if (Pages[PageId].Length < i)
            {
                Images[i].texture = null;
                continue;
            }
            Pokemon pokemon = Pages[PageId][i];
            Images[i].texture = pokemon.img;
        }
    }


    void GetPlayerPokemonsAndSetPages()
    {
        Pages.Clear();
        int count = 0;
        foreach (Pokemon pokemon in Player.player.pokemons)
        {
            count++;
            if ((int)Mathf.Floor(count / 6) <= Pages.Count)
            {
                Pages.Add(new Pokemon[6]);
            }
            Pages[(int)Mathf.Floor(count / 6)][count % 6] = pokemon;
        }
    }

    private void Update()
    {
        GetPlayerPokemonsAndSetPages();
        DisplayPage(0);
    }
}
