using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Animator.SetTrigger("Capture");
                transform.LookAt(collision.transform);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                Player.instance.pokemons.Add(pokemon.pokemon);
                Destroy(pokemon.gameObject, pokemon.animator.GetCurrentAnimatorStateInfo(0).length);
                Destroy(gameObject, pokemon.animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }
}
