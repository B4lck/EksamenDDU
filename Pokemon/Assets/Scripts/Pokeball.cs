using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PokemonController>())
        {
            PokemonController pokemon = collision.gameObject.GetComponent<PokemonController>();
            if (pokemon.Capture())
            {
                Debug.Log("Du fangede en " + pokemon.pokemon.Name);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                Destroy(pokemon.gameObject, pokemon.animator.GetCurrentAnimatorStateInfo(0).length);
                Destroy(gameObject, pokemon.animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }
}
