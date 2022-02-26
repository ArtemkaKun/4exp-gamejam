using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NamesGenerator : MonoBehaviour
{
	[field: SerializeField]
	private List<string> NamesCollection { get; set; } = new List<string>();

	public string GetRandomName ()
	{
		return NamesCollection.Count > 0 ? NamesCollection[Random.Range(0, NamesCollection.Count - 1)] : string.Empty;
	}
}
