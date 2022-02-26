using InventorySystem;
using TimerSystem;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace RoundsSystem
{
	public class RoundsManager : MonoBehaviour
	{
		[field: SerializeField]
		private Timer Timer { get; set; }
		[field: SerializeField]
		private PlayerLifeManager PlayerLifeManager { get; set; }
		[field: SerializeField]
		private GameObject RoundEndedCanvas { get; set; }
		[field: SerializeField]
		private InventoryManager Inventory { get; set; }
		[field: SerializeField]
		private CharactersHistoryController CharactersHistory { get; set; }

		[field: SerializeField] private IntVariable RoundsCounter { get; set; }

		public void StartRound ()
		{
			RoundEndedCanvas.SetActive(false);
			PlayerLifeManager.ChangePlayerActiveStatus(true);
			Cursor.lockState = CursorLockMode.Locked;
			Timer.StartTimer();
			RoundsCounter.Value += 1;
		}

		private void Start ()
		{
			Timer.OnTimerEnd += FinishRound;
			StartRound();
		}

		private void FinishRound (float numberOfYears)
		{
			Cursor.lockState = CursorLockMode.None;
			RoundEndedCanvas.SetActive(true);
			PlayerLifeManager.ChangePlayerActiveStatus(false);
			CharactersHistory.AddNewCharacter(numberOfYears);
		}
	}
}