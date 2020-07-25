
using UnityEngine;

namespace Garden
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] string plantType;

        [SerializeField] PlantPot       pot;
        PlantState     plantState;

        [SerializeField] ClockComponent growingClock;
        [SerializeField] ClockComponent irrigationClock;
        [SerializeField] ClockComponent fertilizationClock;

        bool isReadyToGrow = false;
        string nextGrowingPhase;

        /// <summary>
        ///  Gets a reference to the pot
        /// </summary>
        /// <returns></returns>
        public PlantPot GetPot() => pot;
        
        /// <summary>
        /// Sets the plant pot
        /// </summary>
        /// <param name="newPot"></param>
        public void SetPot(PlantPot newPot) => pot = newPot;


        private void Start()
        {
            //Catch the component
            growingClock = transform.GetComponent<ClockComponent>();

            plantState = new PlantState(plantType);

            //Initialize clocks
            irrigationClock.SetTicks(plantState.GetDesiredValues().irrigationRate / irrigationClock.GetStates().Length);
            fertilizationClock.SetTicks(plantState.GetDesiredValues().fertilizationRate / fertilizationClock.GetStates().Length);
        }

        public void ReadyToGrow()
        {
            isReadyToGrow = true;
           // nextGrowingPhase = growingState;

        }

        public void Atemperate(float sunIntensity)
        {
            plantState.UpdatePlantTemperature(pot.GetTransformedTemperature(sunIntensity));
        }

        public void Irrigate()
        {
            irrigationClock.ChangeState(-1);
            irrigationClock.Reset();
        }

        public void Fertilizate(string fertilizationType)
        {
            if (fertilizationType == plantState.GetDesiredValues().fertilizationType)
            { 
                fertilizationClock.ChangeState(-1);
                fertilizationClock.Reset();           
            }
        }

        public bool CheckIfGrowingIsPossible()
        {
            return isReadyToGrow;
        }

        public void UpgradeGrowingPhase()
        { 
            
        }

        public void Print(string text)
        {
            Debug.Log(text);
        }
    }
}
