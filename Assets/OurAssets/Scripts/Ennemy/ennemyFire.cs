using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyFire : MonoBehaviour
{

    public float offset = 0.0f;
    public GameObject bullet;
    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        firepoint = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        //Rotate towards mouse
        Vector3 difference = GameManager.Instance.Player.position - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

    }

    public void ShootArrow()
    {
        // Instantiate(bullet, firepoint.position, transform.rotation);
        Instantiate(bullet, transform.position, transform.rotation);

    }
}
