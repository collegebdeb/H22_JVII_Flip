using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    TeleportManager tpM;

    // Start is called before the first frame update
    void Start()
    {
        tpM = GameObject.Find("Player").GetComponent<TeleportManager>(); //Get the script
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Teleport1();
        }
    }

    void Teleport1()
    {
        if(tpM.CanTp == true)
        {
            GameManager.Instance.Player.transform.position = tpM.TpDestination.transform.position;
            Camera.main.transform.position = tpM.TpDestination.transform.position + new Vector3(0, 0, -10);
        }
        else
        {
            return;
        }

    }

}
