using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DataLoader : MonoBehaviour {

	public string[] event_data;
	public ScrollRect sv;
	int refreshVal;
	
	// Use this for initialization
	IEnumerator Start () {
		WWW todo_data = new WWW("http://localhost/todo_list_app/event_data.php");
		yield return todo_data;
		string todo_s = todo_data.text;
		event_data = todo_s.Split(';');
		gameObject.GetComponent<EventGallery>().createButtons();
		refreshVal = (int)sv.content.position.y - 300;
	}

	public string getDataVal(string data, string index){
		string value = data.Substring(data.IndexOf(index) + index.Length);
		if(value.Contains("|")){
			value = value.Remove(value.IndexOf("|"));
		}
		return value;
	}

	public IEnumerator updateData(){
		WWW todo_data = new WWW("http://localhost/todo_list_app/event_data.php");
		yield return todo_data;
		string todo_s = todo_data.text;
		event_data = todo_s.Split(';');
		gameObject.GetComponent<EventGallery>().createOneButton(event_data[-1]);
	}

	public string[] getEventData(){
		return event_data;
	}

	public void refreshScene(){
		if((int)sv.content.position.y < refreshVal){
			StartCoroutine(actualRefresh());
		}
	}

	public IEnumerator actualRefresh(){
		yield return new WaitForSeconds(2f);
		Scene s = SceneManager.GetActiveScene();
		SceneManager.LoadScene(s.name);

	}

	public string returnEventByID(string id){
		foreach(string e in event_data){
			string match_id = getDataVal(e,"user_id");
			if(match_id == id){
				return e;
			}
		}
		return "";
	}

}
