
using UnityEngine;

namespace Garden{
public class WateringCanEffect : Effect
{
    private WateringCan wateringCan;
        public WateringCanEffect(WateringCan wateringCan){
            this.wateringCan = wateringCan;
        }
         public override void Execute(){
             Debug.Log(wateringCan.GetCurrentWater);
         }
}
}