using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PausePanel;
  
    public void PauseButtonPressed()
     {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
     }

    public void ContinueButtonPressed()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    



}
