using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddTimerManager : MonoBehaviour {

	private DataManager DataManager;

	private GameObject saveButton;
	private GameObject cancelButton;
	private GameObject timerNameInput;
	private GameObject timerSecondsInput;

	void Awake () { 
		DataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
		saveButton = GameObject.FindGameObjectWithTag("SaveButton");
		cancelButton = GameObject.FindGameObjectWithTag("CancelButton");
		timerNameInput = GameObject.FindGameObjectWithTag("TimerNameInput");
		timerSecondsInput = GameObject.FindGameObjectWithTag("TimerSecondsInput");
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void cancelPressed() {
		SceneManager.LoadScene("Main");
	}

	public void savePressed() {
		string name = timerNameInput.GetComponent<InputField>().text;
		int seconds = 0;
		bool result = int.TryParse(timerSecondsInput.GetComponent<InputField>().text, out seconds);

		if(result) {
			DataManager.saveTimer(name, seconds);
		} else {
			Debug.LogError("Failed to parse seconds to int");
		}
	}
}
