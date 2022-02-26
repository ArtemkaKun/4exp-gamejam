using DG.Tweening.Core;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class EnvironmentController : MonoBehaviour
{
	[field: SerializeField] private Animator TerrainAnimator { get; set; }
	[field: SerializeField] private GameObject TerrainGameObject { get; set; }
	[field: SerializeField] private GameObject WaterGameObject { get; set; }
	[field: SerializeField] private GameObject FlatPlaneGameObject { get; set; }
	[field: SerializeField] private IntVariable RoundsCounter { get; set; }

	[field: SerializeField] private int maxTerrainRound;

	private static readonly int VisualizationTimeHash = Animator.StringToHash("VisualizationTime");

	protected virtual void OnEnable ()
	{
		RoundsCounter.Changed.Register(UpdateTerrain);
	}

	protected virtual void OnDisable ()
	{
		RoundsCounter.Changed.Unregister(UpdateTerrain);
	}

	private void UpdateTerrain (int round)
	{
		if (round > maxTerrainRound)
		{
			TerrainAnimator.gameObject.SetActive(false);
			return;
		}
		else if (round == maxTerrainRound)
		{
			TerrainGameObject.SetActive(true);
			WaterGameObject.SetActive(true);
		}
		else if (round == 2)
		{
			FlatPlaneGameObject.SetActive(false);
		}

		TerrainAnimator.SetFloat(VisualizationTimeHash, (float)(round - 1) / maxTerrainRound);
	}
}
