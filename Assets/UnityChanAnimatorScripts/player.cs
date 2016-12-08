using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public Animator anim;
	private float inputH;
	private float inputV;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("1"))
		{
			anim.Play("WAIT01",-1,0f);
		}
		if(Input.GetKey("2"))
		{
			anim.Play("WAIT02",-1,0f);
		}
		if(Input.GetKey("3"))
		{
			anim.Play("WAIT03",-1,0f);
		}
		if(Input.GetKey("4"))
		{
			anim.Play("WAIT04",-1,0f);
		}
		inputH = Input.GetAxis("Horizontal");
		inputV = Input.GetAxis("Vertical");
		
		anim.SetFloat("inputH",inputH);
		anim.SetFloat("inputV",inputV);
	}
}
