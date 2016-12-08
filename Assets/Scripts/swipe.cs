using UnityEngine;
using System.Collections;

public class swipe : MonoBehaviour{
	//Health health = new Health();
	// void SetHealthBar(float myHealth){
//		health.healthbar.transform.localScale = new Vector3 (myHealth, health.healthbar.transform.localScale.y, health.healthbar.transform.localScale.z);
	//}
	public float maxHealth= 100f;
	public float curHealth= 0f;
	public GameObject healthbar;
	void decreasehealth(){
		curHealth -= 5f;
		float calcHealth = curHealth / maxHealth;
		SetHealthBar (calcHealth);
	}

	void SetHealthBar(float myHealth){
		healthbar.transform.localScale = new Vector3 (myHealth, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
	}
	void Start(){
		curHealth = maxHealth;
	}
	void OnSwipe( SwipeGesture gesture ) 
		{
		// Total swipe vector (from start to end position)
		Vector2 move = gesture.Move;

		// Instant gesture velocity in screen units per second
		float velocity = gesture.Velocity;

		// Approximate swipe direction
		FingerGestures.SwipeDirection direction = gesture.Direction;
		if (gesture.Selection) {
			

			//InvokeRepeating ("decreasehealth",1f,1f);
			Debug.Log ("Swiped object: " + gesture.Selection.name);
			decreasehealth ();
			if (curHealth < 1) 
				Destroy (gameObject);

		}
		//	SetHealthBar (health.calcHealth);

		else
			Debug.Log( "No object was swiped at " + gesture.Position );
	}

}
