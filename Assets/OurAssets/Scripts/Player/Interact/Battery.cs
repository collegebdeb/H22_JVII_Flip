using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

    public PlayerMovement Interract; //Activer/Descativer interact
    public HealthBar healthbar;
    public AudioSource BatterySound;

    public bool CanGet;
    public bool isIn;
    public bool got;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Interract = GameManager.Instance.Player.GetComponent<PlayerMovement>();
        healthbar = GameManager.Instance.Player.GetComponent<HealthBar>();
        animator = gameObject.GetComponent<Animator>();

         //Get the crystal once its open
    }

    // Update is called once per frame
    void Update()
    {
     if(isIn && CanGet)
        {
            Interract.CanInterract = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && !got)
        {
            Get();
            Interract.CanInterract = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Si le joueur entre dans le TP
    {
        if (other.gameObject.name == "Player") //Activer bool pour tp
        { activate(); 
          isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") //Activer bool pour tp
        {
            
            isIn = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!got )
            {
                isIn = true;
            }
            

        }
    }

    void activate()
    {
        animator.SetBool("Activate", true);
        StartCoroutine(Getit());
    }

    private void Get()
    {
        if (CanGet)
        {
            animator.SetBool("Get", true);
            healthbar.Maxhealth++;
            healthbar.refill();
            BatterySound.Play();

            CanGet = false;
            got = true;
        }
    }

    IEnumerator Getit()
    {
        yield return new WaitForSeconds(2);
        this.CanGet = true;
    }
}
