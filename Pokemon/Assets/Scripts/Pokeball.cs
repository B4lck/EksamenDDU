using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pokeball : MonoBehaviour
{
    public Animator Animator;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PokemonController>())
        {
            PokemonController pokemon = collision.gameObject.GetComponent<PokemonController>();
            if (pokemon.Capture(transform))
            {
                //Animer
                Animator.SetTrigger("Capture");
                transform.LookAt(collision.transform);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                pokemon.PositionLocked = true;

                //Gem pokemon
                Player.player.AddPokemon(pokemon);

                //Slet efter animationen
                Destroy(pokemon.gameObject, pokemon.animator.GetCurrentAnimatorStateInfo(0).length);
                Destroy(gameObject, pokemon.animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }

    public void FixRigidbody()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 5f);
    }
}
