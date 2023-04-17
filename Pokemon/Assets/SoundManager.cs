using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager manager; // Singleton
    
    public Sound[] Sounds;

    public void Awake()
    {
        manager = this;
        foreach (Sound sound in Sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.Audio;
            sound.source.volume = sound.Volume;
            sound.source.loop = sound.Loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        s.source.Stop();
    }

}
