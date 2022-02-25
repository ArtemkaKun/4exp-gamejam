using UnityEngine;

namespace InterestPointsSystem
{
	public class InterestPointsSpawner : MonoBehaviour
	{
		[field: SerializeField]
		private GameObject InterestPointPrefab { get; set; }
		[field: SerializeField]
		private InterestPointObjectData FirstInterestPoint { get; set; }

		private void Awake ()
		{
			SpawnInterestPoint(FirstInterestPoint);
		}

		public void SpawnInterestPoints (InterestPointObjectData[] dataCollection)
		{
			for (int dataIndex = 0; dataIndex < dataCollection.Length; dataIndex++)
			{
				SpawnInterestPoint(dataCollection[dataIndex]);
			}
		}

		private void SpawnInterestPoint (InterestPointObjectData data)
		{
			GameObject newInterestPoint = Instantiate(InterestPointPrefab);
			InterestPoint interestPointComponent = newInterestPoint.GetComponent<InterestPoint>();
			interestPointComponent.SetData(data);
			interestPointComponent.SetPointSpawnerReference(this);
			interestPointComponent.SpawnRepresentation();
		}
	}
}