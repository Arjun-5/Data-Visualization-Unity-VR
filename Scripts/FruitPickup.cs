using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPickup : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider fruitBasketCollider;
    void Awake()
    {
        fruitBasketCollider = gameObject.GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pear_Fruit")
        {
            ReadDataSet.updatedDataSet["UK"] = false;
        }
        else if(other.gameObject.tag == "Apple_Fruit")
        {
            ReadDataSet.updatedDataSet["Japan"] = false;
        }
        else if (other.gameObject.tag == "Orange_Fruit")
        {
            ReadDataSet.updatedDataSet["Malaysia"] = false;
        }
        else if (other.gameObject.tag == "Kiwi_Fruit")
        {
            ReadDataSet.updatedDataSet["SA"] = false;
        }
        else if (other.gameObject.tag == "Avocado_Fruit")
        {
            ReadDataSet.updatedDataSet["USA"] = false;
        }
    }
}
