using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.UI.Image;

public class SecondMinigame : MonoBehaviour
{

    public GameObject RareSpot;

    public Rigidbody2D Fish;
    public Collider2D fishHitbox;
    public Transform FishPlace;
    public Transform Place;

    public Collider2D BottomCollider;
    public Collider2D TopCollider;

    public GameObject Game;
    public GameObject Win;
    public GameObject Win2;
    public GameObject Fail;

    public void fishUp()
    {
        Fish.velocity = new Vector3(0, 200, 0);
    }

    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    async void Update()
    {
        Inventory inventory = Inventory.Instance;

        if (fishHitbox.bounds.Intersects(TopCollider.bounds))
        {
            
            if (RareSpot.GetComponent<FishSpotDetactRare>().IsRareSpot == false)
            {
                Debug.Log("Point Added");

                Game.SetActive(false);

                Item reward = new Item("cod");
                bool added = Inventory.Instance.AddItem(reward);

                Win.SetActive(true);
                await Task.Delay(1200);
                Win.SetActive(false);


            }



            else if (RareSpot.GetComponent<FishSpotDetactRare>().IsRareSpot == true)
            {
                Debug.Log("Point Added");

                Game.SetActive(false);

                Item reward = new Item("Open Fish");
                bool added = Inventory.Instance.AddItem(reward);

                Win2.SetActive(true);
                await Task.Delay(1200);
                Win2.SetActive(false);


            }


            FishPlace.transform.position = Place.position;
        }


        else if (fishHitbox.bounds.Intersects(BottomCollider.bounds))
        {
            Debug.Log("Point Removed");

            Game.SetActive(false);

            Fail.SetActive(true);
            await Task.Delay(1200);
            Fail.SetActive(false);

            
            FishPlace.transform.position = Place.position;
        }
    }
    
    
}
