using UnityEngine;
using System.Collections;

public class ClickManager : MonoBehaviour {


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}



	public static bool IsClicked (Vector2 position, string objectname) {
		var ray = Camera.main.ScreenPointToRay(position);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit, 200))
		{
			
			if(hit.collider.name == objectname)
			{
				//Debug.Log("object clicked" + hit.collider.name);
				return true;
			}
		}
		
		//Debug.Log("nothing clicked");
		return false;
	}

	public static bool IsStroked (){
		Debug.Log("Method IsStroked has not been implemented, yet!");
		return false;
	
	}


}
