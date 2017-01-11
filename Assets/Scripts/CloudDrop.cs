using UnityEngine;

public class CloudDrop : MonoBehaviour {
	public float speed;

	// Update is called once per frame
	void Update () {
		transform.Translate( new Vector3(0,-Time.deltaTime * speed,0));
	
		Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
		if(!Utility.isVisible(GetComponent<Renderer>(), Camera.main)) {
			transform.position = new Vector3(transform.position.x,-transform.position.y,transform.position.z);
			
      	}
	}
}
