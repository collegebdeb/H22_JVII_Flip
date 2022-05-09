using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectors : MonoBehaviour
{
    //public GameObject[] logs = new GameObject[4];
    
    public ReadTextFile rd;
    public List<GameObject> logs = new List<GameObject>();
    public Pause pausemenu;
    

    public Text Logtext;
    public int selected = 0;
    public bool isReading;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("LogText");
        Logtext = GameObject.Find("LogDisplay").GetComponent<Text>();
        rd = gameObject.GetComponent<ReadTextFile>();

        canvas.SetActive(false);


        for(int i = 0; i < 5; i++)
        {
            logs[i] = GameObject.Find("log" + i);
            
            
            if (i >0)
            {
                deactivateStart(i);
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if(!isReading)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selected < 4)
                {
                    deactivate(selected);
                    selected++;
                    activate(selected);
                }
                else
                {
                    print("cant");
                }

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selected > 0)
                {
                    deactivate(selected);
                    selected--;
                    activate(selected);
                }
                else
                {
                    print("cant");
                }
            }
        }
     
        if(Input.GetKeyDown(KeyCode.Return) && !isReading)
        {
            print("fuckeverything");
            isReading = true;
            canvas.SetActive(true);
            Logtext.text = rd.names[selected];
            pausemenu.logmenu = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isReading = false;
            canvas.SetActive(false);
        }
        
    }
    void activate(int i)
    {
        if(logs[i].gameObject.transform.GetChild(0).gameObject != null)
        {
            logs[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
      
    }
    void deactivate(int i)
    {
        if (logs[i].gameObject.transform.GetChild(0).gameObject != null)
        {
            logs[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);

        }

    }

    void deactivateStart(int i)
    {
        logs[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
