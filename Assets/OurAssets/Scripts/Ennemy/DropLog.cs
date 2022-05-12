using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLog : MonoBehaviour
{
    public GameObject log;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropaLog()
    {
        Instantiate(log);
        log.transform.position = gameObject.transform.position;
    }
}
