using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{

    public class Sun : MonoBehaviour
    {
        [SerializeField]
        private float currentSun = 5f;
        public float GetCurrentSun => currentSun;
        private SunEffect sunEffect;

        private void Start(){
            sunEffect = new SunEffect(this);

            //Add the effect to the effectsystem
            SceneSystem.Instance.GetEffectsSystem.AddEffect(sunEffect);
        }

        
    }
}