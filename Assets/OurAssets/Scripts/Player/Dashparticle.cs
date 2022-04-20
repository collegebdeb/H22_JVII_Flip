using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashparticle : MonoBehaviour
{
  // PlayerController player;
    public PlayerMovement dash;
    public GameObject ghostPrefab;
    public float delay = 1.0f;
    float delta = 0;
    SpriteRenderer spriteRenderer;
    public float destroyTime = 0.1f;
    public Color color;
    public Material materiel =null;

    // Start is called before the first frame update
    void Start()
    {
         dash = gameObject.GetComponent<PlayerMovement>();
        if (dash.isdashing)
        {

        }
        // }

        // Update is called once per frame
        // void Update()
        //{

        //}
    }
    void createGhost()
    {
        GameObject ghostObj = Instantiate(ghostPrefab, transform.position, transform.rotation);
        //ghostObj.transform.localScale = player.transform.localScale;
        Destroy(ghostObj, destroyTime);
        spriteRenderer = ghostObj.GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = player;
    }
}

