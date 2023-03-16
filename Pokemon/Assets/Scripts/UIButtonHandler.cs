using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHandler : MonoBehaviour
{
    public Transform LeftHand;
    public GameObject Pokeball;
    public Vector3 Offset;

    public GameObject[] Menus;
    public void SummonPokeball()
    {
        GameObject InstPokeball = Instantiate(Pokeball);
        InstPokeball.transform.position = LeftHand.position + Offset;
        InstPokeball.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void SwitchPage(string Name)
    {
        foreach (GameObject menu in Menus)
        {
            if (menu.name == Name)
            {
                menu.SetActive(true);
                continue;
            }
            menu.SetActive(false);
        }
    }
}
