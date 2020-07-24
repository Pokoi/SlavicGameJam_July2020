using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden{
    public class SunEffect : Effect
    {
        private Sun sun;
        public SunEffect(Sun sun){
            this.sun = sun;
        }
         public override void Execute(){
             Debug.Log(sun.GetCurrentSun);
         }
    }
}