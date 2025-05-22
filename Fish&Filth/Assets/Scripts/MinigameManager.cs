using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{

    [SerializeField] Transform TopPivot;
    [SerializeField] Transform BottomPivot;
    [SerializeField] Transform PlayerBar;
    [SerializeField] Transform Goal;
    [SerializeField] GameObject Minigame;
    public Button Button;

    float BarPos;
    float BarDes;

    int WinPoints =0;
    int LosePoints = 0;

    float BarTimer;
    [SerializeField] float TimeMult = 3f;

    float BarSpeed;
    [SerializeField] float Speed;

    float smoothMotion = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BarPos += Time.deltaTime;
        BarTimer -= Time.deltaTime;
        if (BarTimer > 0)
        {
            //BarTimer = UnityEngine.Random.value * TimeMult;

           // BarDes = UnityEngine.Random.value;
        }

        //BarPos = Mathf.SmoothDamp(BarPos, BarDes, ref Speed, smoothMotion);
        //BarPos = Speed * TimeMult;
        //IsGameRunning = GetComponent<bool>("Isgamerunning");
        //while (GetComponent<float>("Isgamerunning"))
        //{

        //}

        //if (PlayerBar.position == BottomPivot.position)
        //{
        //    PlayerBar.position = Vector3.Lerp(BottomPivot.position, TopPivot.position, BarPos);
        //}
        //PlayerBar.position = Vector3.Lerp(BottomPivot.position, TopPivot.position, BarPos);

        //PlayerBar.position = Vector3.Lerp(TopPivot.position, BottomPivot.position, BarPos);

        //PlayerBar.position = Vector3.MoveTowards(BottomPivot.position, TopPivot.position, BarPos);

        float LerpValue = Mathf.PingPong(Time.time * Speed, 1f);
        PlayerBar.position = Vector3.Lerp(BottomPivot.position, TopPivot.position, LerpValue);


        if (WinPoints >= 2)
        {
            //recives fish
            Debug.Log("win");
            Minigame.SetActive(false);
        }
        else if (LosePoints >= 2)
        {
            // dont recives fish
            Debug.Log("lose");
            Minigame.SetActive(false);
        }

    }


    public Collider2D Green;
    public Collider2D Player;
    public void GoalCheck()
    {
        if (Green.bounds.Intersects(Player.bounds))
        {
            Debug.Log("Point Added");
            WinPoints++;
        }
        else
        {
            Debug.Log("Point Removed");
            LosePoints++;
        }
    }
        
    
    
}
