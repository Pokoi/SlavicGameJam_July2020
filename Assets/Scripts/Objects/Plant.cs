using Garden;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Plant 
{
    [System.Serializable]
    public struct InitializationList
    {
        [System.Serializable]
        public struct Range
        {
            public float min;
            public float max;
        }

        public Range temperature;

        public string flowering;
        public string lightExposition;
        public float irrigationRate;

        public float fertilizationRate;
        public string fertilizationType;
    }

    InitializationList values;

    Plant(string type)
    {
        InitializationList list = PlantGenerator.Get.GetPlantValues(type);
    }

}
