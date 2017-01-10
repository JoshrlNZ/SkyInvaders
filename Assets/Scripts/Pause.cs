using UnityEngine;

public class Pause : MonoBehaviour {

	private bool isPaused;
	public KeyCode pauseKey;
	
	void Start() {
		isPaused = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Pause")) {
			Time.timeScale = isPaused ? 1 : 0;
			isPaused = !isPaused;
		}
	}

	void OnGUI() {
		if (isPaused == true) {
			// Show player score in white on the top left of the screen
			GUI.color = Color.white;   
    		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
    		GUI.skin.label.fontSize = 40;
    		GUI.skin.label.fontStyle = FontStyle.Bold;
    		GUI.Label(new Rect(Screen.width/2-100,Screen.height/2-100,200,200), "Paused");
		}
    	
   	}
}
