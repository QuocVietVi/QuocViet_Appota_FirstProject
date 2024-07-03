using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public Button replayBtn;
    public Button menuBtn;
    public Button achievementBtn;
    public GameObject gameOverPanel;
    public bool gameOver;
    public int score;
    public PlayerData playerData;
    public Text scoreTxt;

    public List<AnimalData> animalData = new List<AnimalData>();
    float time;

    private void Awake()
    {
        animalData = DataManager.Instance.ReadListData<AnimalData>();
        playerData = UIManager.Instance.playerData;
    }
    private void Start()
    {
        instance = this;
        gameOver = false;
        replayBtn.onClick.AddListener(Replay);
        menuBtn.onClick.AddListener(BackToMenu);
        achievementBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenAchievementPanel();
            gameOverPanel.SetActive(false);
            scoreTxt.gameObject.SetActive(false);

        });

    }

    private void Update()
    {
        if (!gameOver)
        {
            time += Time.deltaTime;

        }
        
    }

    private void Replay()
    {
        SceneManager.LoadScene(1);
    }

    private void BackToMenu()
    {
        UIManager.Instance.menuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        scoreTxt.gameObject.SetActive(false);
        UIManager.Instance.isOnMenu = true;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOver = true;
        UIManager.Instance.isOnMenu = false;
        playerData.time += time;
        var data = DataManager.Instance;
        if (score > playerData.highScore)
        {
            playerData.highScore = score;
        }
        data.SaveData(playerData);
    }

    
}
