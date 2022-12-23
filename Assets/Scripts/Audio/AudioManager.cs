using UnityEngine.Audio;
using System;
using UnityEngine;

// How to use:
// Inside some script of an object you desire to play a sound listed on the AudioManager
// you can simply type: 
// ***************** 'FindObjectOfType<AudioManager>().Play("Name of the sound");' ******************
// passing the name of the sound to play it.

public class AudioManager : Audio
{ 
    // 'instance' references to itself
    public static AudioManager Instance;

    // Awake is called before the Start method
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.outputAudioMixerGroup = s.output;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
}