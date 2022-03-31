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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aggro();
        
    

        
    }

    void Alert() // gère les animations de l'ennemi
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

    void Aggro()
    {   //active des paramètres si le joueur est proche
        Alert();
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.position) < range) 
        {
            Alerted = true;
            
        }
        else
        {
            Alerted = false;
        }
    }

    

}
