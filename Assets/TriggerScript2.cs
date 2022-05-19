using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript2 : MonoBehaviour
{
    public BatteryWall battery;
    public Transform player;
    public float playerDifference;
    // Start is called before the first frame update
    void Start()
    {
       
        battery = GetComponentInChildren<BatteryWall>();
        player = GameManager.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
      
        playerDifference = player.position.x - transform.position.x;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if(collision.gameObject.name == "Player" && playerDifference > 0)
        {
            print("close");
            battery.active = false;
            battery.closing = true;
        }

       
    }
}
