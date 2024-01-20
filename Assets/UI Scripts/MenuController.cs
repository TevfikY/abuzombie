using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Game Scene")]
    public string loadNewScene;

    public Button musicButton;
    public Button sfxButton;
    public Button pauseButton; 
    public Button resumeButton; 

    private bool isPaused = false;

    private void Start()
    {
        musicButton.onClick.AddListener(ToggleMusic);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    private void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    private void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX(!AudioManager.Instance.sfxSource.enabled);
    }

    private void PauseGame()
    {
        Debug.Log("pressed pause");
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        isPaused = true;
          Debug.Log("Time.timeScale: " + Time.timeScale);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game by setting time scale to 1
        isPaused = false;
    }

    public void NewGameDialogYes()
    {
        // Show confirmation prompt
        if (confirmationPrompt != null)
        {
            confirmationPrompt.SetActive(true);
        }
        else
        {   
            LoadNewGameScene();
        }
    }

    public void NewGameDialogNo()
    {
   
        if (confirmationPrompt != null)
        {
            confirmationPrompt.SetActive(false);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    private void LoadNewGameScene()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(loadNewScene);
    }
}
