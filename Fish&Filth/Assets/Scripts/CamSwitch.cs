using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform ship;
    public Transform player;

    public void FollowPlayer()
    {
        virtualCamera.Follow = player;
    }

    public void FollowShip()
    {
        virtualCamera.Follow = ship;
    }
}
