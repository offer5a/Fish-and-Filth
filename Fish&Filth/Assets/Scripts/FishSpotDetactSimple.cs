using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{


    //[SerializeField] private GameObject Capsule;
    [SerializeField] private GameObject Minigame1;
    [SerializeField] private GameObject Minigame2;

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

        int randomChoice = UnityEngine.Random.Range(0, 2);
        if (collision.CompareTag("Ship"))
        {

            if (randomChoice == 0)
            {
                Minigame1.SetActive(true);
                IsGameRunning = true;
            }
            else if (randomChoice == 1) 
            {
                Minigame2.SetActive(true);
                IsGameRunning = true;

            }
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            Minigame1.SetActive(false);
            Minigame2.SetActive(false);
            IsGameRunning = false;
        }

    }

}
