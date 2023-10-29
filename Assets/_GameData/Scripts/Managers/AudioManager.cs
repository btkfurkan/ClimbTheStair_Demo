using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Ses Ayarlarý")]
    public AudioItem[] sounds;
    public static AudioManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        foreach (AudioItem sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.Clip;

            sound.audioSource.name = sound.Name;
            sound.audioSource.volume = sound.Volume;
            sound.audioSource.pitch = sound.Pitch;
            sound.audioSource.loop = sound.Loop;
        }
    }
    public void Play(string name)
    {
        AudioItem sound = Array.Find(sounds, sound => sound.Name == name);
        if (sound == null)
        {
            print("Ses : " + name + " bulanamdý!");
            return;
        }

        sound.audioSource.Play();
    }
    public void PlayOne(AudioClip clip)
    {
        AudioItem sound = Array.Find(sounds, sound => sound.Name == name);
        if (sound == null)
        {
            print("Ses : " + name + " bulanamdý!");
            return;
        }

        sound.audioSource.PlayOneShot(clip);
    }

    public void Stop(string name)
    {
        AudioItem sound = Array.Find(sounds, sound => sound.Name == name);
        if (sound == null)
        {
            print("Ses : " + name + " bulanamdý!");
        }

        sound.audioSource.Stop();
    }
}

