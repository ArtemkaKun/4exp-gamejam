using UnityEngine;

namespace InterestPointsSystem
{
	[CreateAssetMenu(fileName = ASSET_NAME, menuName = "InterestPoint/" + ASSET_NAME)]
	public class InterestPointObjectData : ScriptableObject
	{
		private const string ASSET_NAME = nameof(InterestPointObjectData);

		[field: SerializeField]
		public GameObject RepresentationPrefab { get; private set; }
		[field: SerializeField]
		public InterestPointObjectData[] ConnectedInterestPoints { get; private set; }
	}
}