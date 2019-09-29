using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougePrompt : MonoBehaviour
{

    public string objectMask;

    public Text dialouge;

    public Camera playerCamera;

    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ViewportPointToRay(Vector3.one / 2f);
        LayerMask mask = LayerMask.GetMask(objectMask);

        if (Physics.Raycast(ray, out hit, 10f, mask)) {

            if (gameManager.bookIsOnTable == false) {
                if (hit.collider.name == "BookTable") {
                    dialouge.text = "There's a gap between the books. Perhaps there is a book missing?";
                } 
            } else {
                dialouge.text = "The completed collection has weakened the curse. I need to get to the courtyard.";
            }

            if (gameManager.gameHasEnded == false) {
                if (hit.collider.name == "Fountain") {
                    dialouge.text = "The curse is too strong to destroy, I need to weaken it with a completed collection of curse dogmas.";
                }
                else if (hit.collider.name == "Gate") {
                    dialouge.text = "Rude... There must be some sort of mechanism that will open this back up.";
                }
            }  else {
                if (hit.collider.name == "Fountain") {
                    dialouge.text = "";
                }
            }

            if (gameManager.gameHasEnded == false && gameManager.bookIsOnTable == true) {
                if (hit.collider.name == "Fountain") {
                    dialouge.text = "The cursed magic coming from this fountain needs to be destroyed with an ancient relic located somewhere in this courtyard.";
                }
            }

            if (gameManager.hasKey == false) {
                if (hit.collider.tag == "Key") {
                    dialouge.text = "Press E to pick up Key";
                }
                else if (hit.collider.tag == "Locked")
                {
                    dialouge.text = "Door is locked, need to find a key...";
                }
            }



            dialouge.gameObject.SetActive(true);

        } else {
            dialouge.gameObject.SetActive(false);
        }

        if (gameManager.relicIsPlaced == true) {
            dialouge.text = "Be gone foul curse!";
        }
    }
}
