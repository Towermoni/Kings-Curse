using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShutGate : MonoBehaviour
{
    
    public GameObject gate;



    public AudioClip audioClip;
    public AudioSource gateAudio;
    public bool isShut;

    
    // Start is called before the first frame update
    void Start()
    {
        gateAudio = GetComponent<AudioSource>();
        isShut = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isShut)
        {
            gate.transform.Translate(Vector3.up * 10f);
            gateAudio.Play();
            isShut = true;
        }
        
    }

}
