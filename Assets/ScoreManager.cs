using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText;

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
        scoreText.text =  $"{score}";
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
