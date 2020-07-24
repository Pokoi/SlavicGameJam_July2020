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
           


            //Effects addition
            

        }
        public override void Update(float delta)
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