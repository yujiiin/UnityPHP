using UnityEngine;
using System.Collections;



public class menu : MonoBehaviour {
	public string username = "";
	public string password = "";
	public string returnText = "";
	bool RegisterUI = false;
	bool LoginUI = false;
	bool LoginedUI = false;
	bool LoginFailUI = false;

	IEnumerator register(string url, WWWForm wwwForm)
	{
		Debug.Log("posted!");
		WWW www = new WWW(url, wwwForm);
		yield return www;
	}
	IEnumerator login(string url, WWWForm wwwForm)
	{
		Debug.Log("access begin");
		WWW www = new WWW(url, wwwForm);
		yield return www;
		returnText = www.text;
		string[] stArray = returnText.Split("\n"[0]);
		returnText = stArray[1];
		if(www.error != null)
		{
			Debug.Log("Error!");
		}else{
			if(returnText == username){
				Debug.Log(returnText);
				LoginedUI = true;
				LoginFailUI = false;
			}else{

				LoginFailUI = true;
			}
		}
	}

	void OnGUI()
	{
		if(RegisterUI == true && LoginUI == false)
		{
			//Register
			username = GUI.TextArea(new Rect(100,125,100,25),username);
			password = GUI.TextArea(new Rect(100,150,100,25),password);
			if(GUI.Button(new Rect(100,175,100,25),"Register"))
			{
				WWWForm wwwForm = new WWWForm();
				wwwForm.AddField("name",username);
				wwwForm.AddField("password",password);
				string url = "http://yujiiin.com/unityphp/signupsubmit.php";
				StartCoroutine(register(url,wwwForm));

				RegisterUI = false;
			}
		}else if(RegisterUI == false && LoginUI == true)
		{
			//Login
			username = GUI.TextArea(new Rect(100,125,100,25),username);
			password = GUI.TextArea(new Rect(100,150,100,25),password);
			if(GUI.Button(new Rect(100,175,100,25),"Login"))
			{
				WWWForm wwwForm = new WWWForm();
				wwwForm.AddField("name",username);
				wwwForm.AddField("password",password);
				string url = "http://yujiiin.com/unityphp/loginsubmit.php";
				StartCoroutine(login(url,wwwForm));

				LoginUI = false;
			}
		}else if(RegisterUI == false && LoginUI == false)
		{
			if(GUI.Button(new Rect(100,125,100,25),"Login"))
			{
				LoginUI = true;
			}
			if(GUI.Button(new Rect(100,150,100,25),"Register"))
			{
				RegisterUI = true;
			}
			
			if(GUI.Button(new Rect(100,175,100,25),"Logout"))
			{

			}
			if(LoginedUI)
			{
				GUI.TextArea(new Rect(200,125,100,25),"Logined as "+ returnText);
			}
			if(LoginFailUI)
			{
				GUI.TextArea(new Rect(200,125,100,25),"Login fail");
			}

			if(GUI.Button(new Rect(300,125,100,25),"Start Game"))
			{
				Application.LoadLevel(1);
			}
			if(GUI.Button(new Rect(300,150,100,25),"Ranking"))
			{
				
			}
		}






	}
}
