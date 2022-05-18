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
        if(Input.GetKeyDown(KeyCode.E) && isIn) { Get(); 
        } //Get Crystal if canget
        if(!CanGet && isIn) { Interract.CanInterract = false; } //shut down interract if got
        if(CanGet && isIn) { Interract.CanInterract = true; } //Show Interract
        
    }

    private void OnTriggerEnter2D(Collider2D other) //Si le joueur entre dans le TP
    {
        if (other.gameObject.name == "Player") //Activer bool pour tp
        { activate(); 
          isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // Si le joueur quitte le TP
    {
        if (other.gameObject.name == "Player")//Désactiver bool pour tp
        { isIn = false;  }
        Interract.CanInterract = false;

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
            healthbar.refill();
            BatterySound.Play();
            CanGet = false;
            got = true;
        }
    }

    IEnumerator Getit()
    {
        yield return new WaitForSeconds(2);
        CanGet = true;
    }
}
