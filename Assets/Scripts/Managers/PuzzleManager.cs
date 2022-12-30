using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnTriggerEnter2D(Collider2D col)
    {
        Time.timeScale = 0;
        DeactivateAllDiscuptiveColliders(false);
        _puzzle.SetActive(true);
    }
}
