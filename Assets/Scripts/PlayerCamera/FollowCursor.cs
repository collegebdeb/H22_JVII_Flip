using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    private Camera cammain;
    private void Start()
    {
        cammain = Camera.main;
        Cursor.visible = false;
    }

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        transform.position = Worldpos();
    }

    private Vector2 Worldpos()
    {
        return cammain.ScreenToWorldPoint(Input.mousePosition);
    }

}
