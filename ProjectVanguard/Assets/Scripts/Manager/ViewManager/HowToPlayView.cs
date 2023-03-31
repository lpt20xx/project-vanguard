using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayView : View
{
    [Header("Buttons")]
    [SerializeField] private Button backButton;
    public override void Initialize()
    {

        //back to main menu
        //backButton.onClick.AddListener(() => ViewManager.ShowLast());
    }

    public void BackToMenu()
    {
        ViewManager.ShowLast();
    }
}
