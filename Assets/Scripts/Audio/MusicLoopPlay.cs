using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoopPlay : MonoBehaviour
{
    public static MusicLoopPlay Instance;
    [SerializeField] private AudioSource musicLoopSource;
    [SerializeField] private AudioClip musicIntro;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        musicLoopSource.PlayOneShot(musicIntro);
        musicLoopSource.PlayScheduled(AudioSettings.dspTime + musicIntro.length);
    }

    public void StopTheMusic()
    {
        AudioListener.pause = true;
    }

    public void UnstopTheMusic()
    {
        //musicLoopSource.UnPause();
        AudioListener.pause = false;
    }
}
