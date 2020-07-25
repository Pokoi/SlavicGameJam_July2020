
using UnityEngine;

namespace Garden
{
    public class FertilizationEffect : Effect
    {

        public GameObject panel, fertilizer,close;
        public InformationSystem informationSystem;
        public override void Execute()
        {

        }

        public void Execute(string type, Plant plant) => plant.Fertilizate(type);


        void OnMouseDown(){
            FertilizerHUD(true);
        }
        public void FertilizerHUD(bool active){
            panel.SetActive(active);
            fertilizer.SetActive(active);
            close.SetActive(active);
        }
    }
}