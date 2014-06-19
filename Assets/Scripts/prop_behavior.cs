using UnityEngine;
using System.Collections;

public class prop_behavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetMouseButton(0) && ClickManager.IsClicked(Input.mousePosition, this.name))
		{
			Debug.Log("Game Object Clicked");
		}

	
	}


}
