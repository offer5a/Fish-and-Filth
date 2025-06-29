using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.UI.Image;

public class SecondMinigame : MonoBehaviour
{

    public Rigidbody2D Fish;
    public Collider2D fishHitbox;
    public Transform FishPlace;
    public Transform Place;

    public Collider2D BottomCollider;
    public Collider2D TopCollider;

    public GameObject Game;
    public GameObject Win;
    public GameObject Fail;

    public void fishUp()
    {
        Fish.velocity = new Vector3(0, 60, 0);
    }

    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    async void Update()
    {
        if (fishHitbox.bounds.Intersects(TopCollider.bounds))
        {
            Debug.Log("Point Added");

            Game.SetActive(false);

            Win.SetActive(true);
            await Task.Delay(1200);
            Win.SetActive(false);

            

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
