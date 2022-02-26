using UnityEngine;

namespace RoundsSystem
{
	public class PlayerLifeManager : MonoBehaviour
	{
		[field: SerializeField]
		private GameObject PlayerPrefab { get; set; }
		[field: SerializeField]
		private Transform SpawnPoint { get; set; }

		private GameObject CachedPlayerPrefab { get; set; }

		public void SpawnPlayer ()
		{
			CachedPlayerPrefab = Instantiate(PlayerPrefab);
			CachedPlayerPrefab.transform.position = SpawnPoint.position;
		}

		public void KillPlayer ()
		{
			Destroy(CachedPlayerPrefab);
		}
	}
}