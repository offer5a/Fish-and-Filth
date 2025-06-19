using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.UI.Image;

public class PlayerUndocker : MonoBehaviour
{
    public GameObject BoardButton;
    private bool nearDock = false;
    public bool isOnLand;
    public GameObject Clone;
    public GameObject Playerfab;
    //public CamSwitch camSwitcher;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject Ship;

    public GameObject Cloner()
    {
        Clone = Instantiate(Playerfab, new Vector3(0, 12, -4), Quaternion.identity);
        return Clone;
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
        Clone = Instantiate(Playerfab, new Vector3(0, 12, -4), Quaternion.identity);


        //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;



        //Debug.Log("Player undocked and can move.");

        isOnLand = true;
        virtualCamera.Follow = Clone.transform;
    }

    public void Dock()
    {

        virtualCamera.Follow = Ship.transform;
        //transform.localPosition = Vector3.zero;

        Destroy(Clone);

        isOnLand = false;
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dock"))

        {
            if (BoardButton != null)
                BoardButton.SetActive(true);

            if (Clone != null)
                Clone.GetComponent<PlayerUndocker>().SetNearDock(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dock"))
        {
            if (BoardButton != null)
                BoardButton.SetActive(false);

            if (Clone != null)
                Clone.GetComponent<PlayerUndocker>().SetNearDock(false);


        }

    }
}
