using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetect : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Wall" && !hasCrashed){
            Debug.Log("Bonk");
            hasCrashed = true;

            //Disable control
            FindObjectOfType<Car>().DisableControl();

            //Play Effect
            crashEffect.Play();

            //Play SFX
            GetComponent<AudioSource>().PlayOneShot(crashSFX);

            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }

}
