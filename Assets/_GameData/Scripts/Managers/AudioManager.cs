using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Ses Ayarları")]
    public AudioItem[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SetupAudioSources();
    }
    public void Play(string name)
    {
        AudioItem sound = Array.Find(sounds, sound => sound.Name == name);
        if (sound == null)
        {
            Debug.LogWarning("Ses: " + name + " bulunamadı!");
            return;
        }

        sound.audioSource.Play();
    }
    public void Stop(string name)
    {
        AudioItem sound = Array.Find(sounds, sound => sound.Name == name);
        if (sound == null)
        {
            Debug.LogWarning("Ses: " + name + " bulunamadı!");
            return;
        }

        sound.audioSource.Stop();
    }
    private void SetupAudioSources()
    {
        foreach (AudioItem sound in sounds)
        {
            sound.audioSource = CreateAudioSource(sound);
        }
    }

    private AudioSource CreateAudioSource(AudioItem sound)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound.Clip;
        audioSource.name = sound.Name;
        audioSource.volume = sound.Volume;
        audioSource.pitch = sound.Pitch;
        audioSource.loop = sound.Loop;

        return audioSource;
    }
}

