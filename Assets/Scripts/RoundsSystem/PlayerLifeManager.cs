using UnityEngine;

namespace RoundsSystem
{
	public class PlayerLifeManager : MonoBehaviour
	{
		[field: SerializeField]
		private GameObject PlayerObject { get; set; }
		[field: SerializeField]
		private Transform PlayerObjectTransform { get; set; }
		[field: SerializeField]
		private Transform SpawnPoint { get; set; }

		public void ChangePlayerActiveStatus (bool isActive)
		{
			if (isActive == true)
			{
				PlayerObjectTransform.position = SpawnPoint.position;
			}
			
			PlayerObject.SetActive(isActive);
		}
	}
}