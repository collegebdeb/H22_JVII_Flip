using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryWall : MonoBehaviour
{
    public GameObject batterywall;
    private float duration = 1.5f, TimeElapsed,percentage;

    public bool active;
    public bool closing;

    public int batteryCount,BatCharge;

    public Transform targetpos;
    public BoxCollider2D collider2d;
    

    Vector3 velocity = new Vector3(0, 0, 0);
    Vector3 starpos;

    public float lerpspeed;

    // Start is called before the first frame update
    void Start()
    {
        collider2d = transform.parent.gameObject.GetComponent<BoxCollider2D>();
        active = false;
        starpos = transform.position;
    }

    // Update is called once per frame


    private void Update()
    {
        if (active)
        {
            open();
        }

        if (closing)
        {
            close();
        }

        if(batteryCount == BatCharge)
        {
            active = true; 
        }

        if(batterywall.transform.position.y <= targetpos.position.y + 0.25f)
        {
            collider2d.enabled = false;
        }
        else
        {
            collider2d.enabled = true;
        }
    }

    public void open()
    {
        batterywall.transform.position = Vector3.SmoothDamp(batterywall.transform.position, targetpos.position, ref velocity, Time.deltaTime * lerpspeed);
        if(batterywall.transform.position.y == targetpos.position.y)
        {
            active = false;
        }
    }
    public void close()
    {
        batterywall.transform.position = Vector3.SmoothDamp(batterywall.transform.position, starpos, ref velocity, Time.deltaTime * lerpspeed);

    }
}
