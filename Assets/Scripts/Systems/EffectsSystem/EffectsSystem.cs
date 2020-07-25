using System.Collections.Generic;

namespace Garden
{
    public class EffectsSystem : System
    {

        SunEffect sunEffect;
        SunEffect GetSunEffect => sunEffect;

        WateringCanEffect wateringCanEffect;
        WateringCanEffect GetWateringCanEffect => wateringCanEffect;

        FertilizationEffect fertilizationEffect;
        FertilizationEffect GetFertilizationEffect => fertilizationEffect;

        public EffectsSystem()
        {

        }

        public override void Init(){

            //List of effects
            effects = new List<Effect>();

            //Effects creation
           


            //Effects addition
            

        }
        public override void Update(float delta)
        {
            /*foreach(Effect e in effects)
            {
                if(e.IsActive)
                    e.Execute();
            }*/
        }

        public void AddEffect(Effect e){
            effects.Add(e);
        }

        private List<Effect> effects;
    }
}