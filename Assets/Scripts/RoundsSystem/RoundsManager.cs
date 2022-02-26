using TimerSystem;
using UnityEngine;

namespace RoundsSystem
{
	public class RoundsManager : MonoBehaviour
	{
		[field: SerializeField]
		private Timer Timer { get; set; }
		[field: SerializeField]
		private PlayerLifeManager PlayerLifeManager { get; set; }

		private void Awake ()
		{
			StartRound();
		}
		
		private void StartRound ()
		{
			PlayerLifeManager.SpawnPlayer();
			Timer.OnTimerEnd += FinishRound;
			Timer.StartTimer();
		}

		private void FinishRound ()
		{
			PlayerLifeManager.KillPlayer();
		}
	}
}