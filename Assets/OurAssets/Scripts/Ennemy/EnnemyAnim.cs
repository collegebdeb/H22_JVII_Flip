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
    public bool vulnerable;

    float currentposition;
    float lastposition = 0;

    public ennemyFire firescript;


    public enum State // diff�rents states pour l'ennemi
    {
        Idle,
        Aggro,
        Chase,
        Fire,
        Stop
    }

    public State state;

    private void Start()
    {
        Idleposition = gameObject.transform.parent.transform;
        path = gameObject.GetComponent<AIPath>();
        SetDestination = gameObject.GetComponent<AIDestinationSetter>();
        firescript = gameObject.transform.GetChild(0).GetComponent<ennemyFire>();
    }

    void Update()
    {
        ChangeState();   //Changer le state
        CheckPosition(); //Pivoter le personnage 
        Alert();         //changer l'alert si le personnage est alerted ou nons
    }

    void Chase() //partir la chasse quand le joueur est assez proche, fonction appel�e dans l'animation
    {
        vulnerable = false;
        state = State.Chase;
        animator.SetBool("ReachedPos", false);
    }

    void AfterCharge() //Une fois que le robot a finit de charger et de tirer, regarder ou se trouve le joueur pour d�terminer son �tat
    {
        animator.SetBool("Fire", false);
        firescript.ShootArrow();

        if (Vector3.Distance(transform.position, GameManager.Instance.Player.position) == 0)
        {
            Alerted = false;
            state = State.Idle;
            vulnerable = false;
        }
        else
        {
            state = State.Chase;
            vulnerable = false;
        }
    }
    void CheckPosition()
    {
        currentposition = transform.position.x;
        animator.SetFloat("Horizontal", currentposition - lastposition);
        lastposition = currentposition;


    }
    // Update is called once per frame


    void Alert() // g�re les animations de l'ennemi de Idle � Alert et son Aggro
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

void ChangeState() // Change l'�tat de l'ennemi
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
                    vulnerable = true;
                    animator.SetBool("Fire", true);
                    path.maxSpeed = 0;
                } break;


            default:
                break;
        }
    }

}
