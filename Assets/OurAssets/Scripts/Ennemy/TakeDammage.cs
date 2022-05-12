using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDammage : MonoBehaviour
{
    public int healthcount;
    Transform healthbar;
    GameObject bar;
    public EnnemyAnim anim;
    public ShieldScript shieldscript;
    Animator Ennemy;

    public DropLog log;

    bool dead;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<DropLog>() != null)
        {
            log = gameObject.GetComponent<DropLog>();
        }
       

        bar = gameObject.transform.GetChild(1).gameObject;
        healthbar = transform.GetChild(1);
        anim = GetComponentInParent<EnnemyAnim>();
        shieldscript = gameObject.transform.GetChild(2).gameObject.GetComponent<ShieldScript>();

        Ennemy = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthcount == 3)
        {
            Ennemy.SetBool("dead", true);
            dead = true;
            StartCoroutine(destroyHB());
        }
    }

   

    public void hit()
    {
        if (anim.vulnerable && !dead)
        {
          
            Animator animator;
            print("hit!");
            animator = healthbar.GetChild(healthcount).GetComponent<Animator>();
            animator.SetBool("TookDammage", true);
           
            healthcount++;

           
            //destroyed();
        }
        else
        {
            StartCoroutine(shieldscript.SpriteFade(0, 0.5f)); // Faire apparaître le bouclier
        }
      
      
    }

    void destroyed()
    {
        if(log != null)
        {
            log.DropaLog();
        }
        Destroy(gameObject);
    }

    IEnumerator destroyHB()
    {
        print("Is dying");
        yield return new WaitForSeconds(0.4f);
        Destroy(bar);
    }
    

   
}
