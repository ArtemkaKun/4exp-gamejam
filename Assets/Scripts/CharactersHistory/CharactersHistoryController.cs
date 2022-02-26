using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharactersHistoryController : MonoBehaviour
{
	[field: SerializeField]
	private NamesGenerator NamesGenerator { get; set; }
	[field: SerializeField]
	private GameObject CharactersHolder { get; set; }

	public void AddNewCharacter (float age)
	{
		GameObject item = new GameObject();
		TextMeshProUGUI info = item.AddComponent<TextMeshProUGUI>();
		info.text = $"{NamesGenerator.GetRandomName()} {age} yo";
		item.GetComponent<RectTransform>().SetParent(CharactersHolder.transform);
		item.transform.localScale = new Vector3(1, 1, 1);
		Instantiate(item);
		item.SetActive(true);
	}
}
