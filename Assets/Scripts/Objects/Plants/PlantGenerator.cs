using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

namespace Garden
{
    public class PlantGenerator
    {
        [Serializable]
        public struct RandomRanges
        {
            public PlantState.InitializationList.Range temperatureMin;
            public PlantState.InitializationList.Range temperatureMax;
            public PlantState.InitializationList.Range growingRate;

            public string[] floweringPossibleValues;
            public string[] irrigationPossibleValues;
            public string[] fertilizationPossibleValues;
            public string[] lightExpositionPossibleValues;
            public string[] fertilizationTypes;

            public PlantState.InitializationList.Range irrigationRateRange;           
            public PlantState.InitializationList.Range fertilizationRateRange;
        }

        [SerializeField] RandomRanges randomStandards;

        List<PlantState.InitializationList> initializationLists = new List<PlantState.InitializationList>();

        [SerializeField] List<string> plantTypes = new List<string>();

        static PlantGenerator instance;

        /// <summary>
        /// Singleton
        /// </summary>
        public static PlantGenerator Get
        {
            get 
            {
                if (instance is null) instance = new PlantGenerator();
                return instance;
            }
        }
        
        private PlantGenerator()
        {
            // Catch a reference to the season clock to initialize the flowering possible values
            var seasonClockStates = SceneSystem.Instance.GetTimeSystem.GetComponent("SeasonClock").GetStates();

            InitializeStandards();

        }

        private void InitializeStandards()
        {
            randomStandards.temperatureMin  = new PlantState.InitializationList.Range (10, 20);
            randomStandards.temperatureMax  = new PlantState.InitializationList.Range(10, 20); ;
            randomStandards.growingRate     = new PlantState.InitializationList.Range(20, 35); ;

            randomStandards.floweringPossibleValues       = new string[] { "summer", "fall", "winter", "spring"};
            randomStandards.irrigationPossibleValues      = new string[] { "puddled", "wet", "damp", "dry" }; 
            randomStandards.fertilizationPossibleValues   = new string[] { "too much", "moderate", "scarce" }; 
            randomStandards.lightExpositionPossibleValues = new string[] { "direct", "indirect"}; 
            randomStandards.fertilizationTypes            = new string[] { "flower", "minerals", "organic", "universal" };

            randomStandards.irrigationRateRange     = new PlantState.InitializationList.Range(2, 20);
            randomStandards.fertilizationRateRange  = new PlantState.InitializationList.Range(30, 120);           

        }


        /// <summary>
        ///  Get the initialization list of a given plant type. If the plant type is not registred, its created
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PlantState.InitializationList GetPlantValues(string name)
        {
            int i = 0;

            while ( i < plantTypes.Count && plantTypes[i] != name)
            {
                ++i;
            }

            if (i >= plantTypes.Count)
            {
                initializationLists.Add(CreateRandom());
                plantTypes.Add(name);
                return initializationLists[plantTypes.Count - 1];
            }

            return initializationLists[i];

        }


        /// <summary>
        /// Creates a random plant and returns it
        /// </summary>
        /// <returns></returns>
        PlantState.InitializationList CreateRandom()
        {
            PlantState.InitializationList initializationList = new PlantState.InitializationList();

            initializationList.temperature.min = UnityEngine.Random.Range( randomStandards.temperatureMin.min, randomStandards.temperatureMin.max);
            initializationList.temperature.max = UnityEngine.Random.Range( randomStandards.temperatureMax.min, randomStandards.temperatureMax.max);

            initializationList.flowering = randomStandards.floweringPossibleValues[UnityEngine.Random.Range(0, randomStandards.floweringPossibleValues.Length)];
            initializationList.lightExposition = randomStandards.lightExpositionPossibleValues[UnityEngine.Random.Range(0, randomStandards.lightExpositionPossibleValues.Length)];

            initializationList.irrigationRate = UnityEngine.Random.Range(randomStandards.irrigationRateRange.min, randomStandards.irrigationRateRange.max);

            initializationList.growingRate = UnityEngine.Random.Range(randomStandards.growingRate.min, randomStandards.growingRate.max);

            initializationList.fertilizationRate = UnityEngine.Random.Range(randomStandards.fertilizationRateRange.min, randomStandards.fertilizationRateRange.max);
            initializationList.fertilizationType = randomStandards.fertilizationTypes[UnityEngine.Random.Range(0, randomStandards.fertilizationTypes.Length)];

            initializationList.irrigationIdealStatus = randomStandards.irrigationPossibleValues[UnityEngine.Random.Range(0, randomStandards.irrigationPossibleValues.Length)];
            initializationList.fertilizationIdealStatus = randomStandards.fertilizationTypes[UnityEngine.Random.Range(0, randomStandards.fertilizationTypes.Length)]; ;

            return initializationList;

        }
    }

}
