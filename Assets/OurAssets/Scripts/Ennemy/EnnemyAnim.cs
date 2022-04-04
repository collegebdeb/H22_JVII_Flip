using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnnemyAnim : MonoBehaviour
{
    public Animator animator;
    public bool aggro;
    public bool Alerted;
    public GameObject Player;
    public float range;
    public AIDestinationSetter SetDestination;
    public AIPath path;
    public Transform Idleposition;

    float currentposition;
    float lastposition = 0;

    public enum State // différents states pour l'ennemi
    {
        Idle,
        Aggro,
        Chase,
        Fire,
        Stop
    }

    public State state;

    void Update()
    {
        ChangeState();   //Changer le state
        CheckPosition(); //Pivoter le personnage 
        Alert();         //changer l'alert si le personnage est alerted ou nons
    }

    void Chase() //partir la chasse quand le joueur est assez proche, fonction appelée dans l'animation
    {
        state = State.Chase;
        animator.SetBool("ReachedPos", false);
    }

    void AfterCharge() //Une fois que le robot a finit de charger et de tirer, regarder ou se trouve le joueur pour déterminer son état
    {
        animator.SetBool("Fire", false);

        if (Vector3.Distance(transform.position, GameManager.Instance.Player.position) == 0)
        {
            Alerted = false;
            state = State.Idle;
        }
        else
        {
            state = State.Chase;
        }
    }
    void CheckPosition()
    {
        currentposition = transform.position.x;
        animator.SetFloat("Horizontal", currentposition - lastposition);
        lastposition = currentposition;


    }
    // Update is called once per frame


    void Alert() // gère les animations de l'ennemi de Idle à Alert et son Aggro
    {
        if (Alerted)
        {
            animator.SetBool("Alerted", true);
            animator.SetBool("Aggro", true);
        }
        else
        {
            animator.SetBool("Alerted", false);
            animator.SetBool("Aggro", false);
        }
    }


    /* if (Vector3.Distance(transform.position, GameManager.Instance.Player.position) >= range)
        {
            Alerted = false;
            aggro = false;
            state = State.Idle;
            animator.SetBool("Fire", false);
         
        }*/



void ChangeState() // Change l'état de l'ennemi
    {
        switch (state)
        {
          

            case State.Idle:
                if (Vector3.Distance(transform.position, Idleposition.position) <= 1f)
                {
                    animator.SetBool("ReachedPos", true);
                }
                path.maxSpeed = 4;
                SetDestination.target = Idleposition.transform;
                Alerted = false;
                if (!aggro && Vector3.Distance(transform.position, GameManager.Instance.Player.position) < range)
                {
                    Alerted = true;
                }
                break;

        
            case State.Chase:
                SetDestination.target = GameManager.Instance.Player;  //Player gets targeted
                path.maxSpeed = 4;
                if (!aggro && Vector3.Distance(transform.position, GameManager.Instance.Player.position) > range + 3f) //If player out of range
                {
                    print("Not aggro anymore");
                    state = State.Idle;
                }
                if(Vector3.Distance(transform.position,GameManager.Instance.Player.position) <= 5)
                {
                    state = State.Fire;
                }
                break;

            case State.Fire:
                {
                    animator.SetBool("Fire", true);
                    path.maxSpeed = 0;
                } break;


            default:
                break;
        }
    }

}
