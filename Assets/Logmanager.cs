using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logmanager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    bool interact;
    public Selectors selector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (interact && Input.GetKeyDown(KeyCode.E))
        {
            selector.currentLogCount++;
            playerMovement.CanInterract = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerMovement.CanInterract = true;
            interact = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerMovement.CanInterract = false;
            interact = false;
        }
    }
}
