using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectors : MonoBehaviour
{
    public GameObject[] logs = new GameObject[4];
    public int selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < logs.Length; i++)
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
        if(Input.GetKeyDown(KeyCode.DownArrow))
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
        if(Input.GetKeyDown(KeyCode.UpArrow))
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
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        { }
        
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
