using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    public GameObject fadeOut;

    // Start is called before the first frame update
    private void Start()
    {
        this.Victory();
    }

    private void Victory()
    {
        if (AudioManager.Instance == null)
        {
            return;
        }
        if (Scoring.isWin)
        {
            fadeOut.SetActive(true);
            AudioManager.Instance.PlaySFX("LevelComplete");
        }
        StartCoroutine(BackToMenuDelay());
    }

    IEnumerator BackToMenuDelay()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        AudioManager.Instance.PlayMusic("MainMenuBGM");

        Cursor.lockState = CursorLockMode.None;
    }
}
