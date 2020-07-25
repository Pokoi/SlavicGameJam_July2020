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
        public bool IsPlanting { get { return planting; } set { planting = value; } }
        private bool usingFertlizer = false;
        public bool IsUsingFertilizer => usingFertlizer;
        private bool usingWaterCan = false;
        public bool IsUsingWaterCan { get { return usingWaterCan; } set { usingWaterCan = value; } }

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

        public string GetPlantType()
        {
            return currPlantType;
        }

        public string GetCurrFertilizer()
        {
            return currFertilizer;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {planting = true;
            usingFertlizer = false;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {planting = false;
            usingFertlizer = true;
            }
        }

        public void SelectSeed(string type)
        {
            currPlantType   = type;
            planting        = true;
            usingFertlizer  = false;
            usingWaterCan   = false;
        }
    }
}
