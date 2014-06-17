using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0) && ClickManager.IsClicked(Input.mousePosition, "quit"))
		{
			Debug.Log("quit game");
			Application.Quit();
		}
	
	}
}
