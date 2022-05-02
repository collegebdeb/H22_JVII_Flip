using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryWall : MonoBehaviour
{
    public GameObject batterywall;
    private float duration = 1.5f, TimeElapsed,percentage;

    bool active;

    public Transform targetpos;

    Vector3 startposition, endposition;
    Vector3 velocity = new Vector3(0, 0, 0);
    Transform Bpos;

    [Range(0, 100)] public float lerpspeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     /*   if(Input.GetKeyDown(KeyCode.E))
        {
            active = true;
        }
        if(active)
        {   //TimeElapsed += Time.deltaTime;
            //percentage = TimeElapsed / duration;
            //batterywall.transform.position = Vector3.Lerp(startposition, endposition, percentage) ;
            batterywall.transform.position = Vector3.SmoothDamp(startposition, targetpos.position, ref velocity, Time.deltaTime * lerpspeed);
           

        }*/
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            active = true;
        }

        if (active)
        {
            batterywall.transform.position = Vector3.SmoothDamp(batterywall.transform.position,targetpos.position , ref velocity, Time.deltaTime * lerpspeed);
        }
    }
}
