using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewDiary : MonoBehaviour
{
    public new Camera camera;

    private GameObject itemBeingPickedUp;
    // Start is called before the first frame update
    [Header("GUI References")]
    public RectTransform noteScreen;

    public Text diaryPage;
    public Text diaryPage2;
    public Text diaryPage3;
    public Text diaryPage4;
    public Text diaryPage5;

    public RectTransform viewDiaryText;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);
        LayerMask mask = LayerMask.GetMask("Wall");
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);


        if (Physics.Raycast(ray, out hit, 5f, mask) && !Input.GetKey(KeyCode.E))
        {
            viewDiaryText.gameObject.SetActive(true);
            noteScreen.gameObject.SetActive(false);
            diaryPage.gameObject.SetActive(false);
            diaryPage2.gameObject.SetActive(false);
            diaryPage3.gameObject.SetActive(false);
            diaryPage4.gameObject.SetActive(false);
            diaryPage5.gameObject.SetActive(false);
        }
        else if (Physics.Raycast(ray, out hit, 5f, mask) && Input.GetKey(KeyCode.E))
        {
            viewDiaryText.gameObject.SetActive(false);
            noteScreen.gameObject.SetActive(true);
            if (hit.collider.name == "Diary01")
            {
                diaryPage.gameObject.SetActive(true);
            }
            else if (hit.collider.name == "Diary02")
            {
                diaryPage2.gameObject.SetActive(true);
            }
            else if (hit.collider.name == "Diary03")
            {
                diaryPage3.gameObject.SetActive(true);
            }
            else if (hit.collider.name == "Diary04")
            {
                diaryPage4.gameObject.SetActive(true);
            }
            else if (hit.collider.name == "Diary05")
            {
                diaryPage5.gameObject.SetActive(true);
            }

            
        }
        else
        {

            viewDiaryText.gameObject.SetActive(false);
            noteScreen.gameObject.SetActive(false);
            diaryPage.gameObject.SetActive(false);
        }

    }

}
