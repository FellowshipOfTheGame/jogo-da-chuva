using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string gameLevel;
    [SerializeField] private GameObject menuPanel, optionsPanel;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void OpenOptions()
    {
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
