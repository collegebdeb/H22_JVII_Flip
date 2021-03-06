using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision);

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
