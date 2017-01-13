using UnityEngine;

public class Attack : MonoBehaviour {

   // Variable storing projectile object
   // prefab
   public Transform shotPrefab;
   
   // Probability of auto-shoot (0 if
   // no autoshoot)
   public float autoShootProbability;
   
   // Cooldown time for firing
   public float fireCooldownTime;
   
   // How much time is left until able to fire again 
   float fireCooldownTimeLeft = 0;

   // Variable storing a reference to an audio clip
   public AudioClip shotSound = null;
      
   // Per every frame...
   void FixedUpdate () {
      // If still some time left until can fire again
      // reduce the time by the time since last
      // frame 
      if(fireCooldownTimeLeft > 0) {
         fireCooldownTimeLeft -= Time.fixedDeltaTime;
      }
      
      // If auto-shoot probability is more than zero...
      if(autoShootProbability > 0) {
         // Generate number a random number between 0 and 1
         float randomSample = Random.Range(0f, 1f);
         // If that random number is less than the 
         // probability of shooting, then try to shoot
         if(randomSample < (autoShootProbability + (GameMaster.waveNumber * 0.0005))) {
            Shoot(false);   
         }
      }
   }

   // Method for firing a projectile
   public void Shoot(bool playerShot) {
      // Shoot only if the fire cooldown period
      // has expired
      if(fireCooldownTimeLeft <= 0 && Time.timeScale == 1) {
         // Create a projectile object from 
         // the shot prefab
         Transform shot = Instantiate(shotPrefab);
         if (playerShot && Player.powerTimeLeft > 0) {
             Transform shot2 = Instantiate(shotPrefab);
             shot2.position = new Vector3 (transform.position.x-0.3f,transform.position.y+0.8f,-5);
         }
         // Set the position of the projectile object
         // to the position of the firing game object
         if (playerShot) {
             if (Player.powerTimeLeft > 0) {
                 shot.position = new Vector3 (transform.position.x+0.3f,transform.position.y+0.8f,-5);
             } else {
                 shot.position = new Vector3 (transform.position.x,transform.position.y+0.8f,-5);
             }
             
         } else {
             shot.position = transform.position;
         }
         // Set time left until next shot
         // to the cooldown time
         fireCooldownTimeLeft = fireCooldownTime;  


         // Check if shotSound variable has been set...if yes,
         // then play it
         if(shotSound != null) {
            AudioSource.PlayClipAtPoint(shotSound, transform.position);      
         }
	  }
   }
}