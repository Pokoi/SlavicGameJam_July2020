using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class SceneSystem : MonoBehaviour
    {

        //Singleton
        private static SceneSystem _instance;

        public static SceneSystem Instance { get { return _instance; } }
        //Singleton end


        //Systems 
        private EffectsSystem effectsSystem;
        public EffectsSystem GetEffectsSystem => effectsSystem;

        [SerializeField]
        private Time timeSystem;
        public Time GetTimeSystem => timeSystem;


        //List of systems
        private List<System> systems;


        [SerializeField] private PlantManager plantManager;
        public PlantManager GetPlantManager => plantManager;


        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }

            //Systems list initialization
            systems = new List<System>();

            //Effects System
            effectsSystem = new EffectsSystem();
            systems.Add(effectsSystem);

            //Time system
            //timeSystem = new Time();
            systems.Add(timeSystem);

            //When all systems are added que initialize them
            foreach (System s in systems)
            {
                s.Init();
            }
        }

        public void Start()
        {

            
        }

        public void Update()
        {
            foreach(System s in systems){
                if(s.IsActive)
                    s.Update(UnityEngine.Time.deltaTime);
            }
        }


    }
}