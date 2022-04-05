using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Animator animator;
    int hitpoints = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Refill", true);
            animator.SetBool("TookDammage", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hitpoints == -1 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.name.StartsWith("Bullet 1"))
        {
            print("ouch");
            animator.SetBool("TookDammage", true);
            animator.SetBool("Refill", false);
            Destroy(collision.gameObject);
            hitpoints--;
        }
    }

}
