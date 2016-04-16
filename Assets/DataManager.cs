using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {

	const string NAME_KEY = "name_";
	const string SECONDS_KEY = "seconds_";
	const int MAX_TIMERS = 100;

	private int idIterator = 0;

	public List<TimerData> timers = new List<TimerData>();

	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
		timers = getTimers();	}

    public void saveTimer(string name, int seconds) {
		if(seconds <= 0 || name == "") {
			Debug.LogError("Invalid timer settings!");
			return;
		}

        int id = getTimerId();
        if(id > MAX_TIMERS) {
            Debug.LogError("Can not set timer. Maximum timers reached!");
            return;
        }

        setName(id, name);
        setSeconds(id, seconds);
    }

    public int getTimerId() {
        return (idIterator == 0) ? 0 : idIterator + 1;
    }

	private List<TimerData> getTimers() {
		List<TimerData> timerList = new List<TimerData>();

        for(int i = 0; i < MAX_TIMERS; i++) {
            TimerData timer = getTimer();
            if(timer) {
                timerList.Add(timer);
				idIterator++;
            } else break;
        }
			
        return timerList;
    }

	public TimerData getTimer() {
        TimerData timer = null;
        string name = getName();
        int seconds = getSeconds();

		if(name != "" && seconds > 0) {
            timer = ScriptableObject.CreateInstance<TimerData>();
            timer.name = name;
            timer.seconds = seconds;
        }

        return timer;
    }

    public void setName (int id, string name) {
		PlayerPrefs.SetString (NAME_KEY + id.ToString(), name);
    }

    public void setSeconds (int id, int seconds) {
		PlayerPrefs.SetInt (SECONDS_KEY + id.ToString(), seconds);
    }

    private string getName() {
        return PlayerPrefs.GetString(NAME_KEY + idIterator.ToString());
    }

    private int getSeconds() {
        return PlayerPrefs.GetInt(SECONDS_KEY + idIterator.ToString());
    }
}