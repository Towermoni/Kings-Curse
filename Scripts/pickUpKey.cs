using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUpKey : MonoBehaviour
{

    public GameObject closedDoor;
    public GameObject openedDoor;
    public GameObject key;

    public Camera playerCamera;

    public string objectMask;

    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ViewportPointToRay(Vector3.one / 2f);
        LayerMask mask = LayerMask.GetMask(objectMask);

        if (Physics.Raycast(ray, out hit, 10f, mask))
        {
            if (hit.collider.tag == "Key")

                if (Input.GetKey(KeyCode.E))
                {
                    key.gameObject.gameObject.SetActive(false);
                    closedDoor.gameObject.SetActive(false);
                    openedDoor.gameObject.SetActive(true);
                }
            
        }
    }

}
