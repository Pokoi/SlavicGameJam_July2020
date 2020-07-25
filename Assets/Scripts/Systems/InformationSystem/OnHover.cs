using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class OnHover : MonoBehaviour
    {
        public string elementName;
        [SerializeField] Delegate[] delegates;

        void Start(){
            
        }

        void OnMouseOver()
        {
            foreach (Delegate sender in delegates)
            {
                sender.Run(elementName);
            }
        }
        void OnMouseExit()
        {
            foreach (Delegate sender in delegates)
            {
                sender.Run(elementName);
            }
        }


    }
}
