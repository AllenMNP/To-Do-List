using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour {

	public bool deleting;
	public Text deletingText;
	// Use this for initialization
	void Start () {
		deleting = false;
		deletingText.gameObject.SetActive(false);		
	}
	
	// Update is called once per frame
	public void changeDeleting(){
		if(deleting){
			deleting = false;
			deletingText.gameObject.SetActive(false);
		}
		else{
			deleting = true;
			deletingText.gameObject.SetActive(true);
		}
	}

}
