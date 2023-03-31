using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private static ViewManager instance;

    [SerializeField] private View startingView;
    [SerializeField] private View[] views;

    private View currentView;

    private readonly Stack<View> history = new Stack<View>();

    public static T GetView<T>() where T : View
    {
        for(int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T tView)
            {
                return tView;
            }
        }

        return null;
    }

    public static void Show<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T)
            {
                if(instance.currentView == null)
                {
                    return;
                }

                if (remember)
                {
                    instance.history.Push(instance.currentView);
                }

                instance.currentView.Hide();

                instance.views[i].Show();

                instance.currentView = instance.views[i];
            }
        }

        
    }

    public static void Show(View view, bool remember = true)
    {
        if(instance.currentView != null)
        {
            if (remember)
            {
                instance.history.Push(instance.currentView);
            }

            instance.currentView.Hide();
        }

        view.Show();

        instance.currentView = view;
    }

    //show the view before
    public static void ShowLast()
    {
        if(instance.history.Count != 0)
        {
            Show(instance.history.Pop(), false);
        }
    }

    private void Awake()
    {
        this.CheckInstance();
    }

    private void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        this.ShowStartingView();
    }

    private void ShowStartingView()
    {
        for (int i = 0; i < views.Length; i++)
        {
            views[i].Initialize();

            views[i].Hide();
        }

        if (startingView != null)
        {
            Show(startingView, true);
        }
    }



}
