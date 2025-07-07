using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class LadyInterafct : MonoBehaviour
{


    public GameObject QuestText1;
    public GameObject QuestID1;
    public GameObject QuestID2;
    public GameObject SuccessText2;
    private bool RewardItem;
    public class tradeoffer
    {

        public string requiredItemName;
        
        public Item rewardItem;


    }
    public tradeoffer LadyCheck;
    private void Start()
    {
        LadyCheck = new tradeoffer
        {
            requiredItemName = "SonItem",
            
            //rewardItem = new Item("Rod")

        };


    }

    public void Update()
    {
        Inventory inventory = Inventory.Instance;
        

        foreach (Item item in inventory.items)
        {
            if (item.itemName == LadyCheck.requiredItemName)
            {
                RewardItem = true;
            }
                
        }
    }

    private async void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (RewardItem == true)
            {
                QuestID2.SetActive(false);


                SuccessText2.SetActive(true);
                await Task.Delay(3000);
                SuccessText2.SetActive(false);
                
            }

            else
            {
                QuestText1.SetActive(true);
                await Task.Delay(3000);
                QuestText1.SetActive(false);

                QuestID1.SetActive(true);

            }
        }
    }
}
