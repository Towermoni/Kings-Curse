using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGatePanels : MonoBehaviour
{


    public GameObject gate;

    public GameObject trig;

    public Text dialouge;

    private AudioClip audioClip;
    private AudioSource gateAudio;
    private bool isShut;
    

    private void Start()
    {
        gateAudio = GetComponent<AudioSource>();
        isShut = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!isShut)
        {
            gate.transform.Translate(Vector3.down * 10f);
            trig.gameObject.SetActive(false);
            gateAudio.Play();
            dialouge.text = "Sounds like the gate has reopened...";
            dialouge.gameObject.SetActive(true); // Enable the text so it shows
            StartCoroutine(delay());
            isShut = true;

        }
    }

    private IEnumerator delay()
    {

        yield return new WaitForSeconds(5f);
        dialouge.gameObject.SetActive(false);

    }



}
