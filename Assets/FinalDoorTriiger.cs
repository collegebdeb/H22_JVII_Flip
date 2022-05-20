using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinalDoorTriiger : MonoBehaviour
{
    public Animator[] animate;
    public int index = 0;
    bool canget;
    public AudioSource source;

    public Image img;
    public Color color;
    [Range(0, 1)] public float range; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        img.color = color;
        color.a = range;
        if(index  ==3)
        {
            range += (Time.deltaTime * 0.4f);
            StartCoroutine(restartmenu());
        }
      
        if (Input.GetKeyDown(KeyCode.E) && canget)
        {
            source.Play();
            animate[index].SetBool("Got", true);
            if(index < 4)
            {
                index++;

            }
            else
            {
                canget = false;
            }
            if(index == 3)
            {
                animate[3].SetBool("Open", true);
                animate[4].SetBool("Open", true);
            }
            
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player"  && index < 4)
        {
            GameManager.Instance.Player.GetComponent<PlayerMovement>().CanInterract = true;
            canget = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.Player.GetComponent<PlayerMovement>().CanInterract = false;
            canget = false;
        }
       
    }

    private IEnumerator restartmenu()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
