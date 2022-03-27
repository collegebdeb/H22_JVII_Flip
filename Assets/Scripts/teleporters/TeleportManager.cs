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
    private void OnTriggerEnter2D(Collider2D collision) //Si le joueur entre dans le TP
    {
        SetDestination(collision);
        if (collision.gameObject.name.StartsWith("Teleporter")) //Activer bool pour tp
        {
            InteractTP.text = "Can Teleport";
            CanTp = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision) // Si le joueur quitte le TP
    {
        if (collision.gameObject.name.StartsWith("Teleporter"))//D�sactiver bool pour tp
        {
            InteractTP.text = "";
            CanTp = false;
        }

    }

    void FileTeleportation() //Entrer tout les positions des points de t�l�portation sur la map
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
    void SetDestination(Collider2D collider) //change l'endroit de t�l�portation � chaque fois que le personnage touche un t�l�porteur
    {
        int number = int.Parse(collider.name.Substring(10));
        if (number % 2 == 0) //V�rifier si nombre pair ou impair, indique l'endroit de t�l�portation avec
        {
            TpDestination = TpPos[number + 1]; //set destination
        }
        else
        {
            TpDestination = TpPos[number - 1];
        }
    }
}



