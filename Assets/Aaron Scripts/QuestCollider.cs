using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class QuestCollider : MonoBehaviour {
	public static int questNum;
	public static bool activeDialog = false;
	public GameObject quest;
	public GameObject nextQuest;
	public static bool[] questsFinished;
	void OnTriggerEnter(Collider col)
	{ 	
		questsFinished = new bool[20];
			if (this.gameObject.name == "QuestIcon1" && col.gameObject.name == "3D_Pointer") {	
				Debug.Log ("Collide Quest 1");
				questNum = 1;
				quest.SetActive (true);
				activeDialog = true;
			}
			if (this.gameObject.name == "QuestIcon2" && col.gameObject.name == "3D_Pointer") {
				Debug.Log ("Collide Quest 2");
				questNum = 2;
				quest.SetActive (true);
				activeDialog = true;
			}
			if (this.gameObject.name == "Monster1" && col.gameObject.name == "3D_Pointer") {
				Debug.Log ("Collide Monster");
				questNum = 3;
				activeDialog = true;
			SceneManager.LoadScene (1);
			}
	}

	void OnTriggerStay(Collider col)
	{
			if (questNum == 1 && questsFinished [1] == true) {
				quest.SetActive (false);
				nextQuest.SetActive (true);
				this.gameObject.SetActive (false);
			}
			if (questNum == 2 && questsFinished [2] == true) {
				quest.SetActive (false);
				nextQuest.SetActive (true);
				this.gameObject.SetActive (false);
			}
//		if(questNum==3){
//			SceneManager.LoadScene (0);
//		}
	}

	void OnTriggerExit(Collider col)
	{
		if (questNum == 1 && questsFinished [1] == true) 
		{
			quest.SetActive (false);
			nextQuest.SetActive (true);
			this.gameObject.SetActive (false);
		}
		if (questNum == 2 && questsFinished [2] == true) 
		{
			quest.SetActive (false);
			nextQuest.SetActive (true);
			this.gameObject.SetActive (false);

		}
//		if(questNum==3){
//			SceneManager.LoadScene (0);
//		}
	}
}
