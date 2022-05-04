using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDammage : MonoBehaviour
{
    public int healthcount;
    Transform healthbar;
    public EnnemyAnim anim;
    public ShieldScript shieldscript;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = transform.GetChild(1);
        anim = GetComponentInParent<EnnemyAnim>();
        shieldscript = gameObject.transform.GetChild(2).gameObject.GetComponent<ShieldScript>();
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
        else
        {
            StartCoroutine(shieldscript.SpriteFade(0, 0.5f)); // Faire apparaître le bouclier
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
