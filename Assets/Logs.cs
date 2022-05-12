using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logs : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public InteractManager inter;
    public Selectors selector;
    bool interact;
    
    // Start is called before the first frame update
    void Start()
    {
        
        playerMovement = GameManager.Instance.Player.GetComponent<PlayerMovement>();
        inter = GameObject.Find("---Interactables---").GetComponent<InteractManager>();
        selector = GameManager.Instance.Player.GetComponentInChildren<Selectors>(true);
        
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(interact && Input.GetKeyDown(KeyCode.E))
        {
            get();
            playerMovement.CanInterract = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player")
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

    void get()
    {
        selector.currentLogCount++;
        inter.on = true;
        
    }
   
           
}
