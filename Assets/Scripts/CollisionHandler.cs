 using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;
    bool isTransiting;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isTransiting = false;
    }
    void OnCollisionEnter(Collision other)
    {
        if(isTransiting) {return;}
        switch (other.gameObject.tag)
        {
            case("Respawn"):
                Debug.Log("Start");
               // audioSource.PlayOneShot(audioClip);
                break;
            case("Obstacle1"):
                Debug.Log("obstackle1");
                isTransiting = true;
                audioSource.PlayOneShot(audioClip);
                GetComponent<Movement>().enabled = false;
                Invoke("ReloadLevel",2);
                break;
            case "Finish":
                isTransiting = true;
                LoadNextLevel();
                break;
            case "Fuel":
                isTransiting = true;
                ReloadLevel();
                break;
            default:
                ReloadLevel();
                break;    
        }
    }
    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel(){
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == SceneManager.sceneCountInBuildSettings-1){
            SceneManager.LoadScene(0);
        }else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
