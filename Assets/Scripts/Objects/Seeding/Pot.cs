using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class Pot : MonoBehaviour
    {
        public Transform plantPivot;
        public Pool plantPool;

        void OnMouseDown(){
            
            if(PlayerController.Instance.GetPlantType() != null)
            {
                
                string plantType = PlayerController.Instance.GetPlantType();
                GameObject plantGO = plantPool.GetFromPool(plantType);
                
                plantGO.transform.parent = plantPivot;
                plantGO.transform.position = plantPivot.position;
                Debug.Log("plantando");
            }
        }

    }
}
