using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioItem
{
    [HideInInspector] public AudioSource audioSource;

    public AudioClip Clip;
    public string Name;
    public bool Loop;
    [Range(0, 1f)] public float Volume;
    [Range(0, 1f)] public float Pitch;
}
