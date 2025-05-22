using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{


    //[SerializeField] private GameObject Capsule;
    [SerializeField] private GameObject Minigame1;

    public bool IsGameRunning;

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
        if (collision.CompareTag("Ship"))
        {
            Minigame1.SetActive(true);
            IsGameRunning = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            Minigame1.SetActive(false);
            IsGameRunning = false;
        }

    }

}
