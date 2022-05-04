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
            print("lesgo");
            StartCoroutine(Die2());
        }
    }
    public IEnumerator Die()
    {
        print("started");
         on = true;
     
        yield return new WaitForSeconds(3);
    
    }

    public IEnumerator Die2()
    {
        print("fuck");
        isrunning = true;
        yield return new WaitForSeconds(3);
        isrunning = false;
        print("off");
        death();

    }
    void death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
