using UnityEngine.Audio;
using System;
using UnityEngine;

// How to use:
// Inside some script of an object you desire to play a sound listed on the AudioManager
// you can simply type: 
// ***************** 'FindObjectOfType<AudioManager>().Play("Name of the sound");' ******************
// passing the name of the sound to play it.

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _SFX_output;
    [SerializeField] private AudioMixerGroup _Music_output;
    [SerializeField] private Sound[] _SFXs;
    [SerializeField] private Sound[] _musics;

    // Awake is called before the Start method
    protected virtual void Awake()
    {
        SetSoundSettings(_SFXs, _SFX_output);
        SetSoundSettings(_musics, _Music_output);        
    }

    private void SetSoundSettings(Sound[] sounds, AudioMixerGroup output)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = output;
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = s.spatialBlend;
        }
    }

    public void PlaySFX (string name)
    {
        Play(name, _SFXs);
    }

    public void StopSFX (string name)
    {
        Stop(name, _SFXs);
    }

    public void PauseSFX(string name)
    {
        Pause(name, _SFXs);
    }

    public void UnpauseSFX(string name)
    {
        Unpause(name, _SFXs);
    }

    public void ReturnSFXAudioclip(string name)
    {
        ReturnAudioclip(name, _SFXs);
    }

    public void PlayMusic(string name)
    {
        Play(name, _musics);
    }

    public void StopMusic(string name)
    {
        Stop(name, _musics);
    }

    public void PauseMusic(string name)
    {
        Pause(name, _musics);
    }

    public void UnpauseMusic(string name)
    {
        Unpause(name, _musics);
    }

    public void ReturnMusicAudioclip(string name)
    {
        ReturnAudioclip(name, _musics);
    }

    // Play the sound with the 'name' passed by parameter
    private void Play(string name, Sound[] sounds)
    {
        // search in the sound array the sound with de given name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found to PLAY!");
            return;
        }

        // Play the sound found
        s.source.Play();
    }

    // Stop the sound with the 'name' passed by parameter
    private void Stop(string name, Sound[] sounds)
    {
        // search in the sound array the sound with de given name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found to STOP!");
            return;
        }

        // Stop the sound found
        s.source.Stop();
    }

    // Stop the sound with the 'name' passed by parameter
    public void Pause(string name, Sound[] sounds)
    {
        // search in the sound array the sound with de given name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found to PAUSE!");
            return;
        }

        // Test if the audio is playing
        if (s.source.isPlaying)
            s.source.Pause();
    }

    // Stop the sound with the 'name' passed by parameter
    private void Unpause(string name, Sound[] sounds)
    {
        // search in the sound array the sound with de given name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found to UNPAUSE!");
            return;
        }

        // Test if the audio is not playing
        if (s.source.isPlaying == false)
            s.source.UnPause();
    }

    // Return the audioclip of the given name
    private AudioClip ReturnAudioclip(string name, Sound[] sounds)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        return s.clip;
    }

    // Not working, AudioSettings.dspTime is not returning 
    public void PlayMusicOneShot(string intro, string loop)
    {
        AudioSource musicSource = Array.Find(_musics, sound => sound.name == loop).source;
        AudioClip musicStart = Array.Find(_musics, sound => sound.name == intro).clip;

        musicSource.PlayOneShot(musicStart);
        Debug.Log(AudioSettings.dspTime);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }
}