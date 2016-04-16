using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AddTimerManager : MonoBehaviour {

	private GameObject saveButton;
	private GameObject cancelButton;

	void Awake () { 
		saveButton = GameObject.FindGameObjectWithTag("SaveButton");
		cancelButton = GameObject.FindGameObjectWithTag("CancelButton");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void cancelPressed() {
		Debug.Log("presssed");
		SceneManager.LoadScene("Main");
	}

	public void savePressed() {
		Debug.Log("save");
	}
}
