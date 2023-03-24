using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    public Animator Animator;
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
                    //Animer
                    Animator.SetTrigger("Capture");
                    transform.LookAt(collision.transform);

                    //Gem pokemon
                    Player.player.AddPokemon(pokemon.gameObject);

                    //Slet efter animationen
                    //Destroy(pokemon.gameObject, pokemon.animator.GetCurrentAnimatorStateInfo(0).length);
                    Destroy(gameObject, pokemon.animator.GetCurrentAnimatorStateInfo(0).length);
                }
            } else
            {
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
