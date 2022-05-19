using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryHolderScript : MonoBehaviour
{
    public Animator animate;
    PlayerMovement playerMovement;
    public BatteryWall battery;
    public bool got,canget;

    AudioSource source;
    public HealthBar hbar;

    public int necessaryHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameManager.Instance.Player.GetComponent<PlayerMovement>();
        hbar = GameManager.Instance.Player.GetComponent<HealthBar>();
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hbar.Maxhealth == necessaryHealth)
        {
            canget = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!got && canget)
            {
                playerMovement.CanInterract = true;
            }
            if(Input.GetKeyDown(KeyCode.E) && !got && canget)
            {
                source.Play();
                battery.BatCharge++;
                animate.SetBool("Got", true);
                got = true;
                playerMovement.CanInterract = false;
            }
            
        }
    }

    

}
