using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthBar : MonoBehaviour
{
    public Animator[] animator = new Animator[3];
    public RespawnManager Res;
    public ParticleSystem particle;


    public int CurrentHealth, Maxhealth;
    

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
            
    
            animator[CurrentHealth].SetBool("TookDammage", true);
            animator[CurrentHealth].SetBool("Refill", false);
           
            hitpoints--;
            CurrentHealth++;

            Destroy(collision.gameObject);

            if (hitpoints == -1)
            {
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(Res.Die());
                particle.Play();
                gameObject.SetActive(false);
                
            }
        }
    }

    public void refill() //Regenerate, change to add new healthbar upon battery
    {
        for(int i = 0; i < Maxhealth; i++)
        {
            animator[i].SetBool("Refill", true);
            animator[i].SetBool("TookDammage", false);
            
        }
        CurrentHealth = 0;
        hitpoints = Maxhealth;
        print(hitpoints);
    }

    



}
