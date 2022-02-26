using System.Collections;
using System.Collections.Generic;
using TimerSystem;
using UnityEngine;

public class WorldStatic : MonoBehaviour
{
	[field: SerializeField]
	private int IncreasePlayerLifeInSeconds { get; set; }
	
    protected virtual void OnEnable()
    {
        BoostPlayer();
    }

    private void BoostPlayer()
    {
		FindObjectOfType<Timer>().IncreaseLeftTime(IncreasePlayerLifeInSeconds);
	}
}
