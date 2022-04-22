using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PauseCanvas;
    bool pause;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused();
        }
        
    }

    public void resume()
    {
        pause = false;
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void paused()
    {
        if(!pause)
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
            pause = true;
            
        }
        else
        {
            
            PauseCanvas.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
            pause = false;
        }

    }
}
