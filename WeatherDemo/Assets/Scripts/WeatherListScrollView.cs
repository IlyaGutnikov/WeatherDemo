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

	public void SetHeaderText(string _text) {
	
		this.headerText.text = _text;
	}
    
	public void AddWeatherListItem(CityWithWeather _cityWithWeather) {

		GameObject _scrollViewItem = Instantiate(scrollViewItem) as GameObject;
		_scrollViewItem.transform.SetParent (content.transform);
		_scrollViewItem.transform.localScale = new Vector3(1, 1, 1);
		_scrollViewItem.GetComponent<WeatherListItem> ().SetItemInfo (_cityWithWeather);

	}

	public void AddAllWeatherListItems(List<CityWithWeather> _cityWithWeathers) {
	
		for (int i = 0; i < _cityWithWeathers.Count; i++) {
		
			AddWeatherListItem (_cityWithWeathers[i]);
		}
	}

	public void DeleteAllWeatherListItems() {

		WeatherListItem[] _weatherItemGameObject = content.GetComponentsInChildren<WeatherListItem> ();

	    if (_weatherItemGameObject.Length > 0)
	    {
	        for (int i = 0; i < _weatherItemGameObject.Length; i++)
	        {

	            Destroy(_weatherItemGameObject[i].gameObject);
	        }
	    }
	}
    

}
