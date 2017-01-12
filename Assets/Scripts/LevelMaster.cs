using UnityEngine;

public class LevelMaster : MonoBehaviour {

   // Variables referencing two edge colliders
   public EdgeCollider2D leftWall;
   public EdgeCollider2D rightWall;
   public Texture boxTexture;
   public Font barFont;

   // Use this for initialization
   void Start () {
      // Get the width and height of the camera (in pixels)
      float screenW = Camera.main.pixelWidth;
      float screenH = Camera.main.pixelHeight;
      
      // Create an array consisting of two Vector2 object
      Vector2[] edgePoints = new Vector2[2];
      
      // Convert screen coordinates point (0,0) to world coordinates
      Vector3 leftBottom  = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));      
      // Convert screen coordinates point (0,H) to world coordinates
      Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, screenH, 0f));      
      
      // Set the two points in the array to screen left bottom
      // and screen left top points            
      edgePoints[0] = leftBottom;
      edgePoints[1] = leftTop;
      
      // Position the left wall edge collider
      // at the left edge of the camera
      leftWall.points = edgePoints;
      
      // Convert screen coordinates point (W,0) to world coordinates
      Vector3 rightBottom = Camera.main.ScreenToWorldPoint(new Vector3(screenW, 0f, 0f));      
      // Convert screen coordinates point (W,H) to world coordinates
      Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(screenW, screenH, 0f));      
      
      // Set the two points in the array to screen right bottom
      // and screen right top points            
      edgePoints[0] = rightBottom;
      edgePoints[1] = rightTop;
      
      // Position the left wall edge collider
      // at the left edge of the camera
      rightWall.points = edgePoints;
   }

      // HUD
   void OnGUI() {
      // Show black bar at the top of the screen
      GUI.Box(new Rect(0, 0, Screen.width, 35), boxTexture);

      GUIStyle barText = new GUIStyle();
      barText.font = barFont;  
      barText.fontSize = 24;
      barText.normal.textColor = Color.white;

      // Show player score in white on the top left of the screen
      barText.alignment = TextAnchor.UpperLeft;
      GUI.Label(new Rect(15,3,500,100), "Score: " + GameMaster.playerScore, barText);
      
      // Show the player lives in red on the top right of the screen
      barText.alignment = TextAnchor.UpperRight;
      GUI.Label(new Rect(Screen.width - 315,3,300,100), "Lives: " + GameMaster.playerHealth, barText);

      // Show current wave and enemies remaining
      GUI.color = Color.white;
      GUI.skin.label.alignment = TextAnchor.UpperLeft;
      GUI.skin.label.fontSize = 24;
      GUI.Label(new Rect(Screen.width/2-200, 3, 400, 100), "Wave " + GameMaster.waveNumber + " - " + GameMaster.enemiesLeft + " enemies remaining", barText);
   }
}