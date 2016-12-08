using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour {

	public GameObject dBox;
	public Text dChar;
	public Text dText;
	int [] noOfDialog;
	public static string[,] Dialog; 
	public string[] questChar;
	int i = 0;
	// Use this for initialization
	void Start () 
	{ 	
		questChar = new string[20];
		noOfDialog = new int[20];
		Dialog = new string[20,20];
		Dialog [1,0] = "Hey Sup!";
		Dialog [1,1] = "Can you go and get me my pen from that girl?";
		Dialog [1,2] = "Thanks bruh.";
		Dialog [2,0] = "Hey!";
		Dialog [2,1] = "Huh? Pen? Owww... wait let me get it..";
		Dialog [2,2] = "Wait.. What the hell is that?";
		Dialog [3,0] = "An enemy approaching is you...";
		noOfDialog [1] = 3;
		noOfDialog [2] = 3;
		noOfDialog [3] = 1;
		questChar [1] = "School Boy";
		questChar [2] = "School Girl";
		questChar [3] = "";




	}
	
	// Update is called once per frame
	void Update () 
	{ 
		if (i == 0 && QuestCollider.activeDialog == true) {
			dText.text = Dialog [QuestCollider.questNum, i];
			dChar.text = questChar [QuestCollider.questNum];
			dBox.SetActive (true);
			i++;
		} 
		else 
		{
			if (QuestCollider.activeDialog == true && Input.GetMouseButtonDown (0)) 
			{ 
				
				if (i == noOfDialog [QuestCollider.questNum]) 
				{
					dBox.SetActive (false);
					i = 0;
					QuestCollider.questsFinished [QuestCollider.questNum] = true;
					QuestCollider.activeDialog = false;
					if (QuestCollider.questNum == 3) 
					{
						
					}
				} 
				else 
				{
					Debug.Log (QuestCollider.questNum + "," + i);
					dChar.text = questChar [QuestCollider.questNum];
					dText.text = Dialog [QuestCollider.questNum, i];
					i++;
				}

			} 
		}
		
	}
}
