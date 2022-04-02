using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    float _followspeed = 5f;

    int[] chose = new int[5];
    
    // Update is called once per frame
    private void Update()
    {
        Getnewposition();
    }

    void Getnewposition()
    {
        Vector3 newPos = new Vector3(GameManager.Instance.Player.position.x, GameManager.Instance.Player.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, _followspeed * Time.deltaTime);
    }

}
