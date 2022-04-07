using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

    public PlayerMovement Interract; //Activer/Descativer interact
    public HealthBar healthbar;

    public bool CanActivate;
    public bool CanGet;

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
        if(Input.GetKeyDown(KeyCode.E))
        {
            active();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Si le joueur entre dans le TP
    {


        if (other.gameObject.name == "Player") //Activer bool pour tp
        {
            print("In");
            
            Interract.CanInterract = true;
            CanActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // Si le joueur quitte le TP
    {
        if (other.gameObject.name == "Player")//Désactiver bool pour tp
        {
            print("out");
            
            Interract.CanInterract = false;
            CanActivate = false;
        }

    }

    void active()
    {
        if (CanActivate)
        {
            animator.SetBool("Activate", true);
            StartCoroutine(Getit());
            CanActivate = false;
        }
        if (CanGet)
        {
            animator.SetBool("Get", true);
            healthbar.refill();
            CanGet = false;
        }
       
    }

    IEnumerator Getit()
    {
        yield return new WaitForSeconds(2);
        CanGet = true;
    }
}
