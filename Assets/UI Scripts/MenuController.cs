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
    public Button pauseButton;  // Button for pausing
    public Button resumeButton; // Button for resuming

    private bool isPaused = false;

    private void Start()
    {
        musicButton.onClick.AddListener(ToggleMusic);
        sfxButton.onClick.AddListener(ToggleSFX);
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
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        isPaused = true;
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
            // If no confirmation prompt, load the new game scene directly
            LoadNewGameScene();
        }
    }

    public void NewGameDialogNo()
    {
        // Close confirmation prompt
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
        // Load the new game scene
        SceneManager.LoadScene(loadNewScene);
    }
}
