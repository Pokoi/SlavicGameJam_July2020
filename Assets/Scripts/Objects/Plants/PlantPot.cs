

using UnityEngine;

namespace Garden
{

    public class PlantPot : MonoBehaviour
    {
        public enum LightExpositions { direct, indirect }
        [SerializeField] LightExpositions lightExposition;

        public string GetLightExposition() => lightExposition.ToString();

        /// <summary>
        /// Transform a given temperature
        /// </summary>
        /// <param name="sunTemperature"></param>
        /// <returns></returns>
        public float GetTransformedTemperature(float sunTemperature)
        {          
            switch (lightExposition)
            {
                case LightExpositions.direct: sunTemperature *= 1.0f; break;
                case LightExpositions.indirect: sunTemperature *= 0.75f; break;
            }

            return sunTemperature;
        }

    }
}
