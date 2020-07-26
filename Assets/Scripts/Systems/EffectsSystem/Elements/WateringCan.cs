
using UnityEngine;

namespace Garden
{
    public class WateringCan : MonoBehaviour
    {
        [SerializeField]
        private int currentWater = 5;
        public float GetCurrentWater => currentWater;
         public WateringCanEffect wateringCanEffect;
        public WateringCanEffect GetWateringCanEffect => wateringCanEffect;

        private void Start()
        {

            //Add the effect to the effectsystem
            SceneSystem.Instance.GetEffectsSystem.AddEffect(wateringCanEffect);
        }


        
    }
}
