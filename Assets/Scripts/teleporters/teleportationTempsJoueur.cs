using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportationTempsJoueur : MonoBehaviour
{
    // Ceux-ci sont pour le joueur les miroirs
    // public GameObject Miroir;
    public GameObject Camera;
    public GameObject Player;

    // Ceci est pour établir le nombre de téléporteurs qui vont se trouver dans le jeu
    public Transform[] teleporteur = new Transform[6]; 

    void Start()
    {
        testTeleportation();
    }

    // Quand le joueur va rentrer en collision avec le miroir, il va téléporter vers soit le passé 
    // ou le futur
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Teleportation());
        }
    }

    // Ceci est la iteration qui va faire la teleportation du joueur et du caméra. Il sera appelé une fois avant de finir la coroutine
    IEnumerator Teleportation()
    {
        yield return new WaitForSeconds (1);
        Player.transform.position = new Vector2(-7, -16);
        Camera.transform.position = new Vector3(-7, -16, -10);
    }

    // Pour établir le nombre de téléporteurs qui se retrouveront dans le niveau et assigner ces 
    // téléporteurs dans la code.
    void testTeleportation()
    {
        for (int i = 0; i < teleporteur.Length; i++)
        {
            teleporteur[i] = GameObject.Find("Teleporteur"+i).transform;
        }
    }
}
