// AudioManager.cs
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    private bool isMusicPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, update references to audio sources
            Instance.musicSource = musicSource;
            Instance.sfxSource = sfxSource;

            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.Play();
        isMusicPaused = false;
    }

    public void ToggleMusic()
    {
        if (musicSource.isPlaying && !isMusicPaused)
        {
            musicSource.Pause();
            isMusicPaused = true;
        }
        else if (isMusicPaused)
        {
            musicSource.UnPause();
            isMusicPaused = false;
        }
    }

    public void ToggleSFX(bool isOn)
    {
        sfxSource.enabled = isOn;
    }
}
