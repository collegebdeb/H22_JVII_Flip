using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // la vitesse que le joueur va avoir lorsqu'il va bouger
    public float speed = 5f;
    float x;
    float y;

    public Rigidbody2D rb;

    public bool CanInterract;
    public bool onstairs; //offset le joueur quand il est sur des escaliers
    public float stairOffset; //amount de offset du joueur

    public GameObject dashtarget;
    public GameObject child; //Rotation du viseur

    Vector2 move;


    public Animator animateurJoueur;

    //DASH
    float dashspeed = 35f;
    float dashTimer = 0.1f;
    float CurrentDashTimer;

    Vector3 MoveDir;

    public bool isdashing, candash;
    public bool canbepushed;

    public LayerMask Wall; // For check

    private void Start()
    {
        isdashing = false;
        candash = true;
        CurrentDashTimer = dashTimer;
        dashtarget = gameObject.transform.GetChild(1).gameObject;
        stairOffset = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput(); // donner vitesse joueur
        Interract(); // Permet d'interragir
        Dash();      // velocity based 
        raycastDash();
        if (Input.GetKeyDown(KeyCode.C)) { print("cast"); }
        MoveDir = new Vector3(x, y);

        if (Input.GetKeyDown(KeyCode.Space) && !isdashing && candash)
        { isdashing = true;  } // get vector direction when walking for dash
    }

    public void Interract() // Montrer le bouton pour interragir
    {
        if (transform.GetChild(2).gameObject != null)
        {
            GameObject interact = transform.GetChild(2).gameObject;
            if (CanInterract)
            {
                interact.SetActive(true);
            }
            else
            {
                interact.SetActive(false);
            }
        }

    }

    public void raycastDash()
    {
        MoveDir = new Vector3(x, y).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, MoveDir, 1f, Wall);
        if (hit.collider != null)
        {
            isdashing = false;
        }
    }

    public void Dash()
    {
        if (isdashing)
        {
            rb.velocity = MoveDir * dashspeed;
            CurrentDashTimer -= Time.deltaTime;

        }
        if (CurrentDashTimer <= 0)
        {
            CurrentDashTimer = dashTimer;
            isdashing = false;
            candash = false;
            StartCoroutine(CanDashAgain());

        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "stairs")
        {
            onstairs = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "stairs")
        {
            onstairs = false;
        }
    }

    private IEnumerator CanDashAgain()
    {
        yield return new WaitForSeconds(1f);
        candash = true;
        print("go again");
        canbepushed = true;
    }

    void MoveInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (isdashing) { return; } //stop moving if dashing

        move = new Vector2(x, y).normalized; //normalise diagonal movement


        if(onstairs && move.x != 0)
        {
            if(move.x > 0) { stairOffset = -3.5f; } else { stairOffset = 2.5f; }
            rb.velocity = new Vector2(move.x * speed, move.y * speed) +  new Vector2(0, stairOffset);
            
        }
        else
        {
            rb.velocity = new Vector2(move.x * speed, move.y * speed);
        }

        

        //animation
        animateurJoueur.SetFloat("mouvementHorizontale", move.x);
        animateurJoueur.SetFloat("mouvementVerticale", move.y);
        animateurJoueur.SetFloat("joueurVitesse", move.sqrMagnitude);
    }

}