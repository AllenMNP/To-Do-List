using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInserter : MonoBehaviour {

	string EventURL = "http://localhost/todo_list_app/insert_event.php";

	public void createEvent(string id, string event_name, string time_start, string time_end, string curr_status, string event_priority, string notes){
		WWWForm form = new WWWForm();
		form.AddField("IDPost", id);
		form.AddField("eventPost", event_name);
		form.AddField("time_beginPost", time_start);
		form.AddField("time_endPost", time_end);
		form.AddField("statusPost", curr_status);
		form.AddField("priorityPost", event_priority);
		form.AddField("notesPost", notes);

		WWW www = new WWW(EventURL, form);
		gameObject.GetComponent<DataLoader>().updateData();
	}
}
