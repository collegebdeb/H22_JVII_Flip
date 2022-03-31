using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirDeFleche : MonoBehaviour
{   
    // À utiliser éventuellement pour viser nos flèches
    private Vector2 positionMouse;
    public Camera cameraScene;

    // Ceci est pour éventuellement attribuer une direction à nos flèches
    private Vector2 directionFleche;
    private Quaternion directionFlecheTest; 

    // Pour indiquer la position du personnage
    private Vector2 positionPlayer;
    private GameObject playerObj = null;

    // Références pour le prefab de la flèche de base et le point de tir sur le joueur
    public Transform baseDeTir;
    public GameObject flechePrefab;

    // Référence de la vitesse d'une flèche de base dans le jeu
    public float flecheVitesse = 20f;

    // Update is called once per frame
    void Update()
    {   
        // Ceci est pour identifier la position du joueur 
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }

        // Quand le joueur va tirer sur la touche pour tirer, le fonction de TirerFleche va s'activer
        if(Input.GetButtonDown("Fire1"))
        {
            //récupérer la position de la souris

            viseInput();
            
            TirerFleche();
        }
    }

    // Cette fonction a comme but de créer une flèche à partir du point de tir du joueur, puis lui 
    // appliquer une force 
    void TirerFleche()
    {
        // Tout d'abord, il faut convertir notre Vector2 de direction fleche en Quaternion pour diriger
        // notre instance
        directionFlecheTest = Quaternion.Euler(directionFlecheTest.x, directionFlecheTest.y, 0);


        // Nécessaire pour que le GameObject du flèche utilise ce code comme référence dans le futur
        // et pour assurer qu'il aille un rigidbody 
        GameObject flecheDeBase = Instantiate(flechePrefab, baseDeTir.position, baseDeTir.rotation);
        Rigidbody2D rbFleche = flecheDeBase.GetComponent<Rigidbody2D>();
        rbFleche.AddForce(baseDeTir.up * flecheVitesse, ForceMode2D.Impulse);
    }

    // Cette fonction a comme but d'enregistrer la position du curseur de souris et de le soustraire
    // par la position du joueur, afin de chercher la direction de la flèche
    void viseInput()
    {
        positionMouse = cameraScene.ScreenToWorldPoint(Input.mousePosition);
        directionFleche = (positionMouse - positionPlayer);
        directionFleche.Normalize();
        Debug.Log("Direction fleche : " + directionFleche);
    }
}
