using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	public int score = 0;

	IEnumerator InsertScore(string url, WWWForm wwwForm)
	{
		Debug.Log("posted!");
		WWW www = new WWW(url, wwwForm);
		yield return www;
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(100,100,100,25),"Add"))
		{
			score++;
		}
		GUI.TextArea(new Rect(200,100,100,25),"Score:" + score);
		if(GUI.Button(new Rect(100,125,100,25),"Submit"))
		{
			WWWForm wwwForm = new WWWForm();
			//wwwForm.AddField("name",username);
			wwwForm.AddField("score",score);
			//string url = "http://yujiiin.com/unityphp/loginsubmit.php";
			//StartCoroutine(InsertScore(url,wwwForm));
		}
		if(GUI.Button(new Rect(100,150,100,25),"Exit"))
		{
			Application.LoadLevel(0);
		}
	}
}
