using UnityEngine;

public class EnemyWave : MonoBehaviour {

   // Variable poitning to object prefab
   public Transform alienPrefab;
   public Transform alienPrefab2;

	// Speed of the wave movement
	public static float speed = 1;
    public float autoSpawnProbability;
    public float autoSpawnProbability2;

	// Update is called once per frame
   void FixedUpdate () {
      float randomSample = Random.Range(0f, 1f);
      if (randomSample < (autoSpawnProbability + (GameMaster.waveNumber * 0.005))) {
          Transform alien = Instantiate(alienPrefab);
          alien.parent = transform;
          randomSample = Random.Range(-1f, 1f);
          Vector3 tmpPos = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.width,0));
          alien.position = new Vector3(randomSample*tmpPos.x/2,5.5f,-2);
      }

      randomSample = Random.Range(0f, 1f);
      if (randomSample < autoSpawnProbability2) {
          Transform alien = Instantiate(alienPrefab2);
          alien.parent = transform;
          float screenW = Camera.main.pixelWidth;
          float screenH = Camera.main.pixelHeight;
          Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenW+100, screenH-120, 0));
          alien.position = new Vector3(newPosition.x, newPosition.y, -3);
      }
   }
}