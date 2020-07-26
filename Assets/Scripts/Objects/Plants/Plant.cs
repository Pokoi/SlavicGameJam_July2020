
using UnityEngine;

namespace Garden
{
    public class Plant : MonoBehaviour
    {
        
        [SerializeField] string plantType;

        Pot pot;
        PlantState plantState;
        public PlantState GetPlantState => plantState;

        private bool isActive = true;
        public bool IsActive { get { return isActive; } set { isActive = value; } }

        [SerializeField] ClockComponent growingClock;
        [SerializeField] ClockComponent irrigationClock;
        [SerializeField] ClockComponent fertilizationClock;

        public int growingPhase = 0;
        public Sprite[] statesSprites = new Sprite[3];
        private SpriteRenderer spriteRenderer;

        bool isReadyToGrow = false;
        string nextGrowingPhase;

        /// <summary>
        ///  Gets a reference to the pot
        /// </summary>
        /// <returns></returns>
        public Pot GetPot() => pot;

        /// <summary>
        /// Sets the plant pot
        /// </summary>
        /// <param name="newPot"></param>
        public void SetPot(Pot newPot)
        {
            pot = newPot;
            plantState.UpdateLightExposition(pot.GetLightExposition());

        }

    
        public void Awake()
        {
            if (plantState == null) plantState = new PlantState(plantType);

            plantState.Grow("seeds");

            //Initialize clocks
            irrigationClock.SetTicks(plantState.GetDesiredValues().irrigationRate / irrigationClock.GetStates().Length);
            fertilizationClock.SetTicks(plantState.GetDesiredValues().fertilizationRate / fertilizationClock.GetStates().Length);
            growingClock.SetTicks(plantState.GetDesiredValues().growingRate / growingClock.GetStates().Length);

            irrigationClock.SetName("IrrigationClock" + GetInstanceID());
            fertilizationClock.SetName("FertilizationClock" + GetInstanceID());
            growingClock.SetName("GrowingClock" + growingClock.gameObject.GetInstanceID());
        }

        void Start(){
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = statesSprites[0];
        }

        public void RestartPlantState(string type)
        {
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
            if (plantState == null) plantState = new PlantState(plantType);

            if (pot != null)
            {
                plantState.UpdatePlantTemperature(pot.GetTransformedTemperature(sunIntensity));
                OnDataChange();
            }
        }

        public void Irrigate()
        {
            Debug.Log("He regado esta planta ");
            if (plantState == null) plantState = new PlantState(plantType);

            irrigationClock.ChangeState(-1);
            irrigationClock.Reset();
            plantState.UpdateIrrigationState(irrigationClock.GetCurrentState());            
           
        }

        public void UpdateIrrigationStats(string state)
        {
            if (plantState == null) plantState = new PlantState(plantType);

            plantState.UpdateIrrigationState(state);
            OnDataChange();
            
        }

        public void UpdateFertilizationStats(string state)
        {
            if (plantState == null) plantState = new PlantState(plantType);
            
            plantState.UpdateFertilizationState(state);
            OnDataChange();
            
        }


        public void Fertilizate(string fertilizationType)
        {
            if (plantState == null) plantState = new PlantState(plantType);
            
            if (fertilizationType == plantState.GetDesiredValues().fertilizationType)
            {
                    fertilizationClock.ChangeState(-1);
                    fertilizationClock.Reset();
                    plantState.UpdateFertilizationState(fertilizationClock.GetCurrentState());
            }
            
        }

        public bool CheckIfGrowingIsPossible()
        {
            if (plantState == null) plantState = new PlantState(plantType);

            return isReadyToGrow && plantState.SatisfyStats();           

        }  
        


        public void UpgradeGrowingPhase()
        {
            if (growingPhase < 3)
            {                
                growingPhase++;
                spriteRenderer.sprite = statesSprites[growingPhase];
                isReadyToGrow = false;
                plantState.Grow(nextGrowingPhase);                
                growingClock.Resume();
            }
        }

        public void OnDataChange()
        {
            if (CheckIfGrowingIsPossible()) UpgradeGrowingPhase();
        }



        public void SetPlantType(string type)
        {
            plantType = type;
        }

        public string GetPlantType()
        {
            return plantType;
        }
    }
}
