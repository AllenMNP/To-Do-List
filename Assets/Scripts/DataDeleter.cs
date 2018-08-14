using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDeleter : MonoBehaviour {

	string EventURL = "http://localhost/todo_list_app/insert_event.php";

	public void deleteEvent(string id){
		WWWForm form = new WWWForm();
		form.AddField("IDPost", id);

		WWW www = new WWW(EventURL, form);
	}
}
