using UnityEngine;
using System.Collections;

public class tap : MonoBehaviour
{
	public float maxHealth= 100f;
	public float curHealth= 0f;
	public AudioClip deathClip;     
	public EnemyAttack enemyattack;
	CapsuleCollider capscol;
	AudioSource enemyAudio;  
	Animator anim;
//	public GameObject healthbar;
	public void decreasehealth(){
		float damage = 20;
		curHealth -= damage;
//		float calcHealth = curHealth / maxHealth;
//		SetHealthBar (calcHealth);
	}

//	public void SetHealthBar(float myHealth){
//		healthbar.transform.localScale = new Vector3 (myHealth, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
//	}

	void Awake(){
		enemyattack = GetComponent<EnemyAttack> ();
		capscol = GetComponent<CapsuleCollider> ();
		anim = GetComponent <Animator> ();
		curHealth = maxHealth;
		enemyAudio = GetComponent <AudioSource> ();
	}

	void OnTap( TapGesture gesture )
	{
		

		if (gesture.Selection){
			
				enemyAudio.Play ();
				Debug.Log ("Tapped object: " + gesture.Selection.name);
			anim.Play ("Get_hit",-1,0f);
				decreasehealth ();
			if (curHealth < 1) {
				Destroy (enemyattack);
				Destroy (capscol);
				enemyAudio.clip = deathClip;
				enemyAudio.Play ();
				anim.Play ("Dead", -1, 0f);
				Destroy (gameObject,2f);
			}
		}
		else
			Debug.Log( "No object was tapped at " + gesture.Position );
	}
}