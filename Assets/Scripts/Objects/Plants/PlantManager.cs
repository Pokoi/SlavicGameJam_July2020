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
        [SerializeField] BotanicManual botanicManual;

        private void Start()
        {            

            UpdateText("Quintana quinae");
            UpdateText("Sutcac siuquis");
            UpdateText("Auch auchus");
            UpdateText("Triqui tricae");
            UpdateText("Alejandro alejandrus");
            UpdateText("Siquis siqus");
            UpdateText("Moru morus");
            UpdateText("Sequa sacus");
        }

        private void UpdateText(string name)
        {
            PlantState.InitializationList initializationList;
            initializationList = PlantGenerator.Get.GetPlantValues("name");

            botanicManual.UpdateText(
                                      botanicManual.GetTextAt(PlantGenerator.Get.GetIndexOfPlantType(name)),
                                      initializationList.irrigationIdealStatus,
                                      initializationList.lightExposition,
                                      (int) (initializationList.temperature.min) + " - " + (int) (initializationList.temperature.max),
                                      initializationList.fertilizationIdealStatus,
                                      initializationList.fertilizationType,
                                      ((int)initializationList.growingRate).ToString()
                                    );
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
