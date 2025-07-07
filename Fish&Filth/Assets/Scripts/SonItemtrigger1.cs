using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SonItemtrigger : MonoBehaviour

    
{

    public GameObject lore;
    public GameObject LoreItem;
    public GameObject QuestID1;
    public GameObject QuestID2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void OnTriggerEnter2D(Collider2D collision)
    {

        Inventory inventory = Inventory.Instance;

        if (collision.CompareTag("Player"))
        {
            Item SonItem = new Item("SonItem");
            bool added = Inventory.Instance.AddItem(SonItem);

            lore.SetActive(true);
            await Task.Delay(3000);
            lore.SetActive(false);

            Destroy(LoreItem);
            QuestID1.SetActive(false);
            QuestID2.SetActive(true);
        }
        
    }
    
}
