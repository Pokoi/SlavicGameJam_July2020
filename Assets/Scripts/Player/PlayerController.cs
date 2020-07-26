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
        public bool IsUsingFertilizer { get { return usingFertlizer; } set { usingFertlizer = value; } }
        private bool usingWaterCan = false;
        public bool IsUsingWaterCan { get { return usingWaterCan; } set { usingWaterCan = value; } }

        private bool usingScissors = false;
        public bool IsUsingScissors { get { return usingScissors; } set { usingScissors = value; } }

        private bool usingTrashCan = false;
        public bool IsUsingTrashCan { get { return usingTrashCan; } set { usingTrashCan = value; } }

        private bool canInteract = true;
        public bool CanInteract { get { return canInteract; } set { canInteract = value; } }


        [HideInInspector]
        public Plant cuttedPlant = null;

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

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                planting = true;
                usingFertlizer = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                planting = false;
                usingFertlizer = true;
            }
        }

        public void SelectSeed(string type)
        {
            currPlantType = type;
            planting = true;
            usingFertlizer = false;
            usingWaterCan = false;
        }

        public void SelectFertilizer(string type)
        {

            currFertilizer = type;
            planting = false;
            usingFertlizer = true;
            usingWaterCan = false;
        }

        
       

    }
}
