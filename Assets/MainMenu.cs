using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  

    public GameObject mainMenuContent;
    public GameObject continueMenuUI;
    public GameObject newGameMenuUI;
    public GameObject mainMenuUI;
    public GameObject settingsMenuUI;
    public GameObject exitMenuUI;

    // The buttons
    public Button buttonContinue;
    public Button buttonNewGame;
    public Button buttonMainMenu;
    public Button buttonSettings;
    public Button buttonExit;

    private bool isPaused = true;
    public bool inMenu = true;


 
    void Start()
    {
        Time.timeScale = 1f;  // Resume the game

        // Initially, hide all menus
        HideAllMenu(inMenu);

        // Set button listeners for each action
        buttonContinue.onClick.AddListener(Continue);
        buttonNewGame.onClick.AddListener(NewGame);
        buttonMainMenu.onClick.AddListener(Mainmenu);
        buttonSettings.onClick.AddListener(OpenSettings);
        buttonExit.onClick.AddListener(ExitGame);

    }
    void Update()
    {
    //Optional: Toggle Pause with the Escape key
     
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                Debug.Log("Escape key pressed");
                if (isPaused)
                    Continue();
                else
                    Paused();


            }
      
     
    }
    public void Paused()
    {
        HideAllMenu(true);
        Time.timeScale = 0f;  // Pause the game
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerData.SavePlayerLevel(EnemySpawner.instance.wave);
        PlayerData.SavePlayerPoint(ScoreManager.Instance.score);

    }

    // Function to resume the game
    public void Continue()
    {
        if (!inMenu)
        {
            HideAllMenu(false);
            Time.timeScale = 1f;  // Resume the game
            return;
        }
        LoadScene();
        GameMenuManager.Instance.isContinue = true;
        
    }
    public void NewGame()
    {
        LoadScene();
        GameMenuManager.Instance.isContinue = false;
        PlayerData.SavePlayerLevel(GameConstact.levelDefault);
        PlayerData.SavePlayerPoint(GameConstact.scoreDefault);


    }
    public void LoadScene()
    {
        string sceneName = "AirCarftShooter";


        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Restarting Scene: " + sceneName);

        }
    }



    // Function to open the settings menu
    public void OpenSettings()
    {
        HideAllMenu(false);
    }

    // Function to open the exit menu
    public void ExitGame()
    {
        HideAllMenu(false);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Stop play mode in the editor
#else
        Application.Quit();  // Quit the game in a build
#endif
    }

    private void HideAllMenu(bool state)
    {
        mainMenuContent.SetActive(state);
        if (state == false)
        { EventSystem.current.SetSelectedGameObject(null); }

    }


}
