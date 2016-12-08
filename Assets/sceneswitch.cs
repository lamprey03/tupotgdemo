using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class sceneswitch : MonoBehaviour {

	public void gotoMap(){
		SceneManager.LoadScene (2);
	}
	public void gotoAR(){
		SceneManager.LoadScene (1);
	}
}
