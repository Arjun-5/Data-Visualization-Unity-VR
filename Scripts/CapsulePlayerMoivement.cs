using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePlayerMoivement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * 10;
        } 
     else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * 10;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * 10;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * 10;
        }
    }
}
