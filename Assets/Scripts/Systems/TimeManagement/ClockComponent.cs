

using System;
using System.Xml.Serialization;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

namespace Garden
{

    public class ClockComponent : MonoBehaviour
    {
        /// <summary>
        /// The name of the component
        /// </summary>
        [SerializeField] string     name;

        /// <summary>
        /// The states of the component in order
        /// </summary>
        [SerializeField] string[]   states;

        /// <summary>
        /// The number of ticks between states
        /// </summary>
        [SerializeField] float        ticks;

         
        float               currentTick;
        int                 stateIndex;
             

        [SerializeField] Delegate [] delegates;

        private void Start()
        {
            stateIndex = 0;

            if (name == "")
            {
                name = gameObject.name;
            }
           
            SceneSystem.Instance.GetTimeSystem.AddComponent(name, this);
        }

        /// <summary>
        /// Unsubscribe to the system
        /// </summary>
        private void OnDestroy()
        {
            SceneSystem.Instance.GetTimeSystem.RemoveComponent(name);
        }

        /// <summary>
        /// Execute the component updating the tick
        /// </summary>
        /// <param name="delta"></param>
        public void Execute(float delta)
        {
            currentTick += delta;           

            if (currentTick > ticks)
            {
                ChangeState();
                currentTick = 0;               
            }          

        }

        /// <summary>
        /// Change the state of the clock
        /// </summary>
        private void ChangeState()
        {            
            stateIndex = stateIndex + 1 >= states.Length ? 0 : stateIndex + 1;
            
            foreach(Delegate sender in delegates)
            {
                sender.Run(GetCurrentState());
            }
        } 
        

        /// <summary>
        /// Get the current state of the clock
        /// </summary>
        /// <returns></returns>
        public string GetCurrentState() => states[stateIndex];
       
    }
}
