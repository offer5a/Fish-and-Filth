using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{

    public GameObject invpanel;

    public void PusedPressed()
    {
        invpanel.SetActive(true);
    }
    public void CancelPressed()
    {
        invpanel.SetActive(false);
    }
}
