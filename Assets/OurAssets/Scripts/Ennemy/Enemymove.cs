using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public bool Aggro;



    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Switchup()
    {
    }
}
