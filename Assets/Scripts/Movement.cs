using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float sensRotation = 0.1f;
    [SerializeField] AudioClip audioClip;
    Rigidbody rb;
    AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey(KeyCode.Space))
        {
            if(!sound.isPlaying)
            {
                sound.PlayOneShot(audioClip);
            }
            
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else
        {
            sound.Stop();
        }
        ProcessRotation();
    }
    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(sensRotation);
        }else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-sensRotation);
        }
    }
    void ApplyRotation(float sensRotation){
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * sensRotation);
        rb.freezeRotation = false;
    }
}
