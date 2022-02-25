using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Timer : MonoBehaviour
{
	public event Action<int> OnLeftTimeChanged;
	
	[field: SerializeField]
	private int TimeInSeconds { get; set; }
	[field: SerializeField]
	private int StepInSeconds { get; set; }
	
	public void StartTimer ()
	{
		TimerProcess().Forget();
	}

	private async UniTaskVoid TimerProcess ()
	{
		int leftTime = TimeInSeconds;

		while (leftTime > 0)
		{
			OnLeftTimeChanged?.Invoke(leftTime);
			await UniTask.Delay(TimeSpan.FromSeconds(StepInSeconds));
			leftTime -= StepInSeconds;
		}
		
		OnLeftTimeChanged?.Invoke(0);
	}
}
