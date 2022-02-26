using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace DefaultNamespace
{
	public class EndGameActivator : MonoBehaviour
	{
		[field: SerializeField]
		private GameObject GameOverCanvasObject { get; set; }
		
		private void OnEnable ()
		{
			StartEndGameProcess().Forget();
		}

		private async UniTaskVoid StartEndGameProcess ()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(10));
			GameOverCanvasObject.GetComponent<Canvas>().sortingOrder = 100;
			GameOverCanvasObject.SetActive(true);
		}
	}
}