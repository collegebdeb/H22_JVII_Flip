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

    // Start is called before the first frame update
    void Start()
    {
        FileTeleportation();
        InteractTP = GameObject.Find("CanTeleport").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.StartsWith("Teleporter"))
        {
            InteractTP.text = "Press E to teleport";
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Teleporter"))
        {
            InteractTP.text = "";
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
            Teleporters[i] = GameObject.Find("Teleporters" + i);
        }
    }
}
