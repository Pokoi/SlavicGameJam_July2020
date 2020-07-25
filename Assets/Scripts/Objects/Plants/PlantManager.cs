using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Garden
{
    public class PlantManager: MonoBehaviour
    {

        [SerializeField] Pool plantsPool;

        private void Start()
        {
           
        }

        public void ApplySun(float sunIntensity)
        {
            foreach (GameObject go in plantsPool.GetElements())
            {
                go.GetComponent<Plant>().Atemperate(sunIntensity);
            }
        }
    }
}
