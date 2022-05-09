using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("indicator");
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator closetext()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
