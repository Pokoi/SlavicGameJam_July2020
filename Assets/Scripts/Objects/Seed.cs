using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{ 
    public class Seed : MonoBehaviour
    {
        [SerializeField] GameObject canvasPanel;
        [SerializeField] GameObject canvasSeedCardsBook;
        [SerializeField] GameObject canvasXButton;

        private void OnMouseDown()
        {
            canvasPanel.SetActive(true);
            canvasSeedCardsBook.SetActive(true);
            canvasXButton.SetActive(true);
            PlayerController.Instance.CanInteract = false;
        }
    }
}
