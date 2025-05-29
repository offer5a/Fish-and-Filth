using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FishSpotDetactRare : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private GameObject Capsule;
    [SerializeField] private GameObject Minigame1;
    
    public bool IsGameRunning;
    public bool IsRareSpot;
    public GameObject norod;
  

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = Inventory.Instance;
        if (collision.CompareTag("Ship"))
        {
            bool hasRod = false;
            foreach (Item item in inventory.items)
            {
                if (item.itemName == "Rod")
                {
                    hasRod = true;
                    break;
                }
            }
            if (hasRod)
            {
                Minigame1.SetActive(true);
                IsGameRunning = true;
                IsRareSpot = true;
            }
            else 
            {
               // Debug.Log("You Dont Have Rod!!");
                norod.SetActive(true);
                await Task.Delay(3000);
                norod.SetActive(false);

                    }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            Minigame1.SetActive(false);
            IsGameRunning = false;
            IsRareSpot=false;
        }

    }
}
