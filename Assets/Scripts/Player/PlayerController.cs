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
    }
}
