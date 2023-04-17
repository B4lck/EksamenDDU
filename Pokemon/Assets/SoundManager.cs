using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager manager;
    public void Awake()
    {
        manager = this;
    }

    public List<AudioClip> Sounds = new List<AudioClip>();

    public void Play(AudioClip Sound)
    {
        
    }

    public void Stop(AudioClip Sound)
    {
        
    }
}
