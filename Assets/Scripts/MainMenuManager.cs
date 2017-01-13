using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
   
   public void StartGame () {
      // Load the "Level" scene
	  GameMaster.playerHealth = 3;
	  GameMaster.playerScore = 0;
   	  GameMaster.waveNumber = 1;
      GameMaster.enemiesLeft = 20;
      Player.powerTimeLeft = 0;
      SceneManager.LoadScene("Level1");
   }
   
   public void QuitGame() {
      // Quit the application
      Application.Quit();
   }
}