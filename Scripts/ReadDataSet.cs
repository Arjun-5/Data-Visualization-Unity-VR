using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReadDataSet : MonoBehaviour
{
    public CountriesList countries = new CountriesList();
    public GameObject Main_Player;
    private GameObject child;
    static protected bool loadedAlready = false;
    public static Dictionary<string, bool> updatedDataSet = new Dictionary<string, bool>();
    void Start()
    {
        if (loadedAlready == false)
        {
            TextAsset asset = Resources.Load("GlobeData") as TextAsset;
            if (asset != null)
            {
                countries = JsonUtility.FromJson<CountriesList>(asset.text);
                disableMapPins();
            }
            loadedAlready = true;
        }
        else
        {
            updatedMapPins();
        }
    } 
    void disableMapPins() 
    {
        foreach (FruitCountryRelation fcr in countries.FruitCountryRelation)
        {
            updatedDataSet.Add(fcr.Name, fcr.Locked);
            if (fcr.Name == "UK" && fcr.Locked == true)
            {
                child = Main_Player.transform.Find("Pin_UK").gameObject;
                child.SetActive(false);
            }
            else if (fcr.Name == "Japan" && fcr.Locked == true)
            {
                child = Main_Player.transform.Find("Pin_Japan").gameObject;
                child.SetActive(false);
            }
            else if (fcr.Name == "Malaysia" && fcr.Locked == true)
            {
                child = Main_Player.transform.Find("Pin_Malaysia").gameObject;
                child.SetActive(false);
            }
            else if (fcr.Name == "SA" && fcr.Locked == true)
            {
                child = Main_Player.transform.Find("Pin_SA").gameObject;
                child.SetActive(false);
            }
            else if (fcr.Name == "USA" && fcr.Locked == true)
            {
                child = Main_Player.transform.Find("Pin_USA").gameObject;
                child.SetActive(false);
            }
        }
    }
    void updatedMapPins()
    { 
        foreach (KeyValuePair<string, bool> myDictonaryEntry in updatedDataSet)
        {
            if (myDictonaryEntry.Key == "UK" && myDictonaryEntry.Value == true)
            {
                child = Main_Player.transform.Find("Pin_UK").gameObject;
                child.SetActive(false);
            }
            else if (myDictonaryEntry.Key == "Japan" && myDictonaryEntry.Value == true)
            {
                child = Main_Player.transform.Find("Pin_Japan").gameObject;
                child.SetActive(false);
            }
            else if (myDictonaryEntry.Key == "Malaysia" && myDictonaryEntry.Value == true)
            {
                child = Main_Player.transform.Find("Pin_Malaysia").gameObject;
                child.SetActive(false);
            }
            else if (myDictonaryEntry.Key == "SA" && myDictonaryEntry.Value == true)
            {
                child = Main_Player.transform.Find("Pin_SA").gameObject;
                child.SetActive(false);
            }
            else if (myDictonaryEntry.Key == "USA" && myDictonaryEntry.Value == true)
            {
                child = Main_Player.transform.Find("Pin_USA").gameObject;
                child.SetActive(false);
            }
        }
    }
}