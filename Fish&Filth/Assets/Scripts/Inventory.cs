using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance;

    public List<Item> items = new List<Item>();
    public int capacity = 10;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(Instance);
    }

    public bool AddItem(Item newItem)
    {
        if (items.Count >= capacity)
        {
            Debug.Log("Inventory full!");
            return false;
        }

        items.Add(newItem);
        Debug.Log("Item added: " + newItem.itemName);
        return true;
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log("Item removed: " + item.itemName);
        }
    }
    // Update is called once per frame
    public void PrintInventory()
    {
        Debug.Log("Inventory Contents:");
        foreach (Item item in items)
        {
            Debug.Log("- " + item.itemName);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PrintInventory();
        }

    }
}
