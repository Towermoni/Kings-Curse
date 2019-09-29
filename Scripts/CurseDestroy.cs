using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CurseDestroy : MonoBehaviour
{

    public ParticleSystem curse;
    public GameManager gameManager;
    public Transform finalRelicPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Relic" && gameManager.bookIsOnTable == true)
        {
            other.attachedRigidbody.isKinematic = true;
            other.attachedRigidbody.useGravity = false;
            other.transform.parent = finalRelicPos;
            other.transform.position = finalRelicPos.position;
            other.transform.rotation = finalRelicPos.rotation;
            other.transform.Rotate(-90, 0, 0);
            gameManager.relicIsPlaced = true;
            curse.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            StartCoroutine(Done());   
        }

    }

    public IEnumerator Done() {
        yield return new WaitForSeconds(5f);       
        gameManager.EndGame();
    }
}
