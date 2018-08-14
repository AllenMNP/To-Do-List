using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelVisibility : MonoBehaviour {

	public GameObject input_panel;
	public InputField event_field;
	public InputField year_field;
	public InputField month_field;
	public InputField day_field;
	public InputField hour_field;
	public InputField minute_field;
	public InputField ampm_field;
	public InputField priority_field;
	public InputField note_field;
	string hourText;

	// Use this for initialization
	void Start () {
		hidePanel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetInput(){

		string priority_text = priority_field.text;
		string event_text = event_field.text;
		string ampm_text = ampm_field.text;
		string note_text = note_field.text;

		if(ampm_text == "PM"){
			int hour = int.Parse(hour_field.text);
			int hour_changed = hour + 12;
			hourText = hour_changed.ToString();
		}
		else{
			hourText = hour_field.text;
		}
		string time_end_text = year_field.text + "-" + month_field.text + "-" + day_field.text + " " + hourText + ":" + minute_field.text + ":00";
		string time_begin_text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		string status_text = "Ongoing";
		
		
		gameObject.GetComponent<DataInserter>().createEvent("", event_text, time_begin_text, time_end_text, status_text, priority_text, note_text);
		
	}

	public void hidePanel(){
		event_field.text = "";
		year_field.text = "";
		month_field.text = "";
		day_field.text = "";
		hour_field.text = "";
		minute_field.text = "";
		ampm_field.text = "";
		priority_field.text = "";
		note_field.text = "";
		input_panel.gameObject.SetActive(false);

	}

	public void showPanel(){
		input_panel.gameObject.SetActive(true);
	}
}
