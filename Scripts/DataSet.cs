using System.Collections.Generic;
[System.Serializable]
    public class DataSet
    {
        public int id;
        public string name;
        public int trips;
        public int profit;
        public int countries;
        public List<Trips> trips_list = new List<Trips>();
    }