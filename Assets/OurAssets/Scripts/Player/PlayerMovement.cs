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

    public bool isdashing;

    public GameObject dashtarget;
    
    Vector2 target;

    

    // l'enregistrement physique du personnage et du joueur dans le monde
    public Rigidbody2D rb;

    public GameObject child; //Rotation du viseur

    // Utilisé pour enregistrer le valeur du mouvement du joueur
    // puis l'utiliser dans notre FixedUpdate afin de programmer le physique du mouvement
    Vector2 move;

    // Ceci est pour assigner les animations de la chasseuse avec le mouvement du joueur
    public Animator animateurJoueur;
    public bool personnageDirectionDroit;


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

        if(isdashing)
        {
            Dash();
        }

        MoveInput(); // donner vitesse joueur

       

        LEtsDraw();




    }

    private void LEtsDraw()
    {
        //Vector3 lip = dashtarget.transform.position;
        Debug.DrawLine(transform.position, dashtarget.transform.position, Color.red);
    }

    void Dash()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, dashtarget.transform.position, 3f);
        if (hit.collider.tag == "Wall")
        {
            print("jots");
            isdashing = false;
            return;
        }*/

        //ray = Physics2D.Raycast();



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

    void FixedUpdate()
    {
        // Ici update sera utilisé afin de coder les physiques du mouvement du jeu puisqu'il est appelé 50 fois par
        // frame faisant celui-ci plus fiable.

        // Le rigidbody va bouger à la nouvelle position grâce à l'input du joueur
        Move();
       Flip(move.x);
    }

    // Ceci est pour changer la direction du personnage en idle lorsqu'il a finit de bouger
    // est déterminé par son direction antécédant 
    private void Flip(float joueurHorizontale)
    {
       if (joueurHorizontale > 0 && !personnageDirectionDroit || joueurHorizontale < 0 && personnageDirectionDroit)
       {
           personnageDirectionDroit = !personnageDirectionDroit;

           Vector3 theScale = transform.localScale;

           theScale.x *= -1;

           transform.localScale = theScale;
       } 
    }

    void MoveInput()
    {
        if(isdashing)
        {
            return;
        }
         
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        move = new Vector2(x, y).normalized;

        // On cherche l'input du donnée horizontale ou verticale du joueur lorsqu'il bouge 
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        // Ceci est l'assignement de l'animation selon l'axe de mouvement du personnage et selon si
        // le joueur bouge. Sinon, la chasseuse reste en animation Idle

        animateurJoueur.SetFloat("mouvementHorizontale", move.x);
        animateurJoueur.SetFloat("mouvementVerticale", move.y);
        animateurJoueur.SetFloat("joueurVitesse", move.sqrMagnitude);
    }

    void Move()
    {
        rb.velocity = new Vector2(move.x * speed, move.y * speed);
    }

    void DashtargetClamp()
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
