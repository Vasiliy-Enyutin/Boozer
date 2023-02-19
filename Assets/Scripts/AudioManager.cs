using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    public void Play(string name)
    {
        Sound sound = Array.Find(Sounds, sound => sound.Name == name);
        if (sound.Source.isPlaying)
        {
            return;
        }
        sound.Source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(Sounds, sound => sound.Name == name);
        if (!sound.Source.isPlaying)
        {
            return;
        }
        sound.Source.Stop();
    }
    
    private void Awake()
    {
        foreach (Sound sound in Sounds)
        {
            sound.Source = GetComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }
}

[Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;
    public bool Loop;
    
    [Range(0f, 1f)]
    public float Volume;
    [Range(0.1f, 3f)]
    public float Pitch;

    [HideInInspector]
    public AudioSource Source;
}
