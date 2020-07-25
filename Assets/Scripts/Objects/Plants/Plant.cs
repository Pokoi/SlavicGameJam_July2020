
using UnityEngine;

namespace Garden
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] string plantType;

        [SerializeField] PlantPot       pot;
        PlantState     plantState;
        public PlantState GetPlantState => plantState;

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


        public void Awake()
        {           

            plantState = new PlantState(plantType);

            //Initialize clocks
            irrigationClock.SetTicks(plantState.GetDesiredValues().irrigationRate / irrigationClock.GetStates().Length);
            fertilizationClock.SetTicks(plantState.GetDesiredValues().fertilizationRate / fertilizationClock.GetStates().Length);
            growingClock.SetTicks(plantState.GetDesiredValues().growingRate / growingClock.GetStates().Length);

             irrigationClock.SetName("IrrigationClock" + GetInstanceID());
             fertilizationClock.SetName("FertilizationClock" + GetInstanceID());
             growingClock.SetName("GrowingClock" + growingClock.gameObject.GetInstanceID());
        }

        public void RestartPlantState(string type){
            plantState.RestartValues(type);
           
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
            Debug.Log("He regado esta planta ");
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
            Debug.Log("He fertilizado.");
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

       

        public void SetPlantType(string type){
            plantType = type;
        }
        public string GetPlantType(){
            return plantType;
        }
    }
}
