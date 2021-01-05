using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeAudioTrigger : MonoBehaviour
{
    public AudioSource music_Source;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainPlayer")
        {
            music_Source.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "MainPlayer")
        {
            music_Source.Stop();
        }
    }
}
