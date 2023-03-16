using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public List<Pokemon> pokemons = new List<Pokemon>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Too many player scripts");
    }

}
