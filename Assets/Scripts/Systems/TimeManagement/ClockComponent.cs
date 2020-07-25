

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

        /// <summary>
        /// Shows if the clock flow runs in a cycle
        /// </summary>
        [SerializeField] bool circularFlow = true;
         
        float               currentTick;
        int                 stateIndex;

        bool playing;

        [SerializeField] Delegate [] delegates;

        private void Start()
        {
            stateIndex = UnityEngine.Random.Range(0, states.Length);
            playing = true;

            if (name == "")
            {
                name = gameObject.name;
            }
            
            foreach (Delegate sender in delegates)
            {
                sender.Run(GetCurrentState());
            }

            SceneSystem.Instance.GetTimeSystem.AddComponent(name, this);
        }

        public void SetName(string name) => this.name = name;

        /// <summary>
        /// Reset the ticks value between states
        /// </summary>
        /// <param name="newTicks"></param>
        public void SetTicks(float newTicks) => ticks = newTicks;

        /// <summary>
        /// Execute the component updating the tick
        /// </summary>
        /// <param name="delta"></param>
        public void Execute(float delta)
        {
            if (playing)
            { 
                currentTick += delta;    

                if (currentTick > ticks)
                {
                    ChangeState();
                    currentTick -= ticks;               
                }          
            }
        }

        /// <summary>
        /// Change the state of the clock
        /// </summary>
        public void ChangeState(int indexChange = 1)
        {
            stateIndex += indexChange;

            if (circularFlow)
            {
                if (stateIndex < 0) stateIndex = states.Length - 1;
                else if (stateIndex >= states.Length) stateIndex = 0;

            }
            else
            {
                if (stateIndex < 0) stateIndex = 0;
                else if (stateIndex >= states.Length) stateIndex = states.Length - 1;
            }            
            
            foreach(Delegate sender in delegates)
            {
                sender.Run(GetCurrentState());
            }
        }

        /// <summary>
        /// Pause the clock execution
        /// </summary>
        public void Pause() => playing = false;        

        /// <summary>
        /// Resume the clock execution
        /// </summary>
        public void Resume() => playing = true;

        /// <summary>
        /// Reset the clock
        /// </summary>
        public void Reset() => currentTick = 0;

        /// <summary>
        /// Get the current state of the clock
        /// </summary>
        /// <returns></returns>
        public string GetCurrentState() => states[stateIndex];

        /// <summary>
        /// Gets a reference to the all possible states of this clock
        /// </summary>
        /// <returns></returns>
        public string[] GetStates() => states;

        /// <summary>
        /// Unsubscribe to the system
        /// </summary>
        private void OnDestroy()
        {
            SceneSystem.Instance.GetTimeSystem.RemoveComponent(name);
        }

    }
}
