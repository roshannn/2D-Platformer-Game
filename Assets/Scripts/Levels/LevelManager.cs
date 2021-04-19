using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string Level1;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if(GetLevelStatus(Level1) == LevelStatus.Locked)
        {
            SetLevelStatus(Level1, LevelStatus.Unlocked);
        }
    }

    public void MarkLevelComplete()
    {
        Scene scene = SceneManager.GetActiveScene();
        LevelManager.Instance.SetLevelStatus(scene.name, LevelStatus.Completed);
        int nextSceneIndex = scene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneAt(nextSceneIndex);
        LevelManager.Instance.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);
    }

    public LevelStatus GetLevelStatus(string level)
    {

        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
