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
    public GameObject restartMenuUI;
    public GameObject settingsMenuUI;
    public GameObject exitMenuUI;

    // The buttons
    public Button buttonContinue;
    public Button buttonRestart;
    public Button buttonSettings;
    public Button buttonExit;

    // Keep track of the game state (paused or not)

    void Start()
    {
        Time.timeScale = 1f;  // Resume the game

        // Initially, hide all menus
        HideAllMenu(true);

        // Set button listeners for each action
        buttonContinue.onClick.AddListener(Continue);
        buttonRestart.onClick.AddListener(Restart);
        buttonSettings.onClick.AddListener(OpenSettings);
        buttonExit.onClick.AddListener(ExitGame);

    }


    // Function to resume the game
    public void Continue()
    {
        HideAllMenu(false);
        Time.timeScale = 1f;  // Resume the game
    }
    public void Restart()
    {
        string sceneName = "AirCarftShooter";

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Restarting Scene: " + sceneName);
        }
        else
        {
            Debug.LogError("Scene '" + sceneName + "' is not added to the Build Settings.");
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
