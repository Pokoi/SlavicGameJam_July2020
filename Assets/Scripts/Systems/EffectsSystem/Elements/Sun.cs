
using UnityEngine;

namespace Garden
{

    public class Sun : MonoBehaviour
    {
        [SerializeField]
        private float currentSun = 5f;
        private float startingSun;
        public float GetCurrentSun => currentSun;
        private SunEffect sunEffect;

        //[SerializeField] Delegate [] delegates;

        private void Start(){
            sunEffect = new SunEffect(this);

            //Add the effect to the effectsystem
            SceneSystem.Instance.GetEffectsSystem.AddEffect(sunEffect);

            startingSun = currentSun;
        }

        //The delegate call this funcion when day night state is changed
        public void ChangeSunIntensity(string state){

            switch(state){
                case "Morning":
                currentSun = startingSun;
                break;

                case "Noon":
                currentSun*=2;
                break;

                case "Afternoon":
                currentSun/=3;
                break;

                case "Evening":
                currentSun = 0f;
                break;
            }
        }

        void Update(){
            Debug.Log("Potencia del sol: " + currentSun);
        }
        
    }
}