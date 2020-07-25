using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class PlayerController : MonoBehaviour
    {
        private static PlayerController _instance;

        public static PlayerController Instance { get { return _instance; } }

        private string currPlantType = "Geranio";
        private string currFertilizer = "Fertilizer Pro 4K";

        private bool planting = false;
        public bool IsPlanting => planting;
        private bool usingFertlizer = false;
        public bool IsUsingFertilizer => usingFertlizer;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public string GetPlantType(){
            return currPlantType;
        }
        public string GetCurrFertilizer(){
            return currFertilizer;
        }

        void Update(){
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {planting = true;
            usingFertlizer = false;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {planting = false;
            usingFertlizer = true;
            }
        }
    }
}
