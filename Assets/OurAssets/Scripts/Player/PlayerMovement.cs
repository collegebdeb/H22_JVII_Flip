using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // la vitesse que le joueur va avoir lorsqu'il va bouger
    public float speed = 5f;
    float x;
    float y;
    float Dashspeed = 30;

    public Rigidbody2D rb;

    public bool isdashing;
    public bool CanInterract;

    public GameObject dashtarget;
    public GameObject child; //Rotation du viseur


    Vector2 target; // curseur
    Vector2 move;

    public Animator animateurJoueur;
    


    private void Start()
    {
        child = gameObject.transform.GetChild(0).gameObject;
        isdashing = false;
        dashtarget = gameObject.transform.GetChild(1).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        DashtargetClamp();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isdashing = true;
            print("pressed");
            target = dashtarget.transform.position;
            
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            
        }
        

        if (isdashing)
        {
            Dash();
        }

        MoveInput(); // donner vitesse joueur
        Interract();
        LEtsDraw();
        CheckForCollisionDash();
    }

    public void Interract()
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

    void CheckForCollisionDash()
    {
        print("ook");
     

        
    }
    private void LEtsDraw()
    {
        //Vector3 lip = dashtarget.transform.position; 
        Debug.DrawLine(transform.position, dashtarget.transform.position, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dashtarget.transform.position, 5);
        if (hit.collider.tag == "Wall")
        {
            print("jots");

        }

    }


    void Dash()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Dashspeed * Time.deltaTime);

        if (Vector2.Distance(transform.position,target) < 0.1f)
        {
            isdashing = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.name.StartsWith("Ennemy"))
        {
            isdashing = false;
        }
    }


    void MoveInput()
    {
       if (isdashing)
        {
            return;
        }
         
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        move = new Vector2(x, y).normalized;
        rb.velocity = new Vector2(move.x * speed, move.y * speed);

        // Ceci est l'assignement de l'animation selon l'axe de mouvement du personnage et selon si
        // le joueur bouge. Sinon, la chasseuse reste en animation Idle

        animateurJoueur.SetFloat("mouvementHorizontale", move.x);
        animateurJoueur.SetFloat("mouvementVerticale", move.y);
        animateurJoueur.SetFloat("joueurVitesse", move.sqrMagnitude);
    }

    void DashtargetClamp() //Dashtarget peut pas sortir du radius
    {
        float radius = 5f;

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the offset vector from the transform.position of the circle to our position
        Vector2 offset = position - transform.position;
        // Calculate the linear distance of this offset vector
        float distance = offset.magnitude;
        if (radius < distance)
        {
            // If the distance is more than our radius we need to clamp
            // Calculate the direction to our position
            Vector3 direction = offset / distance;
            // Calculate our new position using the direction to our old position and our radius
            position = transform.position + direction * radius;
            dashtarget.transform.position = position;
        }
        else
        {
            dashtarget.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,13);
        }
    }

 
}
