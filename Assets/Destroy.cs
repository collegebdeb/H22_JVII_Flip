using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float crush;
    GameObject thisobject;

    public Material[] flash;
    // Start is called before the first frame update
    void Start()
    {
        crush = 0.2f;
        thisobject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (crush > 0)
        {
            crush -= Time.deltaTime;
        }
        else
        {
            Destroy(thisobject);
        }
    }
}
