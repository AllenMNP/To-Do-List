using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVariables : MonoBehaviour {

	string EventURL = "http://localhost/todo_list_app/delete_event.php";
	public string event_ID;
	public GameObject event_panel;
	public Text[] texts;

	void Start(){
		
	}

	// Use this for initialization
	public void buttonController(){
		if(GameObject.Find("Main Camera").GetComponent<DeleteButton>().deleting){
			deleteEvent();
		}
		else{
			event_panel = GameObject.Find("Canvas/Event Panel");
			texts = event_panel.GetComponentsInChildren<Text>();
			showInformation();
		}
	}
	
	public void deleteEvent(){
		WWWForm form = new WWWForm();
		form.AddField("IDPost", event_ID);

		WWW www = new WWW(EventURL, form);
	}

	public void showInformation(){
		GameObject.Find("Main Camera").GetComponent<EventPanel>().showEPanel();
		string event_to_assign = GameObject.Find("Main Camera").GetComponent<DataLoader>().returnEventByID(event_ID);
		texts[0].text = GameObject.Find("Main Camera").GetComponent<DataLoader>().getDataVal(event_to_assign, "event");
		texts[1].text = GameObject.Find("Main Camera").GetComponent<EventGallery>().readableTime(GameObject.Find("Main Camera").GetComponent<DataLoader>().getDataVal(event_to_assign, "time_start"));
		texts[2].text = GameObject.Find("Main Camera").GetComponent<EventGallery>().readableTime(GameObject.Find("Main Camera").GetComponent<DataLoader>().getDataVal(event_to_assign, "time_end"));
		texts[3].text = GameObject.Find("Main Camera").GetComponent<DataLoader>().getDataVal(event_to_assign, "notes_field");
		
	}
}
