using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePuzzle : MonoBehaviour
{
    public GameObject replacementBook;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        replacementBook.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Book") {
            other.gameObject.SetActive(false);
            replacementBook.SetActive(true);
            gameManager.bookIsOnTable = true;
        }
    }
}
