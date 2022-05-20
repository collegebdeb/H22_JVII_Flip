using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrail : MonoBehaviour
{
    public PlayerMovement pm;
    public SpriteRenderer rd;
    public GameObject trail;
    public Material[] flash;

    public float ghostdelay,ghostdelaySeconds;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        rd = GetComponent<SpriteRenderer>();
        
        ghostdelaySeconds = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(pm.isdashing)
        {
            generatetTrail();
        }
    }

    void generatetTrail()
    {
        if(ghostdelay > 0)
        {
            ghostdelay -= Time.deltaTime;
        }
        else
        {
            ghostdelay = ghostdelaySeconds;
            GameObject currenttrail = Instantiate(trail, transform.position, transform.rotation);
            SpriteRenderer crd = currenttrail.GetComponent<SpriteRenderer>();
            int x = Random.Range(0, 3);
            crd.material = flash[x];
            
            crd.sprite = rd.sprite;
        }
    }
}
