using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleUiHandler : MonoBehaviour
{
    public Attack[] Attacks = new Attack[3];
    public GameObject[] AttackButtons = new GameObject[3];
    public TextMeshProUGUI[] AttackText = new TextMeshProUGUI[3];
    public RawImage[] AttackIcons = new RawImage[3];

    public PokemonController PlayerPokemon;
    public PokemonController AiPokemon;

    public TextMeshProUGUI PlayerPokemonName;
    public TextMeshProUGUI PlayerPokemonHealth;
    public Slider PlayerPokemonHealthbar;

    public TextMeshProUGUI AiPokemonName;
    public TextMeshProUGUI AiPokemonHealth;
    public Slider AiPokemonHealthbar;

    public GameObject Panel;



    private void Update()
    {
        if (PlayerPokemon != null && AiPokemon != null)
        {
            Panel.SetActive(true);
            //Opdater Stats
            for (int i = 0; i < Attacks.Length; i++)
            {
                Attacks[i] = null;
            }
            for (int i = 0; i < PlayerPokemon.Attacks.Count; i++)
            {
                Attacks[i] = PlayerPokemon.Attacks[i];
            }

            // Sæt positionen for UI
            transform.position = AiPokemon.transform.position + (Vector3.up * 2);
            transform.LookAt(Player.player.Camera);

            // Vis attack knapperne
            for (int i = 0; i < Attacks.Length; i++)
            {
                //Hvis det ikke er spillerens tur, fjern knapperne
                if (!BattleHandler.battleHandler.IsPlayerTurn) continue;
                
                //Vis Knapperne
                Attack attack = Attacks[i];
                if (attack == null)
                {
                    AttackButtons[i].SetActive(false);
                    continue;
                }
                AttackButtons[i].SetActive(true);
                AttackText[i].text = attack.Name;
                AttackIcons[i].texture = attack.Icon;
            }

            // Fix Health barene
            PlayerPokemonName.text = PlayerPokemon.pokemon.name;
            PlayerPokemonHealth.text = PlayerPokemon.Health + "/" + PlayerPokemon.MaxHealth;
            PlayerPokemonHealthbar.value = PlayerPokemon.Health / PlayerPokemon.MaxHealth;

            AiPokemonName.text = AiPokemon.pokemon.name;
            AiPokemonHealth.text = AiPokemon.Health + "/" + AiPokemon.MaxHealth;
            AiPokemonHealthbar.value = AiPokemon.Health / AiPokemon.MaxHealth;
        } else
        {
            Panel.SetActive(false);
        }
    }

    public void UseAttack(int buttonId)
    {
        // Hvis det ikke er spillerens tur skal den ikke fortsætte
        if (!BattleHandler.battleHandler.IsPlayerTurn) return;

        PlayerPokemon.Hit(Attacks[buttonId], AiPokemon);
        if (AiPokemon.Health <= 0)
        {
            BattleHandler.battleHandler.EndBattle();
            Destroy(AiPokemon.gameObject);
            //Opdater UI mht hvem vandt osv
        }

        BattleHandler.battleHandler.IsPlayerTurn = false;
    }

    public void Flee()
    {
        BattleHandler.battleHandler.EndBattle();
    }
}
