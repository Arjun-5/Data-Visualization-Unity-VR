using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGame : MonoBehaviour
{
    private float timerValue;
    private float currentTimer;
    public bool timeOver;
    // Start is called before the first frame update
    void Start()
    {
        timerValue = GetComponent<Slider>().value;
        currentTimer = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timerUpdate();
    }
    void timerUpdate()
    {
        currentTimer -= Time.deltaTime;
        if (timerValue != 0)
        {
            GetComponent<Slider>().value = currentTimer;
        }
        if(timerValue == 0)
        {
            timeOver = true;
        }
    }
}
