using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class InformationSystem : MonoBehaviour
    {


        public void ShowHoverInfo(Delegate.HoverElement hoverElement){
            if(hoverElement.mouseOver) //If mouse is over que show info
            {   
                string name = hoverElement.elementName;
                switch(name){
                    case "Plant":
                    Debug.Log("This is the info about a Plant");
                    break;
                }
            }
        }
    }
}