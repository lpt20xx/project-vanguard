using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject fadeOut;

    public GameObject scoreText;
    public GameObject crosshair;
    public GameObject playerHealth;
    // Start is called before the first frame update
    private void Start()
    {
        this.EndLevel();
    }

    private void EndLevel()
    {
        StartCoroutine(EndLevelDelay());

        if (AudioManager.Instance == null)
        {
            return;
        }

        AudioManager.Instance.musicSource.Stop();
    }
    IEnumerator EndLevelDelay()
    {
        
        yield return new WaitForSeconds(1f);

        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlaySFX("GameOver");

        scoreText.SetActive(false);
        crosshair.SetActive(false);
        playerHealth.SetActive(false);

        gameOverText.SetActive(true);
        fadeOut.SetActive(true);

        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        AudioManager.Instance.PlayMusic("MainMenuBGM");

        Cursor.lockState = CursorLockMode.None;
    }
}
