
using UnityEngine;

namespace Garden{
public class WateringCanEffect : Effect
{
    public WateringCan wateringCan;
    private AudioSource audioSource;

        void Start(){
            audioSource = GetComponent<AudioSource>();
        }
         public override void Execute()
         {
             Debug.Log(wateringCan.GetCurrentWater);
         }

        public void Execute(Plant plantToIrrigate)
        {
            audioSource.Play();
            plantToIrrigate.Irrigate();
        }
}
}