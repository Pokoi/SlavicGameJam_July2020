using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Garden
{ 

    public class Calendar : MonoBehaviour
    {
        [SerializeField] Month [] months;

        [SerializeField] Sprite[] numbers;

        [SerializeField] SpriteRenderer firstNumber;
        [SerializeField] SpriteRenderer secondNumber;
        [SerializeField] SpriteRenderer monthImage;

        int dayCount;
        int monthCount;

        private void Start()
        {
            dayCount = 20;
            monthCount = 5;

            firstNumber.sprite = (int)(dayCount * 0.1f) == 0 ? null : numbers[(int)(dayCount * 0.1f)];
            secondNumber.sprite = numbers[(int)dayCount % 10];

            monthImage.sprite = months[monthCount].header;

        }


        public void ChangeDay()
        {
            dayCount++;

            if (dayCount> months[monthCount].days)
            {
                ChangeMonth();
            }

            firstNumber.sprite = (int) (dayCount * 0.1f)  == 0 ? null : numbers[(int) (dayCount * 0.1f)];
            secondNumber.sprite = numbers[((int)dayCount % 10) ];
        }

        public void ChangeMonth()
        {
            ++monthCount;

            if (monthCount >= months.Length)
            {
                monthCount = 0;
            }

            monthImage.sprite = months[monthCount].header;

            dayCount = 1;
        }

    }

    [Serializable]
    public class Month
    {
        [SerializeField] public Sprite header;
        [SerializeField] public int days;

    }

}