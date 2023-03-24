using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    // Single ton
    public static BattleHandler battleHandler;
    public void Awake()
    {
        battleHandler = this;
    }


    public GameObject ArmUI;
    public GameObject PokemonPrefab;

    public bool inBattle = false;
    public PokemonController InBattleWith;
    public PokemonController PlayerPokemon;
    public bool IsPlayerTurn;

    public BattleUiHandler BattleUiHandler;

    public void StartBattle(PokemonController toBattle, PokemonController playerPokemon)
    {
        PlayerPokemon = playerPokemon;
        InBattleWith = toBattle;
        ArmUI.SetActive(false);

        BattleUiHandler.PlayerPokemon = PlayerPokemon;
        BattleUiHandler.AiPokemon = InBattleWith;
        /*
        Placer pokemonsne over for hinanden, med spillerens pokemon ved sin side 
        
        Init UI - evt oven over enemy pokemon
         - Disable spillerens arm UI
        
        Giv spilleren sin tur


         */
    }

    public void AiAttack() 
    {
        /*
        Gå igennem AI'ens angreb
        Vælg tilfældigt angreb
        Læs om spilleren er død
         - Hvis ikke, giv turen til spilleren.
         */
    }

    public void EndBattle()
    {
        ArmUI.SetActive(true);

        BattleUiHandler.PlayerPokemon = null;
        BattleUiHandler.AiPokemon = null;
        /*
        Enable spillerens arm UI igen 
         */
    }
}
