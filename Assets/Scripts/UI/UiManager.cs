using UnityEngine;
using System.Collections;

public class UiManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


	public void Menu(){
		Application.LoadLevel (0);
	}

	public void Play(){
		Application.LoadLevel (1/*CHECKBUILDSETTINGS*/);
	}

	public void HowToPlay(){
		Application.LoadLevel(2/*CHECKBUILDSETTINGS*/);
	}

	public void Credits(){
		Application.LoadLevel (3/*CHECKBUILDSETTINGS*/);
	}

	public void Quit () {
		Application.Quit ();
		Debug.Log ("GAME HAS QUIT");
	}


}
