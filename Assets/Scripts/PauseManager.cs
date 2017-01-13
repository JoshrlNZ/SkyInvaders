using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
	   // Reference to UI panel that is our pause menu
   public GameObject pauseMenuPanel;
   // Reference to panel's script object 
   PausePanel pauseMenu;

	// Use this for initialization
	void Start () {
		pauseMenu = pauseMenuPanel.GetComponent<PausePanel>();
      	pauseMenu.Hide();   
	}
	
	// Update is called once per frame
	void Update () {
		 if(GameMaster.gameover) {
         // If gameover state detected, show the pause menu in gameover mode   
         pauseMenu.ShowGameOver();
      } else if(Input.GetKey(KeyCode.Escape)) {
         // If user presses ESC, show the pause menu in pause mode
         pauseMenu.ShowPause();
      }
	}
}
