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
    public Button Button;

    float BarPos;
    float BarDes;

    int Points =0;

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

    }

    public void GoalCheck()
    {
        if (PlayerBar.position == Goal.position)
        {
            Debug.Log(Points++);
        }
        else if (PlayerBar.position != Goal.position)
        {
            Debug.Log(Points--);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            Debug.Log(Points++);
        }
        
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            Debug.Log(Points--);
        }
    }
}
