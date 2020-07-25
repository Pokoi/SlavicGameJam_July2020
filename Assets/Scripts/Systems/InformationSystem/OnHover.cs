using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class OnHover : MonoBehaviour
    {
        public string elementName;

        [TextArea]
        public string textToShow;

        [SerializeField] Delegate[] delegates;

        private Component currComponent = null;

        void Start(){
            
        }

        void OnMouseOver()
        {
                //Information popup
                Delegate.InformationElement hElement;
                hElement.elementName = elementName;
                hElement.mouseOver = true;
                hElement.textToShow = textToShow;
                hElement.component = null;

                delegates[0].Run(hElement);

                ///////////
            
                //Cursor delegate
                
                Delegate.InformationElement hCursor;
                hCursor.elementName = elementName;
                hCursor.mouseOver = true;
                hCursor.textToShow = "";

                if(currComponent==null){
                if(TryGetComponent(out WateringCan wCan)){
                    currComponent = wCan;
                }
                else if(TryGetComponent(out Plant plant))
                    currComponent = null;
                    }

                hCursor.component = currComponent;
                delegates[1].Run(hCursor);
            
        }
        void OnMouseExit()
        {
            
                //Information popout
                Delegate.InformationElement hElement;
                hElement.elementName = elementName;
                hElement.mouseOver = false;
                hElement.textToShow = "";
                hElement.component = null;

                delegates[0].Run(hElement);

                ///////////

                //Cursor delegate

                Delegate.InformationElement hCursor;
                hCursor.elementName = elementName;
                hCursor.mouseOver = false;
                hCursor.textToShow = "";

              
               if(currComponent==null){
                if(TryGetComponent(out WateringCan wCan)){
                    currComponent = wCan;
                }
                else if(TryGetComponent(out Plant plant))
                    currComponent = null;
               }

                hCursor.component = currComponent;
                delegates[1].Run(hCursor);

        }

        void OnMouseDown(){
           delegates[2].Run(currComponent);
        }

    }
}
