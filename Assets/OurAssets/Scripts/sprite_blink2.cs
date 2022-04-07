using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_blink2 : MonoBehaviour
{
    public SpriteRenderer sprite;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine(FlashRed());
            
        }
    }
    public IEnumerator FlashRed()
        {
            sprite.color
            = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color
            = Color.white;
        }
    }
