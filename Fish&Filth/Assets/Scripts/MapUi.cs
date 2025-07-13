using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUi : MonoBehaviour
{

    public GameObject map;
    public bool isopen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mapopen()
    {
        
        map.SetActive(true);
        
    }

    public void mapclose()
    {
       
            map.SetActive(false);


    }

}
