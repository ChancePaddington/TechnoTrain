using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    //Audio
    [SerializeField] AudioClip menuSound;
    [SerializeField] AudioClip buttonSound;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        SoundManager.instance.PlaySoundFXClip(menuSound, transform, volume);
    }
    public void Resume()
    {
        SoundManager.instance.PlaySoundFXClip(buttonSound, transform, volume);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    public void LoadMenu()
    {
        SoundManager.instance.PlaySoundFXClip(buttonSound, transform, volume);
        Time.timeScale = 1f;
        SceneController.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
