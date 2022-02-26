using System;
using TMPro;
using UnityEngine;

namespace TimerSystem
{
    public class TimerView : MonoBehaviour
    {
        [field: SerializeField]
        private TMP_Text MiddleTextElement { get; set; }
        [field: SerializeField]
        private TMP_Text LeftTextElement { get; set; }
        [field: SerializeField]
        private GameObject TimerObject { get; set; }
        [field: SerializeField]
        private GameObject YearsObject { get; set; }

        public void SetLeftTime(TimeSpan leftTime)
        {
            MiddleTextElement.text = leftTime.ToString(@"mm\:ss");
        }

        public void ChangeTimerTextVisibility(bool isVisible)
        {
            TimerObject.SetActive(isVisible);
            YearsObject.SetActive(isVisible);
        }

        public void SetYears(float years)
        {
            LeftTextElement.text = $"{years} yo";
        }
    }
}