using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFishCount : MonoBehaviour
{
    public Text textObject;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fish")
        {
            count += count;
            textObject.text = "Fish Caught : " + count; 
        }
    }
}
