using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Button startBtn;
    public Button achieveBtn;

    public Button backBtn;
    public GameObject menuPanel;
    public GameObject achievementPanel;
    public bool isOnMenu;
    public PlayerData playerData;


    private void Start()
    {
        GetPlayerData();
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        startBtn.onClick.AddListener(StartGame);
        achieveBtn.onClick.AddListener(OpenAchievementPanel);
        backBtn.onClick.AddListener(() =>
        {
            CloseAchievementPanel();
        });
        isOnMenu = true;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
        menuPanel.SetActive(false);
    }

    public void OpenAchievementPanel()
    {
        achievementPanel.SetActive(true);
    }

    private void CloseAchievementPanel()
    {
        achievementPanel.SetActive(false);
        if (isOnMenu)
        {
            menuPanel.SetActive(true);
        }
        else
        {
            MainManager.instance.gameOverPanel.SetActive(true);
        }
    }
    public void GetPlayerData()
    {
        if (DataManager.Instance.HasData<PlayerData>())
        {
            playerData = DataManager.Instance.ReadData<PlayerData>();
            Debug.Log("Loaded User Data.");
        }
        else
        {
            playerData = new PlayerData();
            DataManager.Instance.SaveData(playerData);
            Debug.Log("Creating New User Data");
        }
    }
}
