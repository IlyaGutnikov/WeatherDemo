using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherListScrollView : MonoBehaviour {


	[SerializeField]
	Text headerText;

	[SerializeField]
	ScrollRect scrollRect;

	RectTransform content;

	[SerializeField]
	GameObject scrollViewItem;

	// Use this for initialization
	void Awake () {

		content = scrollRect.content;
	}

	/// <summary>
	/// Sets the header text.
	/// </summary>
	/// <param name="_text">Text.</param>
	public void SetHeaderText(string _text) {
	
		this.headerText.text = _text;
	}
    /*

	/// <summary>
	/// Добавляет один элемент в ScrollView
	/// </summary>
	/// <param name="_mafiaPlayer">Mafia player.</param>
	public void AddPlayerListItem(MafiaPlayerScript _mafiaPlayer) {

		GameObject _scrollViewItem = Instantiate(scrollViewItem) as GameObject;
		_scrollViewItem.transform.SetParent (content.transform);
		_scrollViewItem.transform.localScale = new Vector3(1, 1, 1);
		_scrollViewItem.GetComponent<PlayerListScrollViewItem> ().SetItemInfo (_mafiaPlayer);

	}

	/// <summary>
	/// Добавляет все элементы в ScrollView
	/// </summary>
	/// <param name="_mafiaPlayers">Mafia players.</param>
	public void AddAllPlayerListItems(List<MafiaPlayerScript> _mafiaPlayers) {
	
		for (int i = 0; i < _mafiaPlayers.Count; i++) {
		
			AddPlayerListItem (_mafiaPlayers [i]);
		}
	}

	/// <summary>
	/// Deletes all player list items.
	/// </summary>
	public void DeleteAllPlayerListItems() {

		PlayerListScrollViewItem[] _playersItemGameObject = content.GetComponentsInChildren<PlayerListScrollViewItem> ();

		for (int i = 0; i < _playersItemGameObject.Length; i++) {
		
			Destroy (_playersItemGameObject [i].gameObject);
		}
	}
    */

}
