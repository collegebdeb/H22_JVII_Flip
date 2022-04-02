using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Animator animator;
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            animator.SetBool("TookDammage", true);
            animator.SetBool("Refill", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            animator.SetBool("TookDammage", false);
        }
    }

}
