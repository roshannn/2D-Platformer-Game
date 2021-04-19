using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyLoader : MonoBehaviour
{
    public Button buttonPlay;
    public Button buttonBack;
    public Button buttonReset;
    public GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonBack.onClick.AddListener(GoBack);
        buttonReset.onClick.AddListener(ClearPrefs);
    }
   
    private void PlayGame()
    {
        LevelSelection.SetActive(true);
        
    }
    private void GoBack()
    {
        LevelSelection.SetActive(false);
    }

    private void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
