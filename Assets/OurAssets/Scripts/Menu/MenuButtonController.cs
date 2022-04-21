using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    public int Maxindex;
    int VerticalMovement;
  
    RectTransform RT;

    public bool keyDown;
    bool isPressUp, isPressDown, isPressConfirm;


    void Start()
    {
        RT = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isPressUp) VerticalMovement = 1;
        if (isPressDown) VerticalMovement = -1;
        if (!isPressUp && !isPressDown) VerticalMovement = 0;
    }

    public void onPressUp() { isPressUp = true; }
    public void onPressDown() { isPressDown = true; }
    public void onPressConfirm() { isPressConfirm = true; }
    public void onReleaseUp() { isPressUp = false; }
    public void onReleaseDown() { isPressDown = false; }
    public void onReleaseConfirm() { isPressConfirm = false; }
    

}
