using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    // References to UI panels
    public GameObject gameMenuContent;
    public GameObject continueMenuUI;
    public GameObject restartMenuUI;
    public GameObject settingsMenuUI;
    public GameObject exitMenuUI;

    // The buttons
    public Button buttonContinue;
    public Button buttonRestart;
    public Button buttonSettings;
    public Button buttonExit;

    // Keep track of the game state (paused or not)
    private bool isPaused = false;

    void Start()
    {
        // Initially, hide all menus
        HideAllMenu(false);

        // Set button listeners for each action
        buttonContinue.onClick.AddListener(Continue);
        buttonRestart.onClick.AddListener(Restart);
        buttonSettings.onClick.AddListener(OpenSettings);
        buttonExit.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        // Optional: Toggle Pause with the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            if (isPaused)
                Continue();
            else
                Paused();
        }
    }

    // Function to show the pause menu
    public void Paused()
    {
        isPaused = true;
        HideAllMenu(true);
        //ShowMenu(backGround,continueMenuUI, restartMenuUI, settingsMenuUI, exitMenuUI);
        Time.timeScale = 0f;  // Pause the game
        Debug.Log("Game Paused");
    }

    // Function to resume the game
    public void Continue()
    {
        isPaused = false;
        HideAllMenu(false);
        Time.timeScale = 1f;  // Resume the game
        Debug.Log("Game Resumed");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Function to open the settings menu
    public void OpenSettings()
    {
        HideAllMenu(false);
        //settingsMenuUI.SetActive(true);
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
        gameMenuContent.SetActive(state);
        Debug.Log("call hideAllMenu" + state);
        if (state == false)
        { EventSystem.current.SetSelectedGameObject(null); }
        
    }

    //private void ShowMenu(params GameObject[] menus)
    //{
    //    foreach (var menu in menus)
    //    {
    //        menu.SetActive(true);
    //    }
    //}
}
