using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDammage : MonoBehaviour
{
    public int healthcount;
    Transform healthbar;
    public EnnemyAnim anim;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = transform.GetChild(1);
        anim = GetComponentInParent<EnnemyAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void hit()
    {
        if (anim.vulnerable)
        {
            Animator animator;
            print("hit!");
            animator = healthbar.GetChild(healthcount).GetComponent<Animator>();
            animator.SetBool("TookDammage", true);
            healthcount++;
            destroyed();
        }
      
      
    }

    void destroyed()
    {
        if(healthcount == 3)
        {
            Destroy(this.gameObject);
        }
    }

   
}
