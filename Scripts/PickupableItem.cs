using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickupableItem : MonoBehaviour  
{

    public Text itemPickupText;

    private void OnMouseEnter() {
        itemPickupText.gameObject.SetActive(true);
        itemPickupText.text = "Click to pickup " + this.gameObject.name;
    }

    private void OnMouseOver() {
        itemPickupText.gameObject.SetActive(true);
    }

    private void OnMouseExit() {
        itemPickupText.gameObject.SetActive(false);
    }
}
