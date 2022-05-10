using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public GameObject text;
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("indicator");
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(closetext());
        }
    }

    public IEnumerator closetext()
    {
        on = false;
        text.SetActive(true);
        yield return new WaitForSeconds(4f);
        print("what is going in");
        text.SetActive(false);
    }
}
