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

        public WateringCan wateringCanComponent;

        private bool isOverPlant = false;
        private Plant currPlant = null;

        public void ShowHoverInfo(Delegate.InformationElement hoverElement)
        {
            if (hoverElement.mouseOver) //If mouse is over que show info
            {
                if (hoverElement.component is Plant)
                {
                    Debug.Log(hoverElement.textToShow);
                }

            }
        }

        public void ChangeMouse(Delegate.InformationElement infoElement)
        {
            if (infoElement.mouseOver)
            {

                Texture2D cursortTex = null;

                if (infoElement.component is WateringCan)
                {
                    cursortTex = waterCanCursorTexture;
                    isOverWateringCan = true;
                    Cursor.SetCursor(cursortTex, Vector2.zero, CursorMode.Auto);
                }
            }

            else if (currCursorState == CURSOR_STATE.DEFAULT)
            {
                isOverWateringCan = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }

        }


        public void ElementClicked(Component component)
        {

            if (component is Plant && currCursorState == CURSOR_STATE.WATERINGCAN)
            {
                wateringCanComponent.GetWateringCanEffect.Execute(component as Plant);
            }

        }

        public void Update()
        {
            Debug.Log(currCursorState);
            if (Input.GetMouseButtonDown(0))
            {
                if (isOverWateringCan)
                    currCursorState = CURSOR_STATE.WATERINGCAN;
            }

            if (Input.GetMouseButtonDown(1))
            {
                currCursorState = CURSOR_STATE.DEFAULT;
                isOverWateringCan = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }

        }
    }
}