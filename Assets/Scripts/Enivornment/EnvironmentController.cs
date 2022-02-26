using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnvironmentController : MonoBehaviour
{
	[SerializeField] private UnityEvent testEvent;
	[SerializeField] private Animator animator;

	protected virtual void Start ()
	{
		//animator.speed = 0f;
	}

	[Button]
	private void TriggerEvent ()
	{
		Debug.Log("dupa");
		//testEvent.Invoke();
		animator.SetFloat("VisualizationTime", 0.5f);
	}
}
