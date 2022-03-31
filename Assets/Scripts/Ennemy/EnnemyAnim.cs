using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAnim : MonoBehaviour
{
    public Animator animator;
    public bool aggro;
    public bool Alerted;
    public GameObject Player;
    public float range;

    public enum State // diff�rents states pour l'ennemi
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

    void print()
    {
        print("fuck");
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
        //Aggro();


    }

    void Alert() // g�re les animations de l'ennemi de Idle � Alert
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
            case State.Aggro:
                print("bruh");
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
                break;

            case State.Stop:
              
                break;

            default:
                break;
        }
    }

}
