using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [SerializeField] private GameObject _puzzle;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Time.timeScale = 0;
        _puzzle.SetActive(true);
    }
}
