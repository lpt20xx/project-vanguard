using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{
    public string panelId;

    private PanelManager panelManager;

    public PanelShowBehavior behavior;

    //public static bool isShowing = false;

    private void Start()
    {
        this.GetPanelManager();
    }

    

    private void GetPanelManager()
    {   
        panelManager = PanelManager.Instance;

    }
    public void DoShowPanel()
    {

        panelManager.ShowPanel(panelId, behavior);
        /*if (!isShowing)
        {
            
            //isShowing = true;
        }*/
        
        //Debug.Log("Show the Panel: " +  panelId);
    }
}
