using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Threading.Tasks;


public class MinigameManager : MonoBehaviour
{

    [SerializeField] Transform TopPivot;
    [SerializeField] Transform BottomPivot;
    [SerializeField] Transform Player;
    [SerializeField] Transform Goal;
    [SerializeField] GameObject Minigame;
    [SerializeField] GameObject RareSpot;
    [SerializeField] private InhertitanceTest fish;

    public string Simplefish;

    

    public bool IsGameRunning;

    public Button Button;

    float BarPos;
    float BarDes;

    int WinPoints = 0;
    int LosePoints = 0;

    float BarTimer;
    [SerializeField] float TimeMult = 3f;

    float BarSpeed;
    [SerializeField] float Speed;
    

    float smoothMotion = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoalCheck", 2f);
    }

    // Update is called once per frame
    async void Update()
    {
        Inventory inventory = Inventory.Instance;
        bool hasRod = false;
        foreach (Item item in inventory.items)
        {
            if (item.itemName == "Rod")
            {
                hasRod = true;
                break;
            }
        }




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

        

        Player.position = Vector3.Lerp(BottomPivot.position, TopPivot.position, LerpValue);

        



        if (WinPoints >= 2)
        {
            //recives fish
            Debug.Log("win");
            Minigame.SetActive(false);

            if(RareSpot.GetComponent<FishSpotDetactRare>().IsRareSpot == false)
            {
                GiveReward();
            }
            else if(hasRod == true && RareSpot.GetComponent<FishSpotDetactRare>().IsRareSpot == true)
            {
                GiveRewardRarerFish();
            }
            

            IsGameRunning = false;

            
        }
        else if (LosePoints >= 2)
        {
            // dont recives fish
            Debug.Log("lose");
            Minigame.SetActive(false);
            IsGameRunning = false;

            failText.SetActive(true);
            await Task.Delay(3000);
            failText.SetActive(false);

        }
        else
        {
            IsGameRunning = true;
        }

        if (IsGameRunning == false)
        {
            WinPoints = 0;
            LosePoints = 0;
        }

    }

    
    

    public Collider2D Green;
    
    public Collider2D PlayerBar1;
    
    public GameObject failball;
    public GameObject successball;
    public GameObject codtext;
    public GameObject opentext;
    public GameObject failText;

        


    public async void miniGame()
    {
        if (Green.bounds.Intersects(PlayerBar1.bounds))
        {

            Debug.Log("Point Added");
            WinPoints++;
            successball.SetActive(true);
            await Task.Delay(1200);
            successball.SetActive(false);



        }
        else
        {
            Debug.Log("Point Removed");
            LosePoints++;
            failball.SetActive(true);
            await Task.Delay(1200);
            failball.SetActive(false);

        }
    }


    async void GiveReward()
    {

        Item reward = new Item("cod");
            bool added = Inventory.Instance.AddItem(reward);


            if (added)
            {
                Debug.Log("Minigame completed! Reward given: " + reward.itemName);
            codtext.SetActive(true);
            await Task.Delay(3000);
            codtext.SetActive(false);
            
            }
            
        
        
        
    }
    async void GiveRewardRarerFish()
    {
        Item reward = new Item("Open Fish");
        bool added = Inventory.Instance.AddItem(reward);
        if (added)
        {
            Debug.Log("Minigame completed! Reward given: " + reward.itemName);
            opentext.SetActive(true);
            await Task.Delay(3000);
            opentext.SetActive(false);
        }
    }

}


