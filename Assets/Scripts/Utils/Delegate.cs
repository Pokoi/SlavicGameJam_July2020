
using System;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace Garden
{
    [Serializable]
    public class Delegate
    {
        
        [SerializeField] GameObject target;
        [SerializeField] string functionName;

        [HideInInspector]
        public struct HoverElement{
           public string elementName;
            public bool mouseOver;
        }


        public Delegate()
        { }

        public void SetTarget(GameObject go){
            target = go;
        }

        /// <summary>
        /// Execute the delegate
        /// </summary>
        /// <param name="value"></param>
        public void Run(float value) => target.SendMessage(functionName, value);

        /// <summary>
        /// Execute the delegate
        /// </summary>
        /// <param name="value"></param>
        public void Run(int value) => target.SendMessage(functionName, value);

        /// <summary>
        /// Execute the delegate
        /// </summary>
        /// <param name="value"></param>
        public void Run(string value) => target.SendMessage(functionName, value);

        /// <summary>
        /// Execute the delegate
        /// </summary>
        /// <param name="value"></param>
        public void Run(bool value) => target.SendMessage(functionName, value);

        /// <summary>
        /// Execute the delegate
        /// </summary>
        public void Run() => target.SendMessage(functionName);


        /// <summary>
        /// Execute the delegate
        /// </summary>
        /// <param name="value"></param>
        public void Run(HoverElement value) => target.SendMessage(functionName, value);


    }
}
