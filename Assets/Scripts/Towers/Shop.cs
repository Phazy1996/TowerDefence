using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

	[SerializeField] 
	private GameObject[] towersSelection;
	private bool isClicked;
	private SpriteRenderer invisible;

	void Awake(){
		invisible = GetComponent<SpriteRenderer> ();
	}

	void OnMouseDown (){
		//print ("mouse is working");

		if (!isClicked) 
		{
			Instantiate(towersSelection[0],transform.position,transform.rotation);
			invisible.color = new Color (1f,1f,1f,0f);
			isClicked = true;
		}
	}
}
