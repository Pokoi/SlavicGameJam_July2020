
using UnityEngine;

namespace Garden{
    public class SunEffect : Effect
    {        
       
         public override void Execute()
         {
            
         }

        public void Execute(float sunIntensity) => SceneSystem.Instance.GetPlantManager.ApplySun(sunIntensity);

    }
}