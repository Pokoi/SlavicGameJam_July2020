
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
        public struct InformationElement{
           public string elementName;
            public bool mouseOver;
            public string textToShow;
            public Component component;
        }



        public Delegate()
        { }

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
        public void Run(InformationElement value) => target.SendMessage(functionName, value);

        /// <summary>
        /// Execute the delegate
        /// </summary>
        /// <param name="value"></param>
        public void Run(Component value) => target.SendMessage(functionName, value);

       


    }
}
