using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {
	public Canvas MainCanvas;
	public Canvas OptionsCanvas;


	void Awake(){
		OptionsCanvas.enabled = false;
	}

	public void OptionsOn(){
		OptionsCanvas.enabled = true;
		MainCanvas.enabled = false;
	}

	public void ReturnOn(){
		OptionsCanvas.enabled = false;
		MainCanvas.enabled = true;
	}
	public void LoadOn(){
		//Application.LoadLevel (1); //di na to nagana
		SceneManager.LoadScene(2);
	}
	public void MapOn(){
		SceneManager.LoadScene(2);
	}
}
