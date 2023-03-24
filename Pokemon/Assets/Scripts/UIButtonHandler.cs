using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIButtonHandler : MonoBehaviour
{
    public Transform LeftHand;
    public GameObject Pokeball;
    public Vector3 Offset;

    public GameObject[] Menus;

    public DrawPokemons PokemonPageHandler;
    public TextMeshProUGUI PageText;
    public void SummonPokeball()
    {
        GameObject InstPokeball = Instantiate(Pokeball);
        InstPokeball.transform.position = LeftHand.position + Offset;
        InstPokeball.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void SummonPokeballWithContent(int ButtonId)
    {
        GameObject InstPokeball = Instantiate(Pokeball);
        InstPokeball.GetComponent<Pokeball>().Contains = PokemonPageHandler.GetPokemonFromPageAndPlace(ButtonId);
        InstPokeball.transform.position = LeftHand.position + Offset;
        InstPokeball.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void SwitchPage(string Name)
    {
        foreach (GameObject menu in Menus)
        {
            if (menu.name == Name)
            {
                menu.SetActive(true);
                continue;
            }
            menu.SetActive(false);
        }
    }

    public void ChangePokedexPage(int Change)
    {
        //Tjek om man skifter til en side der ikke findes
        if (Change + PokemonPageHandler.PageId > PokemonPageHandler.Pages.Count || Change + PokemonPageHandler.PageId < 0)
            Change = 0;    // Hvis man gør så sæt side skiftet til 0
        PokemonPageHandler.PageId += Change;
        PokemonPageHandler.PageId = Mathf.Clamp(PokemonPageHandler.PageId, 0, PokemonPageHandler.Pages.Count -1);
        ReadPages(); // Tegn sidetal
    }

    void ReadPages()
    {
        PageText.text = (PokemonPageHandler.PageId + 1).ToString() + "/" + PokemonPageHandler.Pages.Count.ToString();
    }

    private void Update()
    {
        ReadPages();
    }
}
