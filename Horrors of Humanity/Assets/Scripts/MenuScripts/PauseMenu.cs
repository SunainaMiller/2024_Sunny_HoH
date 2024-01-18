using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public static bool GameIsPaused = true; //check from other scripts (and not this specific script) if the game is paused
    
    Animator menuUIAnimator;

    float timeDelay = 2f;
    static bool gameReloaded = false;
    public GameObject cursor;
    CursorBehaviour cursorBehaviour;
    // public GameObject // tutorialPanel;
    // public tutorialScript tutorialScript;
    // public GameObject // gameUI;
    // public GameObject title;

    #region Main Menu UI
    public GameObject mainMenu;
    public GameObject mainMenuCredits;
    public GameObject mainMenuButtonsPanel;
    public GameObject mainMenuLevelSelectionPanel;
    public GameObject mainMenuOptions;
    bool mainMenuActive;
    #endregion

    #region Pause Menu UI
    public GameObject pauseMenuUI;
    public GameObject pauseMenuButtonsPanel;
    public GameObject optionsPanel;
    #endregion

    public GameObject bedConfirmationPanel;

    float sceneNumber;

    #region General
    void Start()
    {
        // Game is paused, // title & main menu actvie, pause menu hidden, game UI hidden
        menuUIAnimator = GetComponent<Animator>();
        cursorBehaviour = cursor.GetComponent<CursorBehaviour>();
        // if current scene is not the main menu, unpause the game
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        gameObject.transform.localScale = new Vector3(1, 1, 1); // setting (button) scale to 1
        if (sceneNumber != 1)
        {
            GameIsPaused = false;
            Debug.Log("Unpausing game at start, because it is not the main menu");
        }
        else if (gameReloaded == false) // if the game hasn't been reloaded before, make main menu appear
        {
            MainMenuAppear();
            pauseMenuUI.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            if(sceneNumber == 1 && !mainMenuButtonsPanel.activeInHierarchy) // if escape is pressed in main menu scene & the main menu buttons are not active, activate them
            {
                Start();
            }
        }
    }
    public void StartScene() //starting from DAY 1
    {
        Time.timeScale = 1f;
        gameReloaded = true;
        SceneManager.LoadScene(2);
        MainMenuDisappear();
        PauseMenuDisappear();
        Debug.Log("Starting game from beginning");
    }
    public void RestartLevel() //restart current level
    {
        gameReloaded = true;
        PauseMenuDisappear();
        Debug.Log("Restarting level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // load current scene
    }
    public void Resume()
    {
        #region Pause Menu
        // if main menu is not open as resume has been requested (so pause menu is active), close pause menu
        if (mainMenuActive == false)
        {
            Debug.Log("Game resumed; pause script");
            bedConfirmationPanel.SetActive(false);
            PauseMenuDisappear();
        }
        #endregion
        #region Main Menu
        else if (mainMenuActive == true) // if resume has been requested from main menu, get rid of main menu
        {
            Debug.Log($"Main menu is {mainMenu == true}");
        }
        #endregion
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }
    #endregion

    #region Main Menu

    void MainMenuAppear()
    {
        //Time.timeScale = 0f;
        //GameIsPaused = true;
        Debug.Log("Game paused from main menu");
        CursorBehaviour.instance.isPencilTime = true;
        #region Main Menu/// title active
        mainMenu.SetActive(true);
        mainMenuButtonsPanel.SetActive(true);
        mainMenuActive = true;
        mainMenuCredits.SetActive(false);
        mainMenuLevelSelectionPanel.SetActive(false);
        mainMenuOptions.SetActive(false);
        #endregion
    }
    void MainMenuDisappear() // called in Resume()
    {
        Debug.Log("Deactivating main menu");
        CursorBehaviour.instance.isPencilTime = false;
        #region Deactivating Main Menu game objects
        mainMenu.SetActive(false);
        mainMenuCredits.SetActive(false);
        mainMenuActive = false;
        #endregion

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    #region Main Menu Credits
    public void MainMenuCredits() // play credits appearing & // title & buttons disappearing anim
    {
        mainMenuCredits.SetActive(true);
        MainMenuButtonsDisappear();

        mainMenuOptions.SetActive(false);
        mainMenuButtonsPanel.SetActive(false);
        mainMenuLevelSelectionPanel.SetActive(false);
        Debug.Log("Activating main menu credits");
    }
    void MainMenuButtonsDisappear() // called in MainMenuCredits()
    {
        mainMenuButtonsPanel.SetActive(false);
        Debug.Log("Main menu panel should disappear for credits");
    }
    #endregion

    #region Options
    public void MainMenuOptionsAppear() // play credits appearing & // title & buttons disappearing anim
    {
        mainMenuOptions.SetActive(true);
        mainMenuButtonsPanel.SetActive(false);

        mainMenuCredits.SetActive(false);
        mainMenuLevelSelectionPanel.SetActive(false);
    }
    public void MainMenuOptionsDisappear()
    {
        optionsPanel.SetActive(false);
        mainMenuButtonsPanel.SetActive(true);
        Debug.Log("Main menu panel should disappear for credits");
    }
    #endregion
    #region Main Menu Level Selection
    public void LevelSelectionPanelAppear()
    {
        mainMenuLevelSelectionPanel.SetActive(true);
        MainMenuButtonsDisappear();

        mainMenuOptions.SetActive(false);
        mainMenuCredits.SetActive(false);
    }

    public void Day1Load()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Loading Day 1");
    }
    public void Day2Load()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Loading Day 2");
    }
    public void Day3Load()
    {
        SceneManager.LoadScene(4);
        Debug.Log("Loading Day 3");
    }
    public void OppositeApartmentLoad()
    {
        SceneManager.LoadScene(5);
        Debug.Log("Loading Day 3, opposite apartment");
    }
    public void CreditsScrollLoad()
    {
        SceneManager.LoadScene(7);
        Debug.Log("Loading credits");
    }
    public void ResumeToMainMenuFromMainMenu()
    {
        Start();
    }
    #endregion
    #endregion

    #region Pause Menu
    void Pause()
    {
        PauseTime();
        pauseMenuUI.SetActive(true);
        pauseMenuButtonsPanel.SetActive(true);
        Debug.Log("Game paused from Pause()");
        CursorBehaviour.instance.isPencilTime = true;
    }
    public void PauseTime()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void PauseMenuDisappear() // called in Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        CursorBehaviour.instance.isPencilTime = false;
        // gameUI.SetActive(true);
        Debug.Log($"Resuming game from Pause()");
    }
    public void GoToMainMenu()
    {
        Debug.Log("Returning to main menu");
        gameReloaded = false;
        SceneManager.LoadScene(1);
        Start();
    }
    #region Options
    public void PauseMenuOptionsAppear() // play credits appearing & // title & buttons disappearing anim
    {
        optionsPanel.SetActive(true);
        pauseMenuButtonsPanel.SetActive(false);
        Debug.Log("Activating main menu credits");
    }
    public void PauseMenuOptionsDisappear()
    {
        optionsPanel.SetActive(false);
        pauseMenuButtonsPanel.SetActive(true);
        Debug.Log("Main menu panel should disappear for credits");
    }
    #endregion
    /*public void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); //
        Debug.Log($"Cursor entered {gameObject}, changing scale");
    }
    public void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1); // setting (button) scale to 1
        Debug.Log($"Cursor exited {gameObject}, changing scale");
    }*/
    #endregion
}
