using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public GameObject levelCompletedTick;
    LevelStatus levelStatus;
    public string LevelName;
    [SerializeField] TextMeshProUGUI textComponent;
    private void Awake()
    {
        levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        
    }
    private void Start()
    {
        CheckLevelStatus();
        if (levelStatus == LevelStatus.Completed)
        {
            Debug.Log("tick active");
            levelCompletedTick.SetActive(true);
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
