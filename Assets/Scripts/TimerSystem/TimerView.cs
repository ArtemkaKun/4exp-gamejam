using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;

namespace TimerSystem
{
	public class TimerView : MonoBehaviour
	{
		[field: SerializeField]
		private TMP_Text LeftTextElement { get; set; }
		[field: SerializeField]
		private TMP_Text YearsTextElement { get; set; }
		[field: SerializeField]
		private GameObject TimerObject { get; set; }
		[field: SerializeField]
		private GameObject YearsObject { get; set; }
		[field: SerializeField]
		private TMP_Text AdditionalTimeTextElement { get; set; }
		[field: SerializeField]
		private GameObject AdditionalTimeObject { get; set; }
		[field: SerializeField]
		private int AdditionalTimeVisibilityInSeconds { get; set; }

		public void SetLeftTime (TimeSpan leftTime)
		{
			LeftTextElement.text = leftTime.ToString(@"mm\:ss");
		}

		public void ChangeTimerTextVisibility (bool isVisible)
		{
			TimerObject.SetActive(isVisible);
			YearsObject.SetActive(isVisible);
		}

		public void SetYears (float years)
		{
			YearsTextElement.text = $"Age: {years}";
		}

		public async UniTaskVoid ShowAdditionalTimeText (int additionalTimeValue)
		{
			AdditionalTimeTextElement.text = $"+{additionalTimeValue}";
			AdditionalTimeObject.SetActive(true);
			await UniTask.Delay(TimeSpan.FromSeconds(AdditionalTimeVisibilityInSeconds));
			AdditionalTimeObject.SetActive(false);
		}
	}
}