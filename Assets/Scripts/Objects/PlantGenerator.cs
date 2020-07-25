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
            public Plant.InitializationList.Range temperatureMin;
            public Plant.InitializationList.Range temperatureMax;


            public string[] floweringPossibleValues;
            public string[] lightExpositionPossibleValues;
            public string[] fertilizationTypes;

            public Plant.InitializationList.Range irrigationRateRange;           
            public Plant.InitializationList.Range fertilizationRateRange;
        }

        [SerializeField] RandomRanges randomStandards;

        List<Plant.InitializationList> initializationLists;

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
        { }


        /// <summary>
        ///  Get the initialization list of a given plant type. If the plant type is not registred, its created
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Plant.InitializationList GetPlantValues(string name)
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
        Plant.InitializationList CreateRandom()
        {
            Plant.InitializationList initializationList = new Plant.InitializationList();

            initializationList.temperature.min = UnityEngine.Random.Range( randomStandards.temperatureMin.min, randomStandards.temperatureMin.max);
            initializationList.temperature.max = UnityEngine.Random.Range( randomStandards.temperatureMax.min, randomStandards.temperatureMax.max);

            initializationList.flowering = randomStandards.floweringPossibleValues[UnityEngine.Random.Range(0, randomStandards.floweringPossibleValues.Length)];
            initializationList.lightExposition = randomStandards.lightExpositionPossibleValues[UnityEngine.Random.Range(0, randomStandards.lightExpositionPossibleValues.Length)];

            initializationList.irrigationRate = UnityEngine.Random.Range(randomStandards.irrigationRateRange.min, randomStandards.irrigationRateRange.max);

            initializationList.fertilizationRate = UnityEngine.Random.Range(randomStandards.fertilizationRateRange.min, randomStandards.fertilizationRateRange.max);
            initializationList.fertilizationType = randomStandards.fertilizationTypes[UnityEngine.Random.Range(0, randomStandards.fertilizationTypes.Length)];

            return initializationList;

        }
    }

}
