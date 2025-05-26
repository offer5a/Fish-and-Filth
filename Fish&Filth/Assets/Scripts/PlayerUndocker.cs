using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerUndocker : MonoBehaviour
{
    private bool nearDock = false;
    public bool isOnLand;
    public GameObject Playerfab;
    //public CamSwitch camSwitcher;
    public CinemachineVirtualCamera virtualCamera;



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
       GameObject Clone = Instantiate(Playerfab, new Vector3(0, 12, -4), Quaternion.identity);


        //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        

        //Debug.Log("Player undocked and can move.");

        isOnLand = true;
        virtualCamera.Follow = Clone.transform;
    }
}
