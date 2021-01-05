using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StopLine : MonoBehaviour
{
    public GameObject lineRenderObject;
    public GameObject ParentObject;
    public Slider HitValue;
    public GameObject LRDest;
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
        if(other.tag == "Fish")
        {
            lineRenderObject.GetComponent<DrawFishingLine>().enabled = false;
            lineRenderObject.GetComponent<DrawFishingLine>().destination = LRDest.transform;
            other.gameObject.transform.position = ParentObject.transform.position;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<ActionPostFishing>().enabled = false;
            other.gameObject.GetComponent<Moving_Fish>().enabled = false;
            other.gameObject.GetComponent<Animator>().enabled = false;
            other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            other.gameObject.transform.parent = ParentObject.transform;
            HitValue.GetComponent<FillHit>().enabled = false;
            HitValue.GetComponent<Slider>().value = 0;
            HitValue.GetComponent<FillHit>().currentTimer = 0;
        }
    }
}
