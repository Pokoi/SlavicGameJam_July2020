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

        private Plant potPlant = null;

        public Plant GetPotPlant => potPlant;

        OnHover onHover;

        [SerializeField] public WateringCan wateringCanComponent;

        private void Start()
        {
            onHover = transform.GetComponent<OnHover>();            
        }

        void OnMouseDown(){

            if (PlayerController.Instance.IsPlanting && PlayerController.Instance.GetPlantType() != null && potPlant == null)
            {

                string plantType = PlayerController.Instance.GetPlantType();
                GameObject plantGO = plantPool.GetFromPool(plantType);

                plantGO.transform.parent = plantPivot;
                plantGO.transform.position = plantPivot.position;
                potPlant = plantGO.GetComponent<Plant>();

                PlayerController.Instance.IsPlanting = false;

                Debug.Log("plantando");
            }
            else if (PlayerController.Instance.IsUsingFertilizer) {
                string fertilizerType = PlayerController.Instance.GetCurrFertilizer();

                fertilizationEffect.Execute(fertilizerType, potPlant);

            }
            else if (PlayerController.Instance.IsUsingWaterCan && potPlant != null)
            {
                wateringCanComponent.GetWateringCanEffect.Execute(potPlant);
            }


        }

        public string GetTextInfo()
        {
            if (potPlant) return potPlant.GetPlantState.ToString();
            return "This pot is empty...";
        }

    }
}
