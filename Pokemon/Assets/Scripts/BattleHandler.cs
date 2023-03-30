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
        /*
        Placer pokemonsne over for hinanden, med spillerens pokemon ved sin side 
         */
    }

    public void AiAttack()
    {
        //Vælg angreb
        int RandomAttackId = (int)Random.Range(0, InBattleWith.Attacks.Count - 1);
        Attack attack = InBattleWith.Attacks[RandomAttackId];
        Debug.Log("Ai used " + attack.name);

        //Slå spilleren
        InBattleWith.Hit(attack, PlayerPokemon);
        if (PlayerPokemon.Health <= 0f)
        {
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
        /*
        Enable spillerens arm UI igen 
         */
    }

    private float CountDown = 2f;
    private void Update()
    {
        if (inBattle)
        {
            Debug.Log("In battle");
            if (!IsPlayerTurn)
            {
                Debug.Log("It is not players turn");
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
