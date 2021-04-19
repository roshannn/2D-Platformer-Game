using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public GameObject LevelCompletedTick;
    LevelStatus levelStatus;
    public string LevelName;
    private TextMeshProUGUI textComponent;
    private void Awake()
    {
        textComponent = GetComponentInChildren<TextMeshProUGUI>();
        levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        
    }
    private void Start()
    {
        textComponent = button.GetComponentInChildren<TextMeshProUGUI>();
        CheckLevelStatus();
        if (levelStatus == LevelStatus.Completed)
        {
            Debug.Log("tick active");
            LevelCompletedTick.SetActive(true);
        }
    }

    public void CheckLevelStatus()
    {
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                textComponent.text = "Locked";
                break;

            case LevelStatus.Unlocked:
                textComponent.text = LevelName;
                break;

            case LevelStatus.Completed:
                break;
        }
    }

    private void OnClick()
    {
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
   
}
