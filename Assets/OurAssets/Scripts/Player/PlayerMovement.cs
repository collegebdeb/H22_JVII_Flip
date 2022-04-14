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

    public GameObject dashtarget;
    public GameObject child; //Rotation du viseur

    Vector2 move;
    Vector3 MoveDir;
    Vector3 MoveDir2;

    public Animator animateurJoueur;

    //DASH
    float dashspeed = 35f;
    float dashTimer = 0.1f;
    float CurrentDashTimer;

    public bool isdashing, candash;

    public LayerMask Wall; // For check

    private void Start()
    {
        isdashing = false;
        candash = true;
        CurrentDashTimer = dashTimer;
        dashtarget = gameObject.transform.GetChild(1).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDir2 = MoveDir = new Vector3(x, y);
        MoveInput(); // donner vitesse joueur
        Interract(); // Permet d'interragir
        Dash();      // velocity based dash
        raycastDash();
        // Check for 

        if (Input.GetKeyDown(KeyCode.C)) {  print("cast"); }

        if (Input.GetKeyDown(KeyCode.Space) && !isdashing && candash)
        { isdashing = true; MoveDir = new Vector3(x, y).normalized; } // get vector direction when walking for dash
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, MoveDir, 3f, Wall);
        if(hit.collider != null)
        {
            print(hit.collider.name);
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

    private IEnumerator CanDashAgain()
    {
        yield return new WaitForSeconds(1f);
        candash = true;
        print("go again");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        StopDash(collision);  
    }

   

    void StopDash(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.name.StartsWith("Ennemy"))
        {
            isdashing = false;
        }
    }



    void MoveInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (isdashing) { return; } //stop moving if dashing

        move = new Vector2(x, y).normalized; //normalise diagonal movement
        rb.velocity = new Vector2(move.x * speed, move.y * speed);

        //animation
        animateurJoueur.SetFloat("mouvementHorizontale", move.x);
        animateurJoueur.SetFloat("mouvementVerticale", move.y);
        animateurJoueur.SetFloat("joueurVitesse", move.sqrMagnitude);
    }

}
