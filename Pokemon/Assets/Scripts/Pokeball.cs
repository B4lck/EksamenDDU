using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    public Animator Animator;
    public GameObject Partikel;
    public PokemonController Contains;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PokemonController>())
        {
            PokemonController pokemon = collision.gameObject.GetComponent<PokemonController>();
            pokemon.PositionLocked = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            if (Contains == null)
            {
                if (pokemon.Capture(transform))
                {
                    //Afspil lyd
                    SoundManager.manager.Play("Pokemon Fanget");

                    //Animer
                    Animator.SetTrigger("Capture");
                    transform.LookAt(collision.transform);
                    Instantiate(Partikel, pokemon.transform.position, Quaternion.identity, pokemon.transform);


                    //Gem pokemon
                    Player.player.AddPokemon(pokemon.gameObject);

                    //Slet efter animationen
                    float TidTilbage = pokemon.animator.GetCurrentAnimatorStateInfo(0).length;
                    pokemon.CaptureIn = TidTilbage;
                    pokemon.CountDown = true;
                    Destroy(gameObject, TidTilbage);
                }
            } else
            {
                Debug.Log(Contains);
                BattleHandler.battleHandler.StartBattle(pokemon, Contains);
            }
        }
    }

    public void FixRigidbody()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 5f);
    }
}
