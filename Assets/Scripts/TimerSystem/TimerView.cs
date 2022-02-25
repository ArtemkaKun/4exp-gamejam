using System;
using TMPro;
using UnityEngine;

namespace TimerSystem
{
	public class TimerView : MonoBehaviour
	{
		[field: SerializeField]
		private TMP_Text LeftTextElement { get; set; }

		public void SetLeftTime (TimeSpan leftTime)
		{
			LeftTextElement.text = leftTime.ToString(@"mm\:ss");
		}
	}
}