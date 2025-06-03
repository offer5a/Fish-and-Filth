using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Docking : MonoBehaviour
{
    public bool isDocked = true;
    public bool nearDock = false;
    private Transform Ship;
    [SerializeField] private GameObject _shipsprits;

    void Start()
    {
        Ship = transform.parent; // Assuming player starts as child of boat
    }

    void Update()
    {
        // Press button to disembark (e.g. "E" key or UI button)
        if (nearDock && isDocked && Input.GetKeyDown(KeyCode.E))
        {
            Undock();
            _shipsprits.SetActive(false);            
        }

        if (!isDocked && nearDock && Input.GetKeyDown(KeyCode.E))
        {
            Dock();
            _shipsprits.SetActive(true);
        }

        // Optional: return to ship (you can reverse the logic later)
        // if (!isDocked && nearDock && Input.GetKeyDown(KeyCode.E)) { Dock(); }
    }

    void Undock()
    {
        transform.SetParent(null); // Detach from boat
        isDocked = false;

        // Optional: Enable player movement script, change layer, etc.
        GetComponent<PlayerMovement>().enabled = true;

        
        gameObject.layer = LayerMask.NameToLayer("Player");
        Debug.Log("Player has left the boat.");
    }

    void Dock()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dock"))
        {
            nearDock = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dock"))
        {
            nearDock = false;
        }
    }
}
