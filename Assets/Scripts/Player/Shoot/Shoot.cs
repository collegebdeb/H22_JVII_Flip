using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float offset = 0.0f;
    public GameObject arrow;
    public Transform firepoint;
    public bool canShoot;
    public bool timer;
    


    // Use this for initialization
    void Start()
    {
        canShoot = true;
        timer = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            ShootArrow();
            canShoot = false;

            if(timer)
            {
                StartCoroutine(ShootTimer()); // empêche le joueur de tirer en succession, à changer
                timer = false;
            }
        }
    }

    void Rotation()
    {
        //Rotate towards mouse
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }

    void ShootArrow()
    {
        Instantiate(arrow, firepoint.position, transform.rotation);
       
    }

    private IEnumerator ShootTimer() //Basique et fonctionne mal, à changer, Timer d'attaque
    {
        print("Called!");
        while(true)
        {
            yield return new WaitForSeconds(2f);
            canShoot = true;
        }
    }
}