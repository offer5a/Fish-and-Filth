using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DockDetect : MonoBehaviour
{

    public GameObject undockButton;
    public GameObject playerObject;
    [SerializeField] private GameObject _shipshpritz;
    // Start is called before the first frame update

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dock"))

        {
            if (undockButton != null)
                undockButton.SetActive(true);

            if (playerObject != null)
                playerObject.GetComponent<PlayerUndocker>().SetNearDock(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dock"))
        {
            if (undockButton != null)
                undockButton.SetActive(false);

            if (playerObject != null)
                playerObject.GetComponent<PlayerUndocker>().SetNearDock(false);
            

        }
        
    }

    public void stopShip()
    {
        if (playerObject.GetComponent<PlayerUndocker>().isOnLand == true)
        {
            var move = GetComponent<PlayerMovement>();
           
            if (move != null)
            {
                move.enabled = false;
            }

           
            undockButton.SetActive(false);
            _shipshpritz.SetActive(false);

        }
        else if(playerObject.GetComponent<PlayerUndocker>().isOnLand == false)
        {
            var move = GetComponent<PlayerMovement>();
            
            if (move != null)
            {
                move.enabled = true;
            }
            _shipshpritz.SetActive(true);
        }

    }
}
