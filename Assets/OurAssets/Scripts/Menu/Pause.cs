using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject LogMenu;
   
    public Selectors selector;
    public SortingGroup sort;

    public int sorter;

    public bool pause;
    public bool logmenu;
    
    // Start is called before the first frame update
    void Start()
    {
        sort = GameManager.Instance.Player.GetComponent<SortingGroup>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(logmenu || pause)
        {
            sort.sortingOrder = 4;
        }
        else
        {
            sort.sortingOrder = 0;
        }

        paused();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                pause = true;
                PauseCanvas.SetActive(true);
                logmenu = false;
            }
            else
            {
                if (!logmenu && pause)
                {
                    pause = false;
                }
                else if(logmenu && !selector.isReading && pause)
                {
                    logmenu = false;
                    LogMenu.SetActive(false);
                    PauseCanvas.SetActive(true);
                }
                else
                {
                    logmenu = false;
                }
            }


        }
        
        
    }

    public void resume()
    {
        pause = false;
      
    }

    public void quit()
    {
        Application.Quit();
    }

    public void logs()
    {
        LogMenu.SetActive(true);
        PauseCanvas.SetActive(false);
        logmenu = true;
        selector.check = true;
        
    }

    public void paused()
    {
        if (pause)
        {
           
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
        else
        {
            PauseCanvas.SetActive(false);
            LogMenu.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }
}
