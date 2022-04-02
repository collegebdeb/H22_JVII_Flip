using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    public Transform[] TpPos = new Transform[6];
    public GameObject[] Teleporters = new GameObject[2];
    public Text InteractTP;
    public bool CanTp;
    public Transform TpDestination;

    // Start is called before the first frame update
    void Start()
    {
        FileTeleportation();
        InteractTP = GameObject.Find("CanTeleport").GetComponent<Text>();
        TpDestination = TpPos[1];
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other) //Si le joueur entre dans le TP
    {
       
        
        if (other.gameObject.name.StartsWith("Teleporter")) //Activer bool pour tp
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

            InteractTP.text = "Can Teleport";
            CanTp = true;
        }
    }



    private void OnTriggerExit2D(Collider2D other) // Si le joueur quitte le TP
    {
        if (other.gameObject.name.StartsWith("Teleporter"))//Désactiver bool pour tp
        {
            InteractTP.text = "";
            CanTp = false;
        }

    }

    void FileTeleportation() //Entrer tout les positions des points de téléportation sur la map
    {
        for (int i = 0; i < TpPos.Length; i++)
        {
            TpPos[i] = GameObject.Find("TpPos" + i).transform;
        }
        for (int i = 0; i < Teleporters.Length; i++)
        {
            Teleporters[i] = GameObject.Find("Teleporter" + i);
        }
    }
    void SetDestination(Collider2D other) //change l'endroit de téléportation à chaque fois que le personnage touche un téléporteur
    {
      
    }
}



