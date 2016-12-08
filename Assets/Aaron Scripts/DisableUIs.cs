using UnityEngine;
using System.Collections;

public class DisableUIs : MonoBehaviour {
	public GameObject quest; 
	// Use this for initialization
	void Start () {
		quest.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
