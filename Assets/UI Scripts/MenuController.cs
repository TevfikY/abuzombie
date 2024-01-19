using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Game Scene")]
    public string newGameLevel;

    public Button musicButton;
    public Button sfxButton;

    private void Start()
    {
        musicButton.onClick.AddListener(ToggleMusic);
        sfxButton.onClick.AddListener(ToggleSFX);
    }

    private void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic(!AudioManager.Instance.musicSource.enabled);
    }

    private void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX(!AudioManager.Instance.sfxSource.enabled);
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
        SceneManager.LoadScene(newGameLevel);
    }
}
