using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance ;
    [SerializeField] EnemyBulletSpawner enemyBulletSpawner;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] BulletSpawner bulletSpawner;
    [SerializeField] MeteorSpawner meteorSpawner;
    [SerializeField] PlayerController playerController;
    public Action onGameFinished;
    [HideInInspector]public bool IsGameOver;

    public EnemyBulletSpawner EnemyBulletSpawner => enemyBulletSpawner; //getter
    public EnemySpawner EnemySpawner => enemySpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;
    public MeteorSpawner MeteorSpawner => meteorSpawner;
    public PlayerController PlayerController => playerController;
    private void Awake()
    {
         Instance = this;
    }

    private void Start()
    {
        onGameFinished += OnGameFinished;
        IsGameOver = false;
    }
    private void OnDestroy()
    {
        onGameFinished -= OnGameFinished;
    }
    private void OnGameFinished()
    {
        IsGameOver = true;
        ScoreManager.Instance.GameFinised();
        MenuUIManager.Instance.GameFinishedUI();


    }
}
