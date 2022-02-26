using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TimerSystem
{
	public class Timer : MonoBehaviour
	{
		public event Action OnTimerEnd;

		[field: SerializeField]
		private int TimeInSeconds { get; set; }
		[field: SerializeField]
		private int StepInSeconds { get; set; }
		[field: SerializeField]
		private TimerView View { get; set; }
		[field: SerializeField]
		private float InitialNumberOfYears { get; set; }
		[field: SerializeField]
		private float SecondsPerYear { get; set; }

		private int LeftTime { get; set; }

		[Button]
		public void StartTimer ()
		{
			TimerProcess().Forget();
		}

		public void IncreaseLeftTime (int additionalSeconds)
		{
			LeftTime += additionalSeconds;
			View.ShowAdditionalTimeText(additionalSeconds).Forget();
		}

		private void Awake ()
		{
			View.SetLeftTime(TimeSpan.FromSeconds(TimeInSeconds));
		}

		private async UniTaskVoid TimerProcess ()
		{
			LeftTime = TimeInSeconds;
			View.SetLeftTime(TimeSpan.FromSeconds(LeftTime));
			View.SetYears(CountYears(LeftTime));
			View.ChangeTimerTextVisibility(true);

			while (LeftTime > 0)
			{
				await UniTask.Delay(TimeSpan.FromSeconds(StepInSeconds));
				LeftTime -= StepInSeconds;
				View.SetLeftTime(TimeSpan.FromSeconds(LeftTime));
				View.SetYears(CountYears(LeftTime));
			}

			View.SetLeftTime(TimeSpan.Zero);
			View.SetYears(InitialNumberOfYears);
			OnTimerEnd?.Invoke();
			View.ChangeTimerTextVisibility(false);
		}

		private float CountYears (int leftTime)
		{
			return InitialNumberOfYears + Mathf.Floor((TimeInSeconds - leftTime) / SecondsPerYear);
		}
	}
}