using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _gameoverpopup;
    void Start()
    {
        FindObjectOfType<GameEventSystem>().onGameOver.AddListener(ShowGameOverPopUp);
    }
    public void Play()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayAgain()
    {
       Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ShowGameOverPopUp()
    {
        _gameoverpopup.SetActive(true);
        Debug.Log("Game Over!");
    }
    public void PouseButton(int val)
    {
        Time.timeScale = val;
    }
}
