using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    [SerializeField] private AnimationClip _exitAnimation;

    void Start()
    {
        if (MusicLoopPlay.Instance)
            Destroy(MusicLoopPlay.Instance.gameObject);
        StartCoroutine(PassNextScene(_exitAnimation.length + 4.0f));
    }

    IEnumerator PassNextScene(float waitDuration)
    {
        yield return new WaitForSeconds(waitDuration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
