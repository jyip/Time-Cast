using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {

	public static DataManager instance = null;

	const string NAME_KEY = "name_";
	const string SECONDS_KEY = "seconds_";
	const int MAX_TIMERS = 100;

	public List<TimerData> timers = new List<TimerData>(MAX_TIMERS);

	void Awake () {
		if (instance == null) {
			instance = this;
			timers = instance.getTimers();
			DontDestroyOnLoad(gameObject);
		} 
		else if (instance != this) {
			Destroy(gameObject);    
		}
	}

    public void saveTimer(string name, int seconds) {
		if(seconds <= 0 || name == "") {
			Debug.LogError("Invalid timer settings!");
			return;
		}

        int id = getTimerId();
        if(id < 0) {
            Debug.LogError("Can not set timer. Maximum set timers reached!");
            return;
        }

        setName(id, name);
        setSeconds(id, seconds);

		TimerData timer = getTimer(id);
		timers.Add(timer);
    }

    public int getTimerId() {
		for(int i = 0; i < MAX_TIMERS; i++) {
			if(timers[i] == null) {
				return i;
			}
		}

		return -1;
    }

	private List<TimerData> getTimers() {
		List<TimerData> timerList = new List<TimerData>();

        for(int i = 0; i < MAX_TIMERS; i++) {
            TimerData timer = getTimer(i);
            timerList.Add(timer);
        }
			
        return timerList;
    }

	public TimerData getTimer(int id) {
        TimerData timer = null;
		string name = getName(id);
		int seconds = getSeconds(id);

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

    private string getName(int id) {
        return PlayerPrefs.GetString(NAME_KEY + id.ToString());
    }

	private int getSeconds(int id) {
        return PlayerPrefs.GetInt(SECONDS_KEY + id.ToString());
    }

	public void printTimers() {
		foreach(TimerData timer in timers)
		{
			if(timer) {
				print (timer.name + ": " + timer.seconds);
			}
		}
	}
}