using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [SerializeField] private AudioSource _puzzleMusic;
    [SerializeField] private GameObject _puzzle;
    [SerializeField] private GameObject _scenario;  // Gameobject containing all scenario obj and its colliders


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this);
    }

    // Deactivate/activate all scenario colliders inside the '_scenario' object
    private void DeactivateAllDiscuptiveColliders(bool activation)
    {
        foreach (Collider2D col in _scenario.GetComponentsInChildren<Collider2D>())
            col.enabled = activation;
    }

    // Pass to the next scene (called when a puzzle is solved)
    public void PuzzleSolved()
    {
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (_puzzleMusic != null)
            {
                _puzzleMusic.ignoreListenerPause = true;
                _puzzleMusic.Play();
            }

            AudioListener.pause = true;
            PlayerMovement.Instance.isPaused = true;
            DeactivateAllDiscuptiveColliders(false);
            _puzzle.SetActive(true);

        }
    }
}
