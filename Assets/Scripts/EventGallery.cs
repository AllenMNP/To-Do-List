using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventGallery : MonoBehaviour {

	public GameObject buttonPref;
	public GameObject buttonContainer;
	public string[] eventData;
	// Use this for initialization
	public void createButtons() {
		eventData = gameObject.GetComponent<DataLoader>().getEventData();

		for(int i = 0; i < eventData.Length - 1; i++){
			GameObject new_button = Instantiate(buttonPref) as GameObject;
			new_button.transform.SetParent(buttonContainer.transform,false);
			Text[] texts = new_button.GetComponentsInChildren<Text>();
			texts[0].text = gameObject.GetComponent<DataLoader>().getDataVal(eventData[i],"event");
			texts[1].text = readableTime(gameObject.GetComponent<DataLoader>().getDataVal(eventData[i],"time_end"));
			new_button.GetComponent<ButtonVariables>().event_ID = gameObject.GetComponent<DataLoader>().getDataVal(eventData[i],"user_id");
			
			switch(gameObject.GetComponent<DataLoader>().getDataVal(eventData[i],"priority")){
				case "1":
					new_button.GetComponent<Image>().color = new Color32(255,255,255,255);
					break;
				case "2":
					new_button.GetComponent<Image>().color = new Color32(120,160,255,255);
					break;
				case "3":
					new_button.GetComponent<Image>().color = new Color32(255,100,100,255);
					break;
			}
			
		}
	}

	public void createOneButton(string eventData){
		GameObject new_button = Instantiate(buttonPref) as GameObject;
		new_button.transform.SetParent(buttonContainer.transform,false);
		Text[] texts = new_button.GetComponentsInChildren<Text>();
		texts[0].text = gameObject.GetComponent<DataLoader>().getDataVal(eventData,"event");
		texts[1].text = readableTime(gameObject.GetComponent<DataLoader>().getDataVal(eventData,"time_end"));
		new_button.GetComponent<ButtonVariables>().event_ID = gameObject.GetComponent<DataLoader>().getDataVal(eventData,"user_id");

		switch(gameObject.GetComponent<DataLoader>().getDataVal(eventData,"priority")){
				case "1":
					new_button.GetComponent<Image>().color = new Color32(255,255,255,255);
					break;
				case "2":
					new_button.GetComponent<Image>().color = new Color32(120,160,255,255);
					break;
				case "3":
					new_button.GetComponent<Image>().color = new Color32(255,100,100,255);
					break;
			}
	}

	public string readableTime(string military_time){
		//string hour = 12:23:00
		string ampm = "AM";
		string hour = military_time.Substring(11,2);
		Debug.Log(hour);
		int hour_int = int.Parse(hour);
		if(hour_int > 12){
			hour_int -= 12;
			ampm = "PM";
		}
		hour = hour_int.ToString();
		string minute = military_time.Substring(13,3);

		return military_time.Substring(0,11) + hour + minute + " " + ampm;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
