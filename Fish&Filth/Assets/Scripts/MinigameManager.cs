using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading;

public class MinigameManager : MonoBehaviour
{

    [SerializeField] Transform TopPivot;
    [SerializeField] Transform BottomPivot;
    [SerializeField] Transform PlayerBar;

    float BarPos;
    float BarDes;

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
        BarTimer -= Time.deltaTime;
        if (BarTimer > 0)
        {
            //BarTimer = UnityEngine.Random.value * TimeMult;

           // BarDes = UnityEngine.Random.value;
        }

        BarPos = Mathf.SmoothDamp(BarPos, BarDes, ref Speed, smoothMotion);
        PlayerBar.position = Vector3.Lerp(BottomPivot.position, TopPivot.position, BarPos);
        PlayerBar.position = Vector3.Lerp(TopPivot.position, BottomPivot.position, BarPos);
    }
}
