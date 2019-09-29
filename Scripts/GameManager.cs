using UnityEngine.SceneManagement;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public FirstPersonController firstPersonController;

    public PauseMenu pauseMenu;

    public bool gameHasEnded;

    public bool bookIsOnTable;

    public bool hasKey;

    public bool relicIsPlaced;

    public Text dialouge;

    public GameObject endGameGUI;

    public string mainMenuScene;

    public void Start() {
        firstPersonController.transform.Find("Capsule").gameObject.SetActive(false);
        dialouge.text = "";
        hasKey = false;
        bookIsOnTable = false;
        relicIsPlaced = false;
        gameHasEnded = false;
    }

    public void Update() {

    }

    public void EndGame() {

        if (gameHasEnded == false) {
            Time.timeScale = 0f;
            relicIsPlaced = false;
            gameHasEnded = true;
            dialouge.text = "";
            endGameGUI.SetActive(true);
            firstPersonController.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.enabled = false;
        }

    }

    public void RestartGame() {
        Debug.Log("Restarting game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        firstPersonController.enabled = true;
        Time.timeScale = 1f;
    }

    public void LoadMainMenu() {
        Debug.Log("Loading menu");
        SceneManager.LoadScene(mainMenuScene);
        firstPersonController.enabled = true;
        Time.timeScale = 1f;

    }

    public void quitGame() {
        Application.Quit();
    }


}
