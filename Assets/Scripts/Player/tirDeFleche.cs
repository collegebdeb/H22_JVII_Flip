using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirDeFleche : MonoBehaviour
{   
    // À utiliser éventuellement pour viser nos flèches
    private Vector2 positionMouse;
    public Camera cameraScene;

    // Pour indiquer la position du personnage
    private Vector2 positionPlayer;

    // Références pour le prefab de la flèche de base et le point de tir sur le joueur
    public Transform baseDeTir;
    public GameObject flechePrefab;

    // Référence de la vitesse d'une flèche de base dans le jeu
    public float flecheVitesse = 20f;

    // Update is called once per frame
    void Update()
    {



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
        // Nécessaire pour que le GameObject du flèche utilise ce code comme référence dans le futur
        // et pour assurer qu'il aille un rigidbody 
        GameObject flecheDeBase = Instantiate(flechePrefab, baseDeTir.position, baseDeTir.rotation);
        Rigidbody2D rbFleche = flecheDeBase.GetComponent<Rigidbody2D>();
        rbFleche.AddForce(baseDeTir.up * flecheVitesse, ForceMode2D.Impulse);
    }

    void viseInput()
    {
        positionMouse = cameraScene.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(positionMouse);
        //trouve position personnage, qui est dans la même espace que la position du curseur
        //Fait un vecteur 2 pour calculer la distance de la flèche, position mouse - position player = direction vecteur 2 de la fleche
        //normalize la direction vers le valeur d'un vecteur entier
        // positionPlayer = 
    }
}
