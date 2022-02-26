using InventorySystem;
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
		[field: SerializeField]
		private GameObject RoundEndedCanvas { get; set; }
		[field: SerializeField]
		private InventoryManager Inventory { get; set; }

		private uint RoundsCounter { get; set; }

		public void StartRound ()
		{
			RoundEndedCanvas.SetActive(false);
			PlayerLifeManager.ChangePlayerActiveStatus(true);
			Cursor.lockState = CursorLockMode.Locked;
			Timer.StartTimer();
			RoundsCounter += 1;
		}

		private void Start ()
		{
			Timer.OnTimerEnd += FinishRound;
			StartRound();
		}

		private void FinishRound ()
		{
			Cursor.lockState = CursorLockMode.None;
			RoundEndedCanvas.SetActive(true);
			PlayerLifeManager.ChangePlayerActiveStatus(false);
			Inventory.RemoveAllItems();
		}
	}
}