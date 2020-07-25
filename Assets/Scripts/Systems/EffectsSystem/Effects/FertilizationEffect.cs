
using UnityEngine;

namespace Garden
{
    public class FertilizationEffect : Effect
    {

        public override void Execute()
        {

        }

        public void Execute(string type, Plant plant) => plant.Fertilizate(type);

    }
}