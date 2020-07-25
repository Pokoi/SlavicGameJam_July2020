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
        void OnMouseDown(){
            
            if(PlayerController.Instance.IsPlanting && PlayerController.Instance.GetPlantType() != null)
            {
                
                string plantType = PlayerController.Instance.GetPlantType();
                GameObject plantGO = plantPool.GetFromPool(plantType);
                
                plantGO.transform.parent = plantPivot;
                plantGO.transform.position = plantPivot.position;
                potPlant = plantGO.GetComponent<Plant>();
                Debug.Log("plantando");
            }
            else if(PlayerController.Instance.IsUsingFertilizer){
                string fertilizerType = PlayerController.Instance.GetPlantType();

                fertilizationEffect.Execute(fertilizerType,potPlant);                

            }


        }

    }
}
