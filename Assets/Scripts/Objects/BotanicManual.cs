using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Garden
{ 
    public class BotanicManual : MonoBehaviour
    {

        [SerializeField] GameObject canvasPanel;
        [SerializeField] GameObject canvasBotanicBook;
        [SerializeField] GameObject canvasXButton;
        
        [SerializeField] TextMeshProUGUI [] plantTexts;
        

        public TextMeshProUGUI GetTextAt (int index)
        {
            if (index < plantTexts.Length)
            { 
                return plantTexts[index];            
            }

            return null;
        }

        public void UpdateText( 
                                TextMeshProUGUI text,
                                string irrigation,
                                string lightExposition,
                                string temperature,
                                string fertilization,
                                string fertilizerType,
                                string growing
                               )
        {
            text.SetText(
                            "Irrigation: this plant requires " + irrigation + " substratum." + "\n" +
                            "Light: this plant requires " + lightExposition + " sun exposition. " + "\n" +
                            "Temperature: " + temperature + "ºC. " + "\n" +
                            "Fertilization: the substratum needs " + fertilization + " fertilizer." + "\n" +
                            "Fertilizer type: " + fertilizerType + "\n" +
                            "Growing: Each " + growing + " days." + "\n"
                        );
        }

        private void OnMouseDown()
        {
            canvasPanel.SetActive(true);
            canvasBotanicBook.SetActive(true);
            canvasXButton.SetActive(true);
            PlayerController.Instance.CanInteract = false;
        }

    }
}

