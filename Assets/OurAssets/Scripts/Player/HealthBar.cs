using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Animator animator;
    int hitpoints;
    // Start is called before the first frame update
    void Start()
    {
        hitpoints = 0;
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
