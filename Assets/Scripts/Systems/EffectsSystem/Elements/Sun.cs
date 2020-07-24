
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
                case "dawn":
                currentSun = startingSun;
                break;

                case "midday":
                currentSun*=2;
                break;

                case "sunset":
                currentSun/=3;
                break;

                case "midnight":
                currentSun = 0f;
                break;
            }
        }

        public void SeasonChanged(string season){
            
            switch(season){
                case "spring":
                currentSun += 2;
                break;

                case "summer":
                currentSun*=2;
                break;

                case "autumn":
                currentSun= startingSun;
                break;

                case "winter":
                currentSun -= 10f;
                break;
            }
        }

        void Update(){
            Debug.Log("Potencia del sol: " + currentSun);
        }
        
    }
}