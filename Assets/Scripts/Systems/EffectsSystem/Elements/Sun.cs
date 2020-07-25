
using UnityEngine;
using System;

namespace Garden
{

    public class Sun : MonoBehaviour
    {
        [SerializeField]
        private float startingSun = 5f;
        private float currentSun;
        public float GetCurrentSun => currentSun;
        private SunEffect sunEffect;

        /// <summary>
        /// A struct with the data about the season heat changes
        /// </summary>
        [Serializable]
        private struct SeasonHeatModifiers 
        {
            public float summer;
            public float fall   ;
            public float winter ;
            public float spring ;
        }

        /// <summary>
        /// A struct with the data about the day-cycle heat changes
        /// </summary>
        [Serializable]
        private struct DayHeatModifiers
        {
            public float dawn;      
            public float midday;
            public float sunset;
            public float midnight;
        }

        [SerializeField] SeasonHeatModifiers seasonHeatModifiers;
        [SerializeField] DayHeatModifiers dayHeatModifiers;


        string currentDayState;
        string currentSeason ;

        //[SerializeField] Delegate [] delegates;

        private void Start(){
            sunEffect = new SunEffect();

            //Add the effect to the effectsystem
            SceneSystem.Instance.GetEffectsSystem.AddEffect(sunEffect);
                       
        }

        //The delegate call this funcion when day night state is changed
        public void ChangeSunIntensity(string state)
        {
            currentDayState = state;
            UpdateTemperature();
        }

        public void SeasonChanged(string season)
        {
            currentSeason = season;
            UpdateTemperature();
        }

        /// <summary>
        /// Updates the temperature value based on all the conditions
        /// </summary>
        void UpdateTemperature()
        {
            float seasonModifier = 1f;
            float dayModifier = 1f;

            switch (currentDayState)
            {
                case "dawn":     dayModifier = dayHeatModifiers.dawn;     break;
                case "midday":   dayModifier = dayHeatModifiers.midday;   break;
                case "sunset":   dayModifier = dayHeatModifiers.sunset;   break;
                case "midnight": dayModifier = dayHeatModifiers.midnight; break;            
            }

            switch (currentSeason)
            {
                case "summer": seasonModifier = seasonHeatModifiers.summer; break;
                case "fall": seasonModifier = seasonHeatModifiers.fall; break;
                case "winter": seasonModifier = seasonHeatModifiers.winter; break;
                case "spring": seasonModifier = seasonHeatModifiers.spring; break;
            }

            currentSun = startingSun * seasonModifier * dayModifier;

            sunEffect.Execute(currentSun);

            Debug.Log("Potencia del sol: " + currentSun + "ºC al " + currentDayState + " en " + currentSeason);
        }

        void Update(){
           
        }
        
    }
}