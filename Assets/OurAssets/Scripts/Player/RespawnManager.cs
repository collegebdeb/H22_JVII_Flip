using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{

    bool on,isrunning;
    // Start is called before the first frame update

    private void Update()
    {
        if(on && !isrunning)
        {
           
            StartCoroutine(Die2());
        }
    }
    public IEnumerator Die()
    {
        
         on = true;
     
        yield return new WaitForSeconds(3);
    
    }

    public IEnumerator Die2()
    {
        isrunning = true;
        yield return new WaitForSeconds(3);
        isrunning = false;
        death();

    }
    void death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
