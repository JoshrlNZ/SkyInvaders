using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour {
   
   // References to text objects on the panel
   public Text resumeText;
   public Text scoreText;
   public Text highScoreText;
   
   // Indicates whether the game in paused mode
   bool pauseGame;

   public void Start() {
	   	Hide();
   }
   
   // Show the pause menu in pause mode (the
   // first option will say "Resume")
   public void ShowPause() {
      // Pause the game
      pauseGame = true;
	  scoreText.text = "Score: " + GameMaster.playerScore;
	  highScoreText.text = "High-Score: " + GameMaster.highScore;
      // Set the text of the first option
      // to "Resume"
      resumeText.text = "Resume";
      // Show the panel
      gameObject.SetActive(true);
   }
   
   // Show the pause menu in game over mode (the
   // first option will say "Restart"
   public void ShowGameOver() {
	  scoreText.text = "Score: " + GameMaster.playerScore;
	  highScoreText.text = "High-Score: " + GameMaster.highScore;
      // Set the text of the first option
      // to "Restart"
      resumeText.text = "Restart";
      // Show the panel
      gameObject.SetActive(true);
   }
   
   
   // Hide the menu panel
   public void Hide() {
      // Deactivate the panel
      gameObject.SetActive(false);
      // Resume the game (if paused)
      pauseGame = false;
      Time.timeScale = 1f;
   }

   public void Resume() {
	   if (resumeText.text == "Resume") {
		   Hide();
	   } else {
		   GameMaster.playerHealth = 3;
	  	   GameMaster.playerScore = 0;
   	       GameMaster.waveNumber = 1;
           GameMaster.enemiesLeft = 20;
           Player.powerTimeLeft = 0;
		   GameMaster.gameover = false;
		   SceneManager.LoadScene("Level1");
	   }
	   
   }
   
   public void Quit() {
	   SceneManager.LoadScene("MainMenu");
   }

   // Update is called once per frame
   void Update () {
      // If game is in pause mode, stop the timeScale value to 0
      if(pauseGame) {
         Time.timeScale = 0;
      }      
   }
}