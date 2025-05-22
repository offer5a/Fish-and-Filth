using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, .5f);

        if (Input.GetKeyDown(KeyCode.W))
        {
            InhertitanceTest Fishes = GetComponent<InhertitanceTest>();
            Debug.Log(Fishes.name);
        }
    }

}
