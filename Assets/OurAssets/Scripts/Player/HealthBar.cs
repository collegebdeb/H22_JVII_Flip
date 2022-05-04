using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthBar : MonoBehaviour
{
    public Animator animator;
    public RespawnManager Res;
    int hitpoints;
    // Start is called before the first frame update
    void Start()
    {
        hitpoints = 0;
        Res = GameObject.Find("---Player---").GetComponent<RespawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Bullet"))
        {
            collision.gameObject.name = "";
    
            animator.SetBool("TookDammage", true);
            animator.SetBool("Refill", false);
           
            hitpoints--;
            print(hitpoints);

            Destroy(collision.gameObject);

            if (hitpoints == -1)
            {
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(Res.Die());
                gameObject.SetActive(false);
                
            }
        }
    }

    public void refill() //Regenerate, change to add new healthbar upon battery
    {
        animator.SetBool("Refill", true);
        animator.SetBool("TookDammage", false);
        hitpoints++;
        print(hitpoints);
    }




}
