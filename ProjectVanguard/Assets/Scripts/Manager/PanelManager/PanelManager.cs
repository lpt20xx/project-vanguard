using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelManager : PanelSingleton<PanelManager>
{
    public List<PanelModel> panels;
    private List<PanelInstanceModel> listInstances = new List<PanelInstanceModel>();


       
    

    public void ShowPanel(string panelId, PanelShowBehavior behavior = PanelShowBehavior.KEEP_PREVIOUS)
    {
        PanelModel panelModel = panels.FirstOrDefault(panel => panel.panelId == panelId);
        //GameObject panelInstance = objectPool.GetObjectFromPool(panelId);

        if (panelModel != null)
        //if(panelInstance != null)
        {
            if (behavior == PanelShowBehavior.HIDE_PREVIOUS && GetAmountPanelIsInQueue() > 0)
            {
                //get the last panel showing
                var lastPanel = GetLastPanel();
                if(lastPanel != null)
                {
                    lastPanel.panelInstance.SetActive(false);
                }
            }

            var newInstancePanel = Instantiate(panelModel.panelPrefab, transform);
            //add new panel to the queue
            listInstances.Add(new PanelInstanceModel
            {
                panelIdInstance = panelId,
                panelInstance = newInstancePanel
                //panelInstance = panelInstance
            }); 
        }
        else
        {
            Debug.LogWarning($"Trying to use panelId = {panelId}, but it is not found in Panels");
        }
    }

    public void HideLastPanel()
    {
        if (AnyPanelShowing())
        {
            //get the last panel showing
            var lastPanel = GetLastPanel();
            listInstances.Remove(lastPanel);
            //destroy that instance
            Destroy(lastPanel.panelInstance);
            //objectPool.PoolObject(lastPanel.panelInstance);

            if(GetAmountPanelIsInQueue() > 0)
            {
                lastPanel = GetLastPanel();
                if(lastPanel != null && !lastPanel.panelInstance.activeInHierarchy)
                {
                    lastPanel.panelInstance.SetActive(true);
                }
            }
        }
    }

    PanelInstanceModel GetLastPanel()
    {
        return listInstances[listInstances.Count - 1];
    }

    //return if any panel is showing
    public bool AnyPanelShowing()
    {
        return GetAmountPanelIsInQueue() > 0;
    }

    //return how many panels in queue
    public int GetAmountPanelIsInQueue()
    {
        return listInstances.Count;
    }
}
