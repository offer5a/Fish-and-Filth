using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FishSpotDetactRare : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private GameObject Capsule;
    [SerializeField] private GameObject Minigame1;
    [SerializeField] private GameObject Minigame2;

    
    public bool IsGameRunning;
    public bool IsRareSpot;
    public GameObject norod;

    public GameObject drunkensailor;

    private async void OnTriggerEnter2D(Collider2D collision)
    {

        int randomChoice = UnityEngine.Random.Range(0, 2);

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
            if (hasRod && randomChoice == 0)
            {
                Minigame1.SetActive(true);
                IsGameRunning = true;
                IsRareSpot = true;

                drunkensailor.SetActive(true);
            }
            else if (hasRod &&  randomChoice == 1)
            {
                Minigame2.SetActive(true);
                IsGameRunning = true;
                IsRareSpot = true;

                drunkensailor.SetActive(true);
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
                Minigame2.SetActive(false);
                IsGameRunning = false;
                IsRareSpot = false;

            drunkensailor.SetActive(false);
        }

    }
}
