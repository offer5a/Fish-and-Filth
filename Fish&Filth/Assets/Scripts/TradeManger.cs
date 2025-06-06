using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class tradeoffer
{

    public string requiredItemName;
    public int requiredAmount;
    public Item rewardItem;

}
public class TradeManger : MonoBehaviour
{
    public GameObject Board;
    public tradeoffer trade;

    private void Start()
    {
        trade = new tradeoffer
        {
            requiredItemName = "cod",
            requiredAmount = 3,
            rewardItem = new Item("Rod")

        };



    }
    public GameObject yestrade;
    public GameObject notrade;

    public async void AttemptTrade()
    {
        Inventory inventory = Inventory.Instance;
        int fishCount = 0;

        // Count how many Fish the player has
        foreach (Item item in inventory.items)
        {
            if (item.itemName == trade.requiredItemName)
                fishCount++;
        }

        if (fishCount >= trade.requiredAmount)
        {
            // Remove required amount of Fish
            int removed = 0;
            for (int i = inventory.items.Count - 1; i >= 0 && removed < trade.requiredAmount; i--)
            {
                if (inventory.items[i].itemName == trade.requiredItemName)
                {
                    inventory.items.RemoveAt(i);
                    removed++;
                }
            }

            // Add the reward item
            
            inventory.AddItem(trade.rewardItem);
            //Debug.Log($"Trade successful! Gave {trade.requiredAmount} {trade.requiredItemName}(s) for a {trade.rewardItem.itemName}.");
            yestrade.SetActive(true);
            await Task.Delay(5000);
            yestrade.SetActive(false);

        }
        else
        {
            //Debug.Log("Not enough items to trade.");
            notrade.SetActive(true);
            await Task.Delay(3000);
            notrade.SetActive(false);
        }


        
}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
          {
            Board.SetActive(true);
          }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Board.SetActive(false);
        }
    }
}
