using System.Collections.Generic;

namespace Garden
{
    public class EffectsSystem : System
    {
        public EffectsSystem(){

        }

        public override void Init(){

            //List of effects
            effects = new List<Effect>();

            //Effects creation
            SunEffect sunEffect = new SunEffect();


            //Effects addition
            effects.Add(sunEffect);

        }
        public override void Update()
        {
            foreach(Effect e in effects)
            {
                e.Execute();
            }
        }

        public void AddEffect(Effect e){
            effects.Add(e);
        }

        private List<Effect> effects;
    }
}