using Garden;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using System;

namespace Garden
{ 
    public class PlantState
    {
        [Serializable]
        public struct InitializationList
        {
            [Serializable]
            public struct Range
            {
                public float min;
                public float max;
            }

            public Range temperature;

            public string   flowering;
            public string   lightExposition;
            
            public float    irrigationRate;
            public float    fertilizationRate;
            
            public string fertilizationType;

            public string irrigationIdealStatus;
            public string fertilizationIdealStatus;
        }

        InitializationList desiredValues;
        
        float   currentTemperature;
        bool    flowingState;
        string  irrigationState;
        string  fertilizationState;
        string  lightExposition;

        public PlantState(string type)
        {
            desiredValues = PlantGenerator.Get.GetPlantValues(type);
        }

        /// <summary>
        /// Get the desired values
        /// </summary>
        /// <returns></returns>
        public InitializationList GetDesiredValues() => desiredValues;

        /// <summary>
        /// Updates the plant temperature 
        /// </summary>
        public void UpdatePlantTemperature(float temperature) => currentTemperature = temperature;       

        /// <summary>
        /// Update the irrigation state of the plant
        /// </summary>
        /// <param name="newState"></param>
        public void UpdateIrrigationState(string newState) => irrigationState = newState;

        /// <summary>
        /// Update the fertilization state of the plant
        /// </summary>
        /// <param name="newState"></param>
        public void UpdateFertilizationState(string newState) => fertilizationState = newState;


        public bool SatisfyStats()
        {
            return  currentTemperature < desiredValues.temperature.max &&
                    currentTemperature > desiredValues.temperature.min &&
                    irrigationState == desiredValues.irrigationIdealStatus &&
                    fertilizationState == desiredValues.fertilizationIdealStatus &&
                    lightExposition == desiredValues.lightExposition;
        }

        public string ToString()
        {
            return "";
        }
    }
}
