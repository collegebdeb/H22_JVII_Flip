using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public GameObject text;
    public bool on;
    public bool sound;
    public AudioSource source;
    bool hasntreadyet;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("indicator");
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (on && !hasntreadyet)
        {
            StartCoroutine(closetext());
        }

        if(sound)
        {
            Playsound();
        }

    }

    public void Playsound()
    {
        sound = false;
        source.Play();
    }

    public IEnumerator closetext()
    {
        on = false;
        hasntreadyet = true;
        text.SetActive(true);
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }
}
