﻿using System;
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


            public string[] floweringPossibleValues;
            public string[] irrigationPossibleValues;
            public string[] fertilizationPossibleValues;
            public string[] lightExpositionPossibleValues;
            public string[] fertilizationTypes;

            public PlantState.InitializationList.Range irrigationRateRange;           
            public PlantState.InitializationList.Range fertilizationRateRange;
        }

        [SerializeField] RandomRanges randomStandards;

        List<PlantState.InitializationList> initializationLists;

        [SerializeField] List<string> plantTypes;

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

            randomStandards.floweringPossibleValues = new string[seasonClockStates.Length];
            int i = 0;

            while (i < seasonClockStates.Length)
            {
                randomStandards.floweringPossibleValues[i] = seasonClockStates[i];
                ++i;
            }

        }


        /// <summary>
        ///  Get the initialization list of a given plant type. If the plant type is not registred, its created
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PlantState.InitializationList GetPlantValues(string name)
        {
            int i = 0;

            while (plantTypes[i] != name && i < plantTypes.Count)
            {
                ++i;
            }

            if (i >= plantTypes.Count)
            {
                initializationLists.Add(CreateRandom());
                plantTypes.Add(name);
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

            initializationList.fertilizationRate = UnityEngine.Random.Range(randomStandards.fertilizationRateRange.min, randomStandards.fertilizationRateRange.max);
            initializationList.fertilizationType = randomStandards.fertilizationTypes[UnityEngine.Random.Range(0, randomStandards.fertilizationTypes.Length)];

            initializationList.irrigationIdealStatus = randomStandards.irrigationPossibleValues[UnityEngine.Random.Range(0, randomStandards.irrigationPossibleValues.Length)];
            initializationList.fertilizationIdealStatus = randomStandards.fertilizationTypes[UnityEngine.Random.Range(0, randomStandards.fertilizationTypes.Length)]; ;

            return initializationList;

        }
    }

}