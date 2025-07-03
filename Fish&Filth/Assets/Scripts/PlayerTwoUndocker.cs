using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.UI.Image;

public class PlayerTwoUndocker : MonoBehaviour
{
    public GameObject BoardButton;
    private bool nearDock = false;
    public bool isOnLand;
    public GameObject Clone1;
    public GameObject Playerfab;
    //public CamSwitch camSwitcher;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject Ship;

    //public Transform DockLok;
    //public Transform  NewDockLok;


    public GameObject Cloner()
    {
        

        Clone1 = Instantiate(Playerfab, new Vector3(100, 72, -4), Quaternion.identity);
        return Clone1;
    }

    public void Awake()
    {
        
        //if(Time.frameCount <= 1)
        //{
        //    Clone = Instantiate(Playerfab, new Vector3(0, 12, -4), Quaternion.identity);
        //}
        
        



    }


    


    public void SetNearDock(bool value)
    {
        nearDock = value;
    }
    
    public void Undock()
    {
        if (!nearDock)
        {
            Debug.Log("Cannot undock: not near dock.");
            return;
        }

        // Detach from ship
        transform.SetParent(null);
        //transform.position += new Vector3(1f, 0, 0);
        
        // Enable movement script
        var move = GetComponent<PlayerMovement>();
        if (move != null)
        {
            move.enabled = true;
        }

        
        //GameObject clone = Instantiate(Playerfab);
        Clone1 = Instantiate(Playerfab, new Vector3(100, 72, -4), Quaternion.identity);


        //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;



        //Debug.Log("Player undocked and can move.");

        isOnLand = true;
        virtualCamera.Follow = Clone1.transform;
    }

    public void Dock()
    {

        if (Clone1 != null)
        {
            Destroy(Clone1);
            Clone1 = null;
        }

        virtualCamera.Follow = Ship.transform;

        isOnLand = false;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dock") || collision.CompareTag("Dock1") || collision.CompareTag("Dock2"))
            
        {
            if (BoardButton != null)
                BoardButton.SetActive(true);



            if (Clone1 != null)
                Clone1.GetComponent<PlayerUndocker>().SetNearDock(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dock") || collision.CompareTag("Dock1") || collision.CompareTag("Dock2"))
        {
            if (BoardButton != null)
                BoardButton.SetActive(false);

            if (Clone1 != null)
                Clone1.GetComponent<PlayerUndocker>().SetNearDock(false);


        }

    }
    
}
