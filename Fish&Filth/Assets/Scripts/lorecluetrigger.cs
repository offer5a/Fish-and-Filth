using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lorecluetrigger : MonoBehaviour

    
{

    public GameObject lore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            lore.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            lore.SetActive(false);  
        }
    }
}
