using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace Garden
{
    public class InformationSystem : MonoBehaviour
    {

        public Texture2D waterCanCursorTexture;
        public Texture2D fertilizationCursorTexture;
        public Texture2D scissorsCursorTexture;
        public Texture2D trashCanCursorTexture;

        [HideInInspector]
        public enum CURSOR_STATE { WATERINGCAN, DEFAULT, FERTILIZATIONMODE, SCISSORS, TRASHCAN }
        private CURSOR_STATE currCursorState = CURSOR_STATE.DEFAULT;
        private bool isOverWateringCan = false;
        private bool isOverFertilizer = false;
        private bool isOverScissors = false;
        private bool isOverTrashCan = false;

        //public WateringCan wateringCanComponent;

        private bool isOverPlant = false;
        private Plant currPlant = null;

        [SerializeField] WindowCollision windowCollision;

        public void ShowHoverInfo(Delegate.InformationElement hoverElement)
        {
            if (hoverElement.mouseOver) //If mouse is over que show info
            {
                StartCoroutine("FollowingMouse");
                windowCollision.rectTransform.gameObject.SetActive(true);
            }
            else
            {
                StopCoroutine("FollowingMouse");
                windowCollision.rectTransform.gameObject.SetActive(false);
            }
            windowCollision.rectTransform.GetComponentInChildren<TextMeshProUGUI>().SetText(hoverElement.textToShow);
        }
        public void PlantCutted(){
            SetCursorImg(trashCanCursorTexture, CURSOR_STATE.TRASHCAN);
            PlayerController.Instance.IsUsingTrashCan = true;
            isOverWateringCan = false;
                isOverFertilizer = false;
                isOverScissors = false;
                isOverTrashCan = true;

        }
        public void ChangeMouse(Delegate.InformationElement infoElement)
        {
            if (infoElement.mouseOver && PlayerController.Instance.CanInteract)
            {

                if (infoElement.component is WateringCan)
                {
                    SetCursorImg(waterCanCursorTexture, CURSOR_STATE.WATERINGCAN);
                    isOverWateringCan = true;
                }

                else if (infoElement.component is FertilizationEffect)
                {
                    SetCursorImg(fertilizationCursorTexture, CURSOR_STATE.FERTILIZATIONMODE);
                    isOverFertilizer = true;
                }
                else if (infoElement.component is Scissors)
                {
                    SetCursorImg(scissorsCursorTexture, CURSOR_STATE.SCISSORS);
                    isOverScissors = true;
                }
                else if (infoElement.component is TrashCan)
                {
                    SetCursorImg(trashCanCursorTexture, CURSOR_STATE.TRASHCAN);
                    isOverTrashCan = true;
                }
            }

            else if (!PlayerController.Instance.IsUsingWaterCan && !PlayerController.Instance.IsUsingFertilizer
            && !PlayerController.Instance.IsUsingScissors && !PlayerController.Instance.IsUsingTrashCan)
            {
                SetCursorImg(null, CURSOR_STATE.DEFAULT);
                isOverWateringCan = false;
                isOverFertilizer = false;
                isOverScissors = false;
                isOverTrashCan = false;

            }

        }


        public void SetCursorImg(Texture2D cursortTex, CURSOR_STATE cState)
        {

            currCursorState = cState;
            Cursor.SetCursor(cursortTex, Vector2.zero, CursorMode.Auto);
        }

        public void ChangeFertilizationCursor(bool active)
        {
            PlayerController.Instance.IsUsingFertilizer = active;
            Texture2D texture = active ? fertilizationCursorTexture : null;

            InformationSystem.CURSOR_STATE cState = active ?
                CURSOR_STATE.FERTILIZATIONMODE : CURSOR_STATE.DEFAULT;

            SetCursorImg(texture, cState);
        }

        public void ElementClicked(Component component)
        {

        }

        private void DisableALL(){
             PlayerController.Instance.IsUsingWaterCan = false;
                PlayerController.Instance.IsUsingFertilizer = false;
                PlayerController.Instance.IsUsingScissors = false;
                PlayerController.Instance.IsUsingTrashCan = false;

                isOverWateringCan = isOverFertilizer =  isOverScissors= isOverTrashCan = false;
                SetCursorImg(null, CURSOR_STATE.DEFAULT);
        }
        public void TrashCanUsed(){
            DisableALL();

        }
        public void Update()
        {
            Debug.Log(currCursorState);
            if (Input.GetMouseButtonDown(0))
            {
                if (isOverWateringCan)
                {
                    PlayerController.Instance.IsUsingWaterCan = true;
                    SetCursorImg(waterCanCursorTexture, CURSOR_STATE.WATERINGCAN);
                }
                else if(isOverScissors){
                    PlayerController.Instance.IsUsingScissors = true;
                    SetCursorImg(scissorsCursorTexture,CURSOR_STATE.SCISSORS);
                }
                else if(isOverTrashCan){
                    PlayerController.Instance.IsUsingTrashCan = true;
                    SetCursorImg(scissorsCursorTexture,CURSOR_STATE.TRASHCAN);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                DisableALL();
            }

        }

        IEnumerator FollowingMouse()
        {
            while (true)
            {
                Vector3 convertedMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                Vector2 newPosition = windowCollision.CalculatePosition(new Vector2(convertedMousePosition.x, convertedMousePosition.y));

                if (newPosition != Vector2.negativeInfinity)
                { 
                    windowCollision.rectTransform.position = Vector2.Lerp(windowCollision.rectTransform.position, newPosition, UnityEngine.Time.deltaTime);
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }


        [Serializable]
    public class WindowCollision
    {
        Box window = new Box(new Vector2(2048 * 0.5f, 1535 * 0.5f),
                                       2048,
                                        1535);

        [SerializeField] public RectTransform rectTransform;
        [SerializeField] float margin;

        struct Box
        {
            public Vector2 center;
            public float width;
            public float height;

            public Box(Vector2 center, float width, float height)
            {
                this.center = center;
                this.width = width;
                this.height = height;
            }

            /// <summary>
            /// Check if two box collides
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public bool CollidesBox(Box other)
            {
                float halfWidth = width * 0.5f;
                float halfHeight = height * 0.5f;

                Vector2 point1 = new Vector2(center.x + halfWidth, center.y + halfHeight);
                Vector2 point2 = new Vector2(center.x + halfWidth, center.y - halfHeight);
                Vector2 point3 = new Vector2(center.x - halfWidth, center.y + halfHeight);
                Vector2 point4 = new Vector2(center.x - halfWidth, center.y - halfHeight);

                return other.ContainsPoint(point1) && other.ContainsPoint(point2) && other.ContainsPoint(point3) && other.ContainsPoint(point4);
            }

            /// <summary>
            /// Check if a point is inside of this box
            /// </summary>
            /// <param name="point"></param>
            /// <returns></returns>
            private bool ContainsPoint(Vector2 point)
            {
                float halfWidth = width * 0.5f;
                float halfHeight = height * 0.5f;

                return point.x < center.x + halfWidth &&
                        point.y < center.y + halfHeight &&
                        point.x > center.x - halfWidth &&
                        point.y > center.y - halfHeight;
            }
        }

        /// <summary>
        /// Returns the position of the panel
        /// </summary>
        /// <param name="mousePosition"></param>
        /// <returns></returns>
        public Vector2 CalculatePosition(Vector2 mousePosition)
        {
            mousePosition = new Vector2(mousePosition.x * Screen.width, mousePosition.y * Screen.height);
            Box upPosition = new Box(
                                        new Vector2(mousePosition.x, mousePosition.y + margin + rectTransform.rect.height),
                                        rectTransform.rect.width * 2f,
                                        rectTransform.rect.height * 2f
                                    );

            Box rightPosition = new Box(
                                        new Vector2(mousePosition.x + margin + rectTransform.rect.width, mousePosition.y),
                                        rectTransform.rect.width * 2f,
                                        rectTransform.rect.height * 2f
                                    );

            Box leftPosition = new Box(
                                        new Vector2(mousePosition.x - margin - rectTransform.rect.width, mousePosition.y),
                                        rectTransform.rect.width * 2f,
                                        rectTransform.rect.height * 2f
                                    );

            Box downPosition = new Box(
                                        new Vector2(mousePosition.x, mousePosition.y - margin - rectTransform.rect.height),
                                        rectTransform.rect.width * 2f,
                                        rectTransform.rect.height * 2f
                                    );

            if (upPosition.CollidesBox(window)) return upPosition.center;
            if (rightPosition.CollidesBox(window)) return rightPosition.center;
            if (leftPosition.CollidesBox(window)) return leftPosition.center;
            if (downPosition.CollidesBox(window)) return downPosition.center;

            return Vector2.negativeInfinity;
        }

    }


}
