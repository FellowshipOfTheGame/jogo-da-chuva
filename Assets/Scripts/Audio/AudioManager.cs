using UnityEngine;

// How to use:
// Inside some script of an object you desire to play a sound listed on the AudioManager
// you can simply type: 
// ***************** 'AudioManager.Instance.Play("Name of the sound");' ******************
// passing the name of the sound to play it.

public class AudioManager : Audio
{ 
    // 'instance' references to itself
    public static AudioManager Instance;

    // Awake is called before the Start method
    protected override void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this);

        base.Awake();        
    }
}