using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Camera mainCamera;

    public LayerMask layerMask;

    public GameObject guide;

    private GameObject itemBeingPickedUp;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            SelectItemBeingPickedUpFromRay();
           
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1)) { 
            PutItemDown();
        }
    }

    private void SelectItemBeingPickedUpFromRay() {
        //
        // DONT DELETE - OTHER WAYS TO CREATE A RAY
        //
        //Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 10f, layerMask)) {
            var hitItem = hitInfo.collider.gameObject;
            if (hitItem == null) {
                itemBeingPickedUp = null;
            }
            else if (hitItem != null && hitItem != itemBeingPickedUp) {
                itemBeingPickedUp = hitItem;
                if (itemBeingPickedUp != null) {
                    SetNewTransform();
                }
            }
        }
        else {
            itemBeingPickedUp = null;
        }
    }

    private void SetNewTransform() {
        itemBeingPickedUp.GetComponent<Rigidbody>().isKinematic = true;
        itemBeingPickedUp.GetComponent<Rigidbody>().useGravity = false;
        itemBeingPickedUp.transform.SetParent(guide.transform, false);
        itemBeingPickedUp.transform.position = guide.transform.position;
        itemBeingPickedUp.transform.rotation = guide.transform.rotation;

        if (itemBeingPickedUp.tag == "Relic") {
            itemBeingPickedUp.transform.Rotate(-90, 90, 0);
        }
    }

    private void PutItemDown() {
        if (itemBeingPickedUp == null) {
            return;
        }
        else {
            itemBeingPickedUp.GetComponent<Rigidbody>().useGravity = true;
            itemBeingPickedUp.GetComponent<Rigidbody>().isKinematic = false;
            itemBeingPickedUp.transform.parent = null;
            itemBeingPickedUp.transform.position = guide.transform.position;
            itemBeingPickedUp = null;
        }
    }
}
