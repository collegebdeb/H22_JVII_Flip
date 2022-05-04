using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryWall : MonoBehaviour
{
    public GameObject batterywall;
    private float duration = 1.5f, TimeElapsed,percentage;

    bool active;

    public Transform targetpos;
    public BoxCollider2D collider2d;

    Vector3 velocity = new Vector3(0, 0, 0);

    [Range(0, 100)] public float lerpspeed;

    // Start is called before the first frame update
    void Start()
    {
        collider2d = transform.parent.gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame


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

        if(batterywall.transform.position.y <= targetpos.position.y + 0.25f)
        {
            collider2d.enabled = false;
        }
    }
}
