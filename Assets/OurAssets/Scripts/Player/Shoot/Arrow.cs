using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public TakeDammage hit;
    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
        DestroyDistance();
    }

    void DestroyDistance()
    {
        if (Vector3.Distance(startpos,transform.position) > 12)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Ennemy")
        {
            hit = collision.GetComponent<TakeDammage>();
            hit.hit();
            Destroy(gameObject);
        }
    }




}
