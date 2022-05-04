using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public IEnumerator SpriteFade(
 float endValue,
 float duration)
    {
        SpriteRenderer SSr = gameObject.GetComponent<SpriteRenderer>();
        float elapsedTime = 0;
        float startValue = 1;
        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            SSr.color = new Color(SSr.color.r, SSr.color.g, SSr.color.b, newAlpha);
            print(SSr.color.a);
            yield return null;
        }
    }
}
