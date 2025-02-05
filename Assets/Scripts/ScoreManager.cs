using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public GameObject gameScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public TextMeshProUGUI gameOverText;

    public int score = 0;
    public int defaultScore;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        score = GameConstact.scoreDefault;
        if (GameMenuManager.Instance.isContinue)
        {
            score = PlayerData.GetCurrentPointPlayer();
        }

    }
    private void Update()
    {
        if (!GameController.Instance.IsGameOver)
        {
            scoreText.text = $"Score:{score} \n Level:{EnemySpawner.Instance.wave + 1}";
        }
       
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    public void GameFinised()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        gameOverText.text = $"<color=green>CONGRATULATION!! \nYou are killed the Boss!!";
    }
}
