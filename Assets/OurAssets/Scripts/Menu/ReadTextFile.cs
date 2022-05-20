using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReadTextFile : MonoBehaviour
{
    public TextAsset textAssetsName;

    public string[] names;

    // Start is called before the first frame update
    void Start()
    {
        ReadTextAssets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadTextAssets()
    {
        names = textAssetsName.text.Split(new string[] {"<" }, StringSplitOptions.None);
    }
}
