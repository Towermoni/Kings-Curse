using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    
    public string mainMenuScene;

    public GameObject pauseMenuUI;

    public FirstPersonController firstPersonController;

    private void Start() {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //firstPersonController.GetComponentInChildren<MouseLook>().enabled = true;
        firstPersonController.GetComponent<FirstPersonController>().enabled = true;
        firstPersonController.GetComponentInChildren<DoorDetectionLite>().CrosshairPrefabInstance.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause() {
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //firstPersonController.GetComponentInChildren<MouseLook>().enabled = false;
        firstPersonController.GetComponent<FirstPersonController>().enabled = false;
        firstPersonController.GetComponent<DoorDetectionLite>().CrosshairPrefabInstance.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
        Cursor.visible = true;
    }
}
