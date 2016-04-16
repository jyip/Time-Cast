using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private Text display;
	private bool running = true;

	public float startTime = 5;

	void Awake () {
		display = GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(running) {
			startTime -= Time.deltaTime;
		}

		int displayTime = (int)startTime;

		if(startTime > 1) {
			display.text = displayTime.ToString();
		} else {
			display.text = "FINISHED!";
			running = false;
			startTime = 0;
		}
	}
}
