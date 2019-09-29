using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
 
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
