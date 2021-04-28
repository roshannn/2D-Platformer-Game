using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyLoader : MonoBehaviour
{
    public Button buttonPlay;
    public Button buttonBackFromLevels;
    public Button buttonBackFromSettings; 
    public Button buttonReset;
    public Button buttonSettings;
    public Button buttonMute;
    public GameObject LevelSelection;
    public GameObject SettingsSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonBackFromLevels.onClick.AddListener(GoBackFromLevelSelection);
        buttonBackFromSettings.onClick.AddListener(GoBackFromSettingsSelection);
        buttonReset.onClick.AddListener(ClearPrefs);
        buttonSettings.onClick.AddListener(Settings);
    }
    
    private void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.StartGame);
        LevelSelection.SetActive(true);
    }

    private void Settings()
    {
        SoundManager.Instance.Play(Sounds.StartGame);
        SettingsSelection.SetActive(true);
    }

    
    private void GoBackFromSettingsSelection()
    {
        SoundManager.Instance.Play(Sounds.Back);
        SettingsSelection.SetActive(false);
    }
    private void GoBackFromLevelSelection()
    {
        SoundManager.Instance.Play(Sounds.Back);
        LevelSelection.SetActive(false);
    }

    private void ClearPrefs()
    {
        SoundManager.Instance.Play(Sounds.Reset);
        PlayerPrefs.DeleteAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
