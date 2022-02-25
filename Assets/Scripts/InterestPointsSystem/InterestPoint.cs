using UnityEngine;

namespace InterestPointsSystem
{
	public class InterestPoint : MonoBehaviour
	{
		private InterestPointObjectData Data { get; set; }
		private InterestPointsSpawner PointsSpawner { get; set; }

		public void InteractedReaction ()
		{
			PointsSpawner.SpawnInterestPoints(Data.ConnectedInterestPoints);
			Destroy(gameObject);
		}

		public void SetData (InterestPointObjectData newData)
		{
			Data = newData;
		}

		public void SetPointSpawnerReference (InterestPointsSpawner pointSpawnerReference)
		{
			PointsSpawner = pointSpawnerReference;
		}

		public void SpawnRepresentation ()
		{
			GameObject newRepresentationObject = Data.RepresentationPrefab;
			newRepresentationObject.transform.position = transform.position;
		}
	}
}