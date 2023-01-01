using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    [SerializeField] private AudioSource musicLoopSource;
    [SerializeField] private AudioClip musicIntro;
    [SerializeField] private bool _isLoopedMusic;
    void Start()
    {
        if (_isLoopedMusic) {
            musicLoopSource.PlayOneShot(musicIntro);
            musicLoopSource.PlayScheduled(AudioSettings.dspTime + musicIntro.length);
        }
        else
            musicLoopSource.Play();
    }
}
