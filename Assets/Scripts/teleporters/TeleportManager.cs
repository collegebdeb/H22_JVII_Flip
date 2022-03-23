using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform[] TpPos = new Transform[6];
    public GameObject[] Teleporters = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        FileTeleportation();
    }

    // Update is called once per frame
    void Update()
    {
        
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
