using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Pokemon>())
        {
            Pokemon pokemon = collision.gameObject.GetComponent<Pokemon>();
            if (pokemon.Capture())
            {
                Debug.Log("Du fangede en " + pokemon.Name);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                Destroy(pokemon.gameObject, pokemon.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                Destroy(gameObject, pokemon.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }
}
