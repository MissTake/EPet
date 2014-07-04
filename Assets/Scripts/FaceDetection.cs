using UnityEngine;
using System.Collections;

public class FaceDetection : MonoBehaviour {
	// Use this for initialization
	private bool seesomething;

	void Start () {
		seesomething = false;
		//Sprite spr = Resources.Load<Sprite>("IDontSeeYou");
		//SpriteRenderer sprRenderer = (SpriteRenderer)renderer;
		//sprRenderer.sprite = spr;
	}
	
	// Update is called once per frame
	void Update () {

		//-----do not switch between detected and not detected
		/*
		//toggle between face detected and no face detected
		if(Input.GetMouseButtonDown(0) && ClickManager.IsClicked(Input.mousePosition, "ISeeYou") && seesomething == false)
		{
			pet_behavior.animator.SetBool("is_noticed", true);
			seesomething = true;
			Sprite spr = Resources.Load<Sprite>("ISeeYou");
			SpriteRenderer sprRenderer = (SpriteRenderer)renderer;
			sprRenderer.sprite = spr;

		}
		else if(Input.GetMouseButtonDown(0) && ClickManager.IsClicked(Input.mousePosition, "ISeeYou") && seesomething == true)
		{
			pet_behavior.animator.SetBool("is_noticed", false);
			seesomething = false;
			Sprite spr = Resources.Load<Sprite>("IDontSeeYou");
			SpriteRenderer sprRenderer = (SpriteRenderer)renderer;
			sprRenderer.sprite = spr;
		}
		*/
	
	}
}
