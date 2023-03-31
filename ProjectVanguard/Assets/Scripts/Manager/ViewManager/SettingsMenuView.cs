using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuView : View
{
    [Header("Buttons")]
    [SerializeField] private Button saveButton;
    [SerializeField] private Button backButton;

    
    public override void Initialize()
    {
        //save settings
        //saveButton.onClick.AddListener(() => ViewManager.ShowLast());
        //back to main menu
        //backButton.onClick.AddListener(() => ViewManager.ShowLast());
    }


    public void SaveSettings()
    {
        ViewManager.ShowLast();
    }

    public void BackToMenu()
    {
        ViewManager.ShowLast();
    }

    
}
    

