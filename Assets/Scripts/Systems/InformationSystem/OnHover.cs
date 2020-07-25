using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Garden
{
    public class OnHover : MonoBehaviour
    {
        public string elementName;

        [TextArea]
        public string textToShow;

        [SerializeField] Delegate[] delegates;


        private Component currComponent = null;

        Pot pot;

        void Start(){
            if(TryGetComponent(out WateringCan wCan))
                currComponent = wCan;

            else if(TryGetComponent(out Plant plant)){
                currComponent = plant;
            }

            if(TryGetComponent(out Pot pot))
            {
                this.pot = pot;
            }
        }

        void OnMouseOver()
        {
                //Information popup
                Delegate.InformationElement hElement;
                hElement.elementName = elementName;
                hElement.mouseOver = true;               
                
                if (pot)
                {
                    hElement.textToShow = pot.GetTextInfo();
                }
                else
                { 
                    hElement.textToShow = textToShow;
                }

                hElement.component = null;

                delegates[0].Run(hElement);

                ///////////
            
                //Cursor delegate
                
                Delegate.InformationElement hCursor;
                hCursor.elementName = elementName;
                hCursor.mouseOver = true;
                hCursor.textToShow = "";


                hCursor.component = currComponent;
                if (delegates.Length > 1 && delegates[1] != null)
                { 
                    delegates[1].Run(hCursor);
                }
            
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

              
                hCursor.component = currComponent;
                if (delegates.Length > 1 && delegates[1] != null)
                {
                    delegates[1].Run(hCursor);
                }

        }

        void OnMouseDown()
        {
            if (delegates.Length > 2 && delegates[2] != null)
            {
                delegates[2].Run(currComponent);
            }
            
        }


    }
}
