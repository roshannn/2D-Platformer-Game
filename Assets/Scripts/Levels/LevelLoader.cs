using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    private Text text;
    LevelStatus levelStatus;
    public string LevelName;
    
    private void Awake()
    {
        levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        button.onClick.AddListener(onClick);
    }


    private void onClick()
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
