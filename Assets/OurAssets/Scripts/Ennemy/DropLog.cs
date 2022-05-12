using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLog : MonoBehaviour
{
    public GameObject log;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void DropaLog(Vector3 kill)
    {
        Instantiate(log,kill,Quaternion.identity);
        print(kill + "yeaaah");
        //log.transform.position = kill;
    }
}
