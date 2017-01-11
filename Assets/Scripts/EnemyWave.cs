using UnityEngine;

public class EnemyWave : MonoBehaviour {

   // Variable poitning to object prefab
   public Transform alienPrefab;

	// Speed of the wave movement
	public static float speed = 1;
    public float autoSpawnProbability;

	// Update is called once per frame
   void FixedUpdate () {
      float randomSample = Random.Range(0f, 1f);
      if (randomSample < autoSpawnProbability) {
          Transform alien = Instantiate(alienPrefab);
          alien.parent = transform;
          randomSample = Random.Range(-1f, 1f);
          alien.position = new Vector3(randomSample*5,6,0);
      }
   }
}