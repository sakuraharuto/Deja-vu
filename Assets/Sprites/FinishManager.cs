using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{   
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){

            Debug.Log("You win");

            //Play effect
            finishEffect.Play();
            //Play SFX
            GetComponent<AudioSource>().Play();

            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }

}
