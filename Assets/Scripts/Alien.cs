using UnityEngine;

public class Alien : MonoBehaviour {

   //Points the alien is worth
   public static int points = 10;
   public bool isUFO = false;

   void Update() {
       if (isUFO) {
           transform.Translate(-EnemyWave.speed * Time.deltaTime * 2, 0, 0);
       } else {
           transform.Translate(0, -EnemyWave.speed * Time.deltaTime, 0);
       }
       if(!Utility.isVisible(GetComponent<Renderer>(), Camera.main)) {
         Destroy(gameObject);
        }
   }

   // When enemy collides with an object with a
   // collider that is a trigger...
   void OnTriggerEnter2D(Collider2D other) {
         // Collision with something that is not a wall
         // Check if collided with a projectile
         // A projectile has a Projectile script component,
         // so try to get a reference to that component
         Projectile projectile = other.GetComponent<Projectile>();
         
         //If that refernce is not null, then check if it's an enemyProjectile      
         if(projectile != null && !projectile.enemyProjectile) {
            // Collided with non enemy projectile (so a player projectile)
            
            // Destroy the projectile game object
            Destroy(other.gameObject);

            // Report enemy hit to the game master
            GameMaster.EnemyHit(this);  
            points += 5;

            // Destroy self
            Destroy(gameObject);         
        } 
   	}
}