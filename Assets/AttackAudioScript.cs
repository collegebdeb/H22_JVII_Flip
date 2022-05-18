using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAudioScript : MonoBehaviour
{
    public AudioSource[] sound = new AudioSource[4];
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 3, y = 0; i < 7; i++, y++)
        {
            sound[y] = transform.GetChild(i).GetComponent<AudioSource>();
        }

        sound[0] = transform.GetChild(3).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void AttackSound()
    {
        
       sound[0].Play();
    }
    public void deathSound()
    {
        sound[3].Play();
    }

    public void HitSound()
    {
        sound[1].Play();
    }

    public void ShieldSound()
    {
        sound[2].Play();
    }

}
