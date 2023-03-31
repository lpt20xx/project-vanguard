using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanelButton : MonoBehaviour
{
    public string panelId;

    private PanelManager panelManager;

    private void Start()
    {
        this.GetPanelManager();
    }

    private void GetPanelManager()
    {
        panelManager = PanelManager.Instance;

    }
    public void DoHidePanel()
    {
        panelManager.HideLastPanel();
        //ShowPanelButton.isShowing = false;
        //Debug.Log("Hide last Panel ");
    }
}
