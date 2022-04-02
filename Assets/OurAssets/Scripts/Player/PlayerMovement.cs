using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // la vitesse que le joueur va avoir lorsqu'il va bouger
    public float speed = 5f;
    float x;
    float y;

    // l'enregistrement physique du personnage et du joueur dans le monde
    public Rigidbody2D rb;

    // Utilisé pour enregistrer le valeur du mouvement du joueur
    // puis l'utiliser dans notre FixedUpdate afin de programmer le physique du mouvement
    Vector2 move;

    // Ceci est pour assigner les animations de la chasseuse avec le mouvement du joueur
    public Animator animateurJoueur;

    public bool personnageDirectionDroit;

    // Update is called once per frame
    void Update()
    {
        MoveInput(); // donner vitesse joueur

       // On cherche l'input du donnée horizontale ou verticale du joueur lorsqu'il bouge 
       x = Input.GetAxisRaw("Horizontal");
       y = Input.GetAxisRaw("Vertical");
    
       // Ceci est l'assignement de l'animation selon l'axe de mouvement du personnage et selon si
       // le joueur bouge. Sinon, la chasseuse reste en animation Idle

       animateurJoueur.SetFloat("mouvementHorizontale", move.x); 
       animateurJoueur.SetFloat("mouvementVerticale", move.y); 
       animateurJoueur.SetFloat("joueurVitesse",  move.sqrMagnitude);

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
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        move = new Vector2(x, y).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(move.x * speed, move.y * speed);
    }
}
