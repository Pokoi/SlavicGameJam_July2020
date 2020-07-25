
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
            irrigationClock.SetName("IrrigationClock" + irrigationClock.gameObject.GetInstanceID());
            fertilizationClock.SetTicks(plantState.GetDesiredValues().fertilizationRate / fertilizationClock.GetStates().Length);
            fertilizationClock.SetName("FertilizationClock" + fertilizationClock.gameObject.GetInstanceID());
            growingClock.SetTicks(plantState.GetDesiredValues().growingRate / growingClock.GetStates().Length);
            growingClock.SetName("GrowingClock" + growingClock.gameObject.GetInstanceID());
        }

        public void ReadyToGrow(string growingState)
        {
            isReadyToGrow = true;
            nextGrowingPhase = growingState;
            growingClock.Pause();
            growingClock.Reset();

            OnDataChange();
        }

        public void Atemperate(float sunIntensity)
        {
            plantState.UpdatePlantTemperature(pot.GetTransformedTemperature(sunIntensity));
            OnDataChange();
        }

        public void Irrigate()
        {
            irrigationClock.ChangeState(-1);
            irrigationClock.Reset();
            plantState.UpdateIrrigationState(irrigationClock.GetCurrentState());
        }

        public void UpdateIrrigationStats(string state)
        { 
            plantState.UpdateIrrigationState(state);
            OnDataChange();
        }

        public void UpdateFertilizationStats(string state)
        { 
            plantState.UpdateFertilizationState(state);
            OnDataChange();
        }       


        public void Fertilizate(string fertilizationType)
        {
            if (fertilizationType == plantState.GetDesiredValues().fertilizationType)
            { 
                fertilizationClock.ChangeState(-1);
                fertilizationClock.Reset();
                plantState.UpdateFertilizationState(fertilizationClock.GetCurrentState());
            }
        }

        public bool CheckIfGrowingIsPossible() => isReadyToGrow && plantState.SatisfyStats();
      

        public void UpgradeGrowingPhase()
        {
            isReadyToGrow = false;
            plantState.Grow(nextGrowingPhase);            
            growingClock.Resume();
        }

        public void OnDataChange()
        {
            if (CheckIfGrowingIsPossible()) UpgradeGrowingPhase();
        }

        public void Print(string text)
        {
            Debug.Log(text);
        }
    }
}
