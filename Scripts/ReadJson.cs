using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ReadJson : MonoBehaviour

{
    public CountryProfitList countryProfit = new CountryProfitList();
    public DataList data = new DataList();
    public TripProfitList tripProfit = new TripProfitList();
    public List<DataSet> days = new List<DataSet>();
    public int num_days;
    public GameObject weather;
    public DataSet currentDay;
    
    public GameObject board_recap;
    public GameObject board_trip_1;
    public GameObject board_trip_2;
    public GameObject board_trip_3;
    public GameObject board_trip_4;
    
    public GameObject apple;
    public GameObject kiwi;
    public GameObject banana;
    public GameObject pear;
    public GameObject orange;
    public GameObject avocado;

    public GameObject umbrella;
    public GameObject fountain;
    public GameObject fire;

    public GameObject smallFish; 
    public GameObject midFish;   
    public GameObject bigFish;  


    
    
    public int counter;
    public int delay = 10;
    
    public int midProfit = 150;
    public int lowProfit = 80; 
    
    public int lowTrip = 1;
    public int midTrip = 3; 

    void Start()
    {
        counter = 0;
        // TextAsset asset = Resources.Load("GlobeData") as TextAsset;

        TextAsset asset1 = Resources.Load("CountryProfit") as TextAsset;
        TextAsset asset2 = Resources.Load("TripProfit") as TextAsset;
        //TextAsset asset3 = Resources.Load("Data") as TextAsset;





        if (asset1 != null && asset2 != null)
        {

            countryProfit = JsonUtility.FromJson<CountryProfitList>(asset1.text);
            tripProfit = JsonUtility.FromJson<TripProfitList>(asset2.text);


            //data = JsonUtility.FromJson<DataList>(asset3.text);
        }

        for (int i = 0; i < num_days; i++)
        {
            DataSet obj = new DataSet();
            days.Add(obj);
            days[i].id = i;
            days[i].name = (i + 1).ToString();
            days[i].trips = calculateTrips(i);
            days[i].profit = calculateProfits(i);
            days[i].countries = calculateCountries(i);
            days[i].trips_list = calculateList(i);

        }

        currentDay = days[0];
        InvokeRepeating(nameof(set_day), delay, delay);

    }

  



    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;



        if (sceneName == "NatureEnvironment")
        {
   
            // Weather 

            Weather_Selector weather_selector = (Weather_Selector) weather.GetComponent("Weather_Selector");

            if (currentDay.trips_list.Count() <= lowTrip)
            {
                weather_selector.selector = 1; // rainy
                umbrella.SetActive(true);
                fire.SetActive(false);
                fountain.SetActive(false);

            }
        
            
            if (currentDay.trips_list.Count() > lowTrip && currentDay.trips_list.Count()<= midTrip) {
                weather_selector.selector = 3; // cloudy 
                fire.SetActive(true);
                umbrella.SetActive(false);
                fountain.SetActive(false);

}

            if (currentDay.trips_list.Count() > midTrip)
            {
                weather_selector.selector = 2; // sunny
                fountain.SetActive(true);
                fire.SetActive(false);
                umbrella.SetActive(false);


            }


            // Numerical Data on the sign

            Text txt0 = board_recap.GetComponent<Text>();
            Text txt1 = board_trip_1.GetComponent<Text>();
            Text txt2 = board_trip_2.GetComponent<Text>();
            Text txt3 = board_trip_3.GetComponent<Text>();
            Text txt4 = board_trip_4.GetComponent<Text>();


            txt0.text = "Day:" + currentDay.name + "\n" +
                        "Trips sold: " + currentDay.trips + "\n" +
                        "Profit: " + currentDay.profit;
            
            if (currentDay.trips_list.Count >= 1)
            {

                txt1.text = "-----------------------------------------------------"
                            + "\n" +
                            "Trip ID: " + currentDay.trips_list[0].id + "\n" +
                            "Destination: " + currentDay.trips_list[0].destination + "\n" +
                            "Passengers: " + currentDay.trips_list[0].traveler + "\n" +
                            "Profits: " + currentDay.trips_list[0].value;
            }

            if (currentDay.trips_list.Count >= 2)
            {

                txt2.text = "-----------------------------------------------------"
                            + "\n" +
                            "Trip ID: " + currentDay.trips_list[1].id + "\n" +
                            "Destination: " + currentDay.trips_list[1].destination + "\n" +
                            "Passengers: " + currentDay.trips_list[1].traveler + "\n" +
                            "Profits: " + currentDay.trips_list[1].value;
            }

            if (currentDay.trips_list.Count >= 3)
            {

                txt3.text = "-----------------------------------------------------"
                            + "\n" +
                            "Trip ID: " + currentDay.trips_list[2].id + "\n" +
                            "Destination: " + currentDay.trips_list[2].destination + "\n" +
                            "Passengers: " + currentDay.trips_list[2].traveler + "\n" +
                            "Profits: " + currentDay.trips_list[2].value;
            }

            if (currentDay.trips_list.Count >= 4)
            {

                txt4.text = "-----------------------------------------------------"
                            + "\n" +
                            "Trip ID: " + currentDay.trips_list[3].id + "\n" +
                            "Destination: " + currentDay.trips_list[3].destination + "\n" +
                            "Passengers: " + currentDay.trips_list[3].traveler + "\n" +
                            "Profits: " + currentDay.trips_list[3].value;
            }
            
            
            // Fruit 

            HashSet<string> country_fruit = ReturnCountries();
            foreach (string c in country_fruit)
            {
               
                switch (c)
                {
                   case  "Germany" : 
                       apple.SetActive(true);
                     
                       break;
                   case "Malaysia":
                       kiwi.SetActive(true);
                       break;
                   case "UK":
                       banana.SetActive(true);
                       break;
                   case "USA":
                       avocado.SetActive(true);
                       break;
                   case "Japan":
                       orange.SetActive(true);
                       break;
                   case "SA": 
                       pear.SetActive(true);    
                       break;
                }
                
            }
            
            
            // Fish

            if (currentDay.profit <= lowProfit)
            {
                
               smallFish.SetActive(true);
               midFish.SetActive(false);
               bigFish.SetActive(false);
                
            }
            else
            {
                if (currentDay.profit > lowProfit && currentDay.profit <= midProfit)
                {
                    smallFish.SetActive(false);
                    midFish.SetActive(true);
                    bigFish.SetActive(false);
                    
                }
                else
                {
                    smallFish.SetActive(false);
                    midFish.SetActive(false);
                    bigFish.SetActive(true);
                }
               
            }

        }

        if (sceneName == "BusinessEnvironment" ||  sceneName == "Office Scene" || sceneName == "OfficeScene")
        {
            //do stuff
        }

    }

    void InitializeFruit()
    {
        
        apple.SetActive(false);
        
        kiwi.SetActive(false);
       
        banana.SetActive(false);
        
        avocado.SetActive(false);
       
        orange.SetActive(false);
        
        pear.SetActive(false);  
    }
    
    
    void set_day()
    {
        
        if (counter<3) counter ++;
        else counter = 0;
        currentDay = days[counter];
        InitializeFruit();
        
    }

    public int calculateTrips(int i)
    {
        int count = 0;

        foreach (Trips t in tripProfit.Trips)
        {

            if (t.day == i) count++;
        }


        return count;

    }

    public int calculateProfits(int i)
    {
        int sum = 0;
        int profit;
        int people;
        foreach (Trips t in tripProfit.Trips)
        {
            if (t.day == i)
            {
                profit = getProfit(t.destination);
                people = t.traveler;
                sum += profit * people;



            }
        }

        return sum;

    }

    public int calculateCountries(int i)
    {
        HashSet<string> myList = new HashSet<string>();
        int count = 0;

        foreach (Trips t in tripProfit.Trips)
        {
            if (myList.Contains(t.destination) == false)
            {
                myList.Add(t.destination);
                count++;
            }


        }

        return count;

    }
    
    
    public HashSet<string> ReturnCountries()
    {
        HashSet<string> myList = new HashSet<string>();
        int count = 0;

        foreach (Trips t in currentDay.trips_list)
        {
            if (myList.Contains(t.destination) == false)
            {
                myList.Add(t.destination);
                count++;
            }


        }

        return myList;

    }


    public int getProfit(string destination)
    {

        foreach (Country c in countryProfit.Country)
        {
            if (destination.Equals(c.name)) return c.profit;

        }

        return 0;

    }

    public List<Trips> calculateList(int i)
    {
        List<Trips> tripList = new List<Trips>();
        Trips temp;
        foreach (Trips t in tripProfit.Trips)
        {
            if (t.day == i)
            {
                temp = t;
                temp.value = getProfit(temp.destination) * temp.traveler;
                tripList.Add(temp);
            }

        }

        return tripList;

    }


}