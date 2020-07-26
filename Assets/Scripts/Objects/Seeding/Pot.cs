using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class Pot : MonoBehaviour
    {
        public Transform plantPivot;
        public Pool plantPool;

        public FertilizationEffect fertilizationEffect;

        public Plant potPlant = null;

        public Plant GetPotPlant => potPlant;

        OnHover onHover;

        [SerializeField] public WateringCan wateringCanComponent;

        public enum LightExpositions { direct, indirect }
        [SerializeField] LightExpositions lightExposition;

        public InformationSystem informationSystem;

        private AudioSource audioSource;

        public string GetLightExposition() => lightExposition.ToString();

        /// <summary>
        /// Transform a given temperature
        /// </summary>
        /// <param name="sunTemperature"></param>
        /// <returns></returns>
        public float GetTransformedTemperature(float sunTemperature)
        {
            switch (lightExposition)
            {
                case LightExpositions.direct: sunTemperature *= 1.0f; break;
                case LightExpositions.indirect: sunTemperature *= 0.75f; break;
            }

            return sunTemperature;
        }


        private void Start()
        {
            onHover = transform.GetComponent<OnHover>();
            audioSource = transform.GetComponent<AudioSource>();
        }

        void OnMouseDown()
        {

            if (PlayerController.Instance.IsPlanting  && potPlant == null)
            {

                string plantType = PlayerController.Instance.GetPlantType();
                GameObject plantGO = plantPool.GetFromPool(plantType);

                plantGO.transform.parent = plantPivot;
                plantGO.transform.position = plantPivot.position;
                potPlant = plantGO.GetComponent<Plant>();
                potPlant.SetPot(this);
                potPlant.Awake();

                audioSource.Play();

                PlayerController.Instance.IsPlanting = false;

                Debug.Log("plantando");
            }
            else if (PlayerController.Instance.IsUsingFertilizer)
            {
                string fertilizerType = PlayerController.Instance.GetCurrFertilizer();

                fertilizationEffect.Execute(fertilizerType, potPlant);

            }
            else if (PlayerController.Instance.IsUsingWaterCan && potPlant != null)
            {
                if (potPlant.gameObject.activeSelf)
                    wateringCanComponent.GetWateringCanEffect.Execute(potPlant);
            }
            else if (PlayerController.Instance.IsUsingScissors && potPlant != null)
            {
                if (potPlant.gameObject.activeSelf)
                {
                    PlayerController.Instance.cuttedPlant = potPlant;
                    PlayerController.Instance.IsUsingScissors = false;
                    PlayerController.Instance.IsUsingTrashCan = true;

                    informationSystem.PlantCutted();

                    Debug.Log("He cortado la plantita");
                    // potPlant = null;
                    potPlant.IsActive = false;
                    potPlant.transform.parent = plantPool.transform;
                    potPlant.gameObject.SetActive(false);
                    potPlant = null;
                }

            }


        }

        public string GetTextInfo()
        {
            if (potPlant) return potPlant.GetPlantState.ToString();
            return "This pot is empty...";
        }

    }
}
