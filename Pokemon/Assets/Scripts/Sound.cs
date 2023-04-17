using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip Audio;
    [Range(0f,1f)]
    public float Volume;
    public bool Loop;

    [HideInInspector]
    public AudioSource source;
}
