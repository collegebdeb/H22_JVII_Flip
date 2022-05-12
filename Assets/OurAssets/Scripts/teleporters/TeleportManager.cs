using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    public Transform[] TpPos = new Transform[20];
    public Transform TpDestination;

    public GameObject[] Teleporters = new GameObject[20];
    public bool CanTp;
    

    public PlayerMovement Interract; //Activer/Descativer interact

    // Start is called before the first frame update
    void Start()
    {
        FileTeleportation();
        TpDestination = TpPos[1];
        Interract = GameManager.Instance.Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter2D(Collider2D other) //Si le joueur entre dans le TP
    {
       
        
        if (other.gameObject.name.StartsWith("Teleporter")) //Activer bool pour tp
        {
            SetDestination(other);
            Interract.CanInterract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // Si le joueur quitte le TP
    {
        if (other.gameObject.name.StartsWith("Teleporter"))//Désactiver bool pour tp
        {
            CanTp = false;
            Interract.CanInterract = false;
        }

    }

   



 

    void FileTeleportation() //Entrer tout les positions des points de téléportation sur la map
    {
        for (int i = 2; i < TpPos.Length; i++)
        {
            TpPos[i] = GameObject.Find("TpPos" + i).transform;
            if(TpPos[i] == null)
            {
                break;
            }
        }
        for (int i = 2; i < Teleporters.Length; i++)
        {
            Teleporters[i] = GameObject.Find("Teleporter" + i);
            if(Teleporters[i] == null)
            {
                break;
            }
        }
    }
    void SetDestination(Collider2D other) //change l'endroit de téléportation à chaque fois que le personnage touche un téléporteur
    {
        int number = int.Parse(other.name.Substring(10));
        if (number % 2 == 0) //Vérifier si nombre pair ou impair, indique l'endroit de téléportation avec
        {
            TpDestination = TpPos[number + 1]; //set destination
        }
        else
        {
            TpDestination = TpPos[number - 1];
        }
        CanTp = true;
    }
}



