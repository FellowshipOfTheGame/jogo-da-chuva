using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [SerializeField] private GameObject _puzzle;
    [SerializeField] private GameObject _scenario;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this);
    }

    private void DeactivateAllDiscuptiveColliders(bool activation)
    {
        foreach (Collider2D col in _scenario.GetComponentsInChildren<Collider2D>())
            col.enabled = activation;
    }

    public void PuzzleSolved()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Time.timeScale = 0;
        DeactivateAllDiscuptiveColliders(false);
        _puzzle.SetActive(true);
    }
}
