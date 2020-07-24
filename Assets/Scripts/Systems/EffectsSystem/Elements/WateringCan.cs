
using UnityEngine;

namespace Garden
{
    public class WateringCan : MonoBehaviour
    {
        [SerializeField]
        private int currentWater = 5;
        public float GetCurrentWater => currentWater;
        private WateringCanEffect wateringCanEffect;

        private void Start(){
            wateringCanEffect = new WateringCanEffect(this);

            //Add the effect to the effectsystem
            SceneSystem.Instance.GetEffectsSystem.AddEffect(wateringCanEffect);
        }

    }
}
