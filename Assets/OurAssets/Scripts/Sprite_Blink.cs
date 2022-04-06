using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Blink : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag== "Bullet 1")
        {
         StartCoroutine(FlashRed())
        }

        

    }
    public IEnumerator FlashRed()
    {

    }
}