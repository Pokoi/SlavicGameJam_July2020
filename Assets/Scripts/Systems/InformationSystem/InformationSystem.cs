using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class InformationSystem : MonoBehaviour
    {

        public Texture2D waterCanCursorTexture;

        private enum CURSOR_STATE { WATERINGCAN, DEFAULT }
        private CURSOR_STATE currCursorState = CURSOR_STATE.DEFAULT;
        private bool isOverWateringCan = false;

        //public WateringCan wateringCanComponent;

        private bool isOverPlant = false;
        private Plant currPlant = null;

        public void ShowHoverInfo(Delegate.InformationElement hoverElement)
        {
            if (hoverElement.mouseOver) //If mouse is over que show info
            {
                
            }
        }

        public void ChangeMouse(Delegate.InformationElement infoElement)
        {
            if (infoElement.mouseOver)
            {

                Texture2D cursortTex = null;

                if (infoElement.component is WateringCan)
                {
                    SetWateringCanCursor(true);
                }
            }

            else if (!PlayerController.Instance.IsUsingWaterCan)
            {
                SetWateringCanCursor(false);
            }

        }

        public void SetWateringCanCursor(bool status)
        {

            currCursorState = status ? CURSOR_STATE.WATERINGCAN : CURSOR_STATE.DEFAULT;
            Texture2D cursortTex = status ? waterCanCursorTexture : null;
            isOverWateringCan = status;            
            Cursor.SetCursor(cursortTex, Vector2.zero, CursorMode.Auto);
        }


        public void ElementClicked(Component component)
        {

        }

        public void Update()
        {
            Debug.Log(currCursorState);
            if (Input.GetMouseButtonDown(0))
            {
                if (isOverWateringCan)
                {
                    PlayerController.Instance.IsUsingWaterCan = true;
                    SetWateringCanCursor(true);                   
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                PlayerController.Instance.IsUsingWaterCan = false;
                SetWateringCanCursor(false);

            }

        }
    }
}