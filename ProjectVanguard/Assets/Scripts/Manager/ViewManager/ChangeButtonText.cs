
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeButtonText : MonoBehaviour
{

    [SerializeField] private TMP_Text muteSoundText;


    protected string muteText = "MUTE";
    protected string unmuteText = "UNMUTE";

    public void ChangeText()
    {
        if (muteSoundText.text == muteText)
        {
            muteSoundText.text = unmuteText;
        }
        else
        {
            muteSoundText.text = muteText;
        }
    }
}
