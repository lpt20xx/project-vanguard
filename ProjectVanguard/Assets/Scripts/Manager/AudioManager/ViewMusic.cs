using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMusic : MonoBehaviour
{


    public void GameMusic()
    {
        //play music
        //AudioManager.Instance.musicSource.Stop();
        int rdMusic = Random.Range(1, AudioManager.Instance.GetGameBGMCount() + 1);
        Debug.Log("RandomMusic: " + rdMusic);


        AudioManager.Instance.PlayMusic("GameBGM" + rdMusic);
        
        /*if (rdMusic == 1)
        {
            AudioManager.Instance.PlayMusic("GameBGM1");
        }*/
        
    }
    public void CreditMusic()
    {
        //play BGM
        AudioManager.Instance.PlayMusic("Credit");
    }
    public void CreditBack()
    {
        AudioManager.Instance.PlayMusic("MainMenuBGM");
    }
}
