using UnityEngine;
using System.Collections;

public class enable : MonoBehaviour {
	public GameObject model;
	// Use this for initialization
	void Start () {
		//model.SetActive (false);
		StartCoroutine (delay ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator delay() {
		yield return new WaitForSeconds (0.1f);
		gameObject.SetActive (true);
	}
}
