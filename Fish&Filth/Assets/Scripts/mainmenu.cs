using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit"); //check
    
    }
}
