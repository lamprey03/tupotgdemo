using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public float maxHealth= 100f;
	public float curHealth= 0f;
	public GameObject healthbar;
	// Use this for initialization
	void Start () {
		curHealth = maxHealth;
		InvokeRepeating ("decreasehealth",1f,1f);
		//decreasehealth ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void decreasehealth(){
		curHealth -= 2f;
		float calcHealth = curHealth / maxHealth;
	    SetHealthBar (calcHealth);
	}

	public void SetHealthBar(float myHealth){
		healthbar.transform.localScale = new Vector3 (myHealth, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
	}
}
