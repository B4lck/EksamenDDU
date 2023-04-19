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
   
    public bool inBattle = false;
    public PokemonController InBattleWith;
    public PokemonController PlayerPokemon;
    public bool IsPlayerTurn;

    public BattleUiHandler BattleUiHandler;

    public void StartBattle(PokemonController toBattle, PokemonController playerPokemon)
    {
        inBattle = true;
        PlayerPokemon = playerPokemon;
        InBattleWith = toBattle;
        ArmUI.SetActive(false);

        BattleUiHandler.gameObject.SetActive(true);
        BattleUiHandler.PlayerPokemon = PlayerPokemon;
        BattleUiHandler.AiPokemon = InBattleWith;

        IsPlayerTurn = true; 

        // Afspil lyd
        SoundManager.manager.Stop("Main Theme");
        SoundManager.manager.Stop("Pokemon Fanget");
        SoundManager.manager.Play("Battle Musik");
        /*
        Placer pokemonsne over for hinanden, med spillerens pokemon ved sin side 
         */
    }

    public void AiAttack()
    {
        //Vælg angreb
        int RandomAttackId = (int)Random.Range(0, InBattleWith.Attacks.Count - 1);
        Attack attack = InBattleWith.Attacks[RandomAttackId];

        //Slå spilleren
        InBattleWith.Hit(attack, PlayerPokemon);
        BattleUiHandler.SetStatus(InBattleWith.pokemon.Name + " used " + attack.name);
        if (PlayerPokemon.Health <= 0f)
        {
            InBattleWith.LevelUp();
            Player.player.RemovePokemon(PlayerPokemon.gameObject);
            EndBattle();
        }

        //Spillers tur
        IsPlayerTurn = true;
    }

    public void EndBattle()
    {
        inBattle = false;
        ArmUI.SetActive(true);

        BattleUiHandler.PlayerPokemon = null;
        BattleUiHandler.AiPokemon = null;

        SoundManager.manager.Play("Main Theme");
        SoundManager.manager.Stop("Battle Musik");
    }

    private float CountDown = 2f;
    private void Update()
    {
        if (inBattle)
        {
            if (!IsPlayerTurn)
            {
                CountDown -= Time.deltaTime;
                if (CountDown <= 0f)
                {
                    AiAttack();
                    CountDown = 2f;
                }
            }
        }
    }
}
