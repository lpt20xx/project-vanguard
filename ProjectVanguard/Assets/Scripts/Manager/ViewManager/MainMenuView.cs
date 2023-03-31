using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : View
{
    [Header("Buttons")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button htpButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button quitButton;

    public override void Initialize()
    {
        startButton.interactable = false;
        htpButton.interactable = false;
        settingsButton.interactable = false;
        creditButton.interactable = false;
        quitButton.interactable = false;

        /*
        startButton.onClick.AddListener(() => SceneManager.LoadScene("Level1"));
        
        htpButton.onClick.AddListener(() => ViewManager.Show<HowToPlayView>());
        
        settingsButton.onClick.AddListener(() => ViewManager.Show<SettingsMenuView>());
        
        creditButton.onClick.AddListener(() => ViewManager.Show<CreditView>());
        */
    }

    

    private void Start()
    {
        StartCoroutine(EnableButton());
    }

    IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(3);
        startButton.interactable = true;
        htpButton.interactable = true;
        settingsButton.interactable = true;
        creditButton.interactable = true;
        quitButton.interactable = true;
    }


    //start game
    public void StartGame()
    {
        //load scene in build settings (file -> buid settings)
        //SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

        PlayerHealth.isDead = false;
    }
    //how to play
    public void HowToPlay()
    {
        ViewManager.Show<HowToPlayView>();
    }
    //settings
    public void SettingsMenu()
    {
        ViewManager.Show<SettingsMenuView>();
    }
    //credit
    public void Credit()
    {
        ViewManager.Show<CreditView>();
    }
}
