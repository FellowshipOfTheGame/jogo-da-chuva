using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoopPlay : MonoBehaviour
{
    [SerializeField] private AudioSource musicLoopSource;
    [SerializeField] private AudioClip musicIntro;
    void Start()
    {
        musicLoopSource.PlayOneShot(musicIntro);
        musicLoopSource.PlayScheduled(AudioSettings.dspTime + musicIntro.length);
    }
}
