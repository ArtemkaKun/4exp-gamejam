using Cinemachine;
using UnityEngine;

namespace PlayerSystem
{
	public class PlayerCameraUpdater : MonoBehaviour
	{
		[field: SerializeField]
		private CinemachineBrain CameraBrain { get; set; }

		private void Update ()
		{
			CameraBrain.ManualUpdate();
		}
	}
}