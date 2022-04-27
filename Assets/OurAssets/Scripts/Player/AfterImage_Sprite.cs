using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage_Sprite : MonoBehaviour
{
    [SerializeField]
    private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    [SerializeField]
    private float alphaset = 0.8f;
    private float alphamultiplier = 0.85f;
    private Transform player;
    private SpriteRenderer SR;
    private SpriteRenderer playerSR;
    private Color color;



    // Start is called before the first frame update
    private void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaset;
        SR.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }
    private void Update()
    {
        alpha *= alphamultiplier;
        color = new Color(1f, 1f, 1f, alpha);
        SR.color = color;

        if (Time.time >= (timeActivated + activeTime))
        {
            //Add back to pool.
        }
    }
}
