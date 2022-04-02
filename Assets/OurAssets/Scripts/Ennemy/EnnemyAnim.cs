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
    public Transform Idleposition;

    public enum State // différents states pour l'ennemi
    {
        Idle,
        Aggro,
        Chase,
        Stop
    }


    public State state;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    void Chase()
    {
        state = State.Chase;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
        //Aggro();


    }

    void Alert() // gère les animations de l'ennemi de Idle à Alert
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


    void ChangeState() // Change l'état de l'ennemi
    {
        switch (state)
        {
            case State.Aggro:
                Alert();
                if (Vector3.Distance(transform.position, GameManager.Instance.Player.position) >= range)
                {
                    Alerted = false;
                    aggro = false;
                    state = State.Idle;
                    Alert();
                }
                break;

            case State.Idle:
                if (!aggro && Vector3.Distance(transform.position, GameManager.Instance.Player.position) < range)
                {
                    Alerted = true;
                    state = State.Aggro;
                }
                break;

            case State.Chase:
                SetDestination.target = GameManager.Instance.Player;
                if (!aggro && Vector3.Distance(transform.position, GameManager.Instance.Player.position) > range)
                {
                    print("lets go");
                    state = State.Stop;
                }
                break;

            case State.Stop:
                {
                    SetDestination.target = Idleposition.transform;
                    if (Vector3.Distance(transform.position,Idleposition.position) < 1)
                    {
                        Alerted = false;
                        aggro = false;
                        state = State.Idle;
                        Alert();
                    }
                }
              
                break;

            default:
                break;
        }
    }

}
