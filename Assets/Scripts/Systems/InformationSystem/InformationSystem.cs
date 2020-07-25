using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class InformationSystem : MonoBehaviour
    {

        public Texture2D waterCanCursorTexture;
        public Texture2D fertilizationCursorTexture;

    [HideInInspector]
        public enum CURSOR_STATE { WATERINGCAN, DEFAULT, FERTILIZATIONMODE }
        private CURSOR_STATE currCursorState = CURSOR_STATE.DEFAULT;
        private bool isOverWateringCan = false;
        private bool isOverFertilizer = false;

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

                if (infoElement.component is WateringCan)
                {
                    SetCursorImg(waterCanCursorTexture,CURSOR_STATE.WATERINGCAN);
                    isOverWateringCan = true;
                }
                else if(infoElement.component is FertilizationEffect){
                    SetCursorImg(fertilizationCursorTexture,CURSOR_STATE.FERTILIZATIONMODE);
                    isOverFertilizer = true;
                }
            }

            else if (!PlayerController.Instance.IsUsingWaterCan && !PlayerController.Instance.IsUsingFertilizer)
            {
                SetCursorImg(null,CURSOR_STATE.DEFAULT);
                isOverWateringCan = false;
                isOverFertilizer = false;
            }

        }

    
        public void SetCursorImg(Texture2D cursortTex, CURSOR_STATE cState)
        {

            currCursorState = cState;
            Cursor.SetCursor(cursortTex, Vector2.zero, CursorMode.Auto);
        }

        public void ChangeFertilizationCursor(bool active){
            PlayerController.Instance.IsUsingFertilizer = active;
            Texture2D texture = active ? fertilizationCursorTexture : null;

            InformationSystem.CURSOR_STATE cState = active ? 
                CURSOR_STATE.FERTILIZATIONMODE : CURSOR_STATE.DEFAULT;
            
            SetCursorImg(texture,cState);
        }

        public void ElementClicked(Component component)
        {

        }

        public void Update()
        {
            Debug.Log(currCursorState);
            Debug.Log(isOverWateringCan);
            if (Input.GetMouseButtonDown(0))
            {
                if (isOverWateringCan)
                {
                    PlayerController.Instance.IsUsingWaterCan = true;
                    SetCursorImg(waterCanCursorTexture,CURSOR_STATE.WATERINGCAN);                   
                }
                /*else if(isOverFertilizer){
                    PlayerController.Instance.IsUsingFertilizer = true;
                    SetCursorImg(waterCanCursorTexture,CURSOR_STATE.FERTILIZATIONMODE);
                }*/
            }

            if (Input.GetMouseButtonDown(1))
            {
                PlayerController.Instance.IsUsingWaterCan = false;
                PlayerController.Instance.IsUsingFertilizer = false;

                isOverWateringCan = isOverFertilizer = false;
                SetCursorImg(null,CURSOR_STATE.DEFAULT);

            }

        }
    }
}