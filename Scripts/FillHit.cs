using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FillHit : MonoBehaviour
{
    private float timerValue;
    public float currentTimer;
    public GameObject LineDestination;
    public bool fillComplete;
    // Start is called before the first frame update
    void Start()
    {
        //Get the current Slider Value - Has to be Zero
        timerValue = GetComponent<Slider>().value;
        currentTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //If the Slider Value is not equal to 1 increase the timer value 
        if(currentTimer != 1 && LineDestination.GetComponent<Catching_Fish>().fishCaught == true)
        {
            if (Input.GetKeyDown(KeyCode.O) || OVRInput.GetDown(OVRInput.Button.Two))
            {
                currentTimer += 0.05f;
            }
            GetComponent<Slider>().value = currentTimer;
        }
        //If the current timer Value is greater than 1 set the value of two bool Variables to True
        if(currentTimer >= 1)
        {
            LineDestination.GetComponent<Catching_Fish>().task_Complete = true;
            LineDestination.GetComponent<Catching_Fish>().hit = true;
        }
    }
}
