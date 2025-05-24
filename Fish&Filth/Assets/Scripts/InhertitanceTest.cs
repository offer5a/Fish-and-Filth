using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InhertitanceTest : MonoBehaviour 
{
    public string simplefish;
    public string Simplefish()
    {
        return simplefish;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class Fish
    {
        public static string name;
        public static string type;


        //public int Value;
    }

    public class cod : Fish
    {
        public cod()
        {
            name = "cod";
            type = "Normal Fish";
            
        }
    }
    

}
