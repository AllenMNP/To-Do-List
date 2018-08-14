using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPanel : MonoBehaviour {

	public GameObject event_panel;
	
	// Use this for initialization
	void Start () {
		hideEPanel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void hideEPanel(){
		event_panel.GetComponent<RectTransform>().localScale = new Vector3(0,0,0);
	}

	public void showEPanel(){
		event_panel.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
	}
}
