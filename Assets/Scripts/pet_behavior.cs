using UnityEngine;
using System.Collections;

public class pet_behavior : MonoBehaviour {
	private Vector3 clickedPosition;
	public float speed;
	//public int movement = 1;
	public static Animator animator;
	private float clickedTime;
	private float timer = 0;


	// Use this for initialization
	void Start () {

		animator = GetComponentInChildren<Animator>();
		animator.SetBool("is_noticed", false);
		animator.SetBool("is_tickled", false);
		speed = 0.1f;
		clickedTime = 0f;
	
	}


	void Move(Vector3 position) {

		clickedPosition.Set(position.x, position.y, position.z);

		Debug.Log("New Position: " + clickedPosition);		
		transform.position = clickedPosition;

	}



	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		//check if the Object Pet is clicked
		if(Input.GetMouseButtonDown(0) && ClickManager.IsClicked(Input.mousePosition, "Pet"))
		{
			clickedTime = timer;
		    if((timer-clickedTime)<0.3)
			{
			animator.SetBool("is_tickled", true);
			}

		}

		if(timer-clickedTime>0.3)
		{
			animator.SetBool("is_tickled", false);
		}
		
		/*

		//----------------------ab hier Touch-----------------------
		bool clicked = false;

		// If a Touch is detected, do the following:
		if(Input.touchCount > 0)
		{






			// go through each detected Touch
			for(int i = 0; i < Input.touchCount; i++)
			{
				// check if the object "Pet" is touched by an touch
				// if so, update variable "clicked"
				clicked = ClickManager.IsClicked(Input.GetTouch(i).position, "Pet");

				// set animation of Pet Object to happy or sad, depending on weather it was touched or not
				//animator.SetBool("IsClicked", clicked);

				if(Input.GetTouch(i).phase == TouchPhase.Moved && clicked)
				{
					Vector2 touchDeltaPosition = Input.GetTouch(i).deltaPosition;
					transform.Translate (touchDeltaPosition.normalized.x *1f * speed, 0f, 0f);
					//Move(new Vector3(6.257f*Input.GetTouch(i).position.normalized.x, 1.5f, 0f));
				}

				// if there was a Touch and it ended, set the animation of Pet Object to sad
				// otherwise it would stay happy if the Touch ends
				if(Input.GetTouch(i).phase == TouchPhase.Ended)
				{
					//animator.SetBool("IsClicked", false);
				}

				if(Input.GetTouch(i).phase == TouchPhase.Ended)
				{
					clicked = false;
				}

			}

			// only if the Pet is touched, check weather the Touch moved
			// if so, move the Pet Object with the Touch.
			/*for(int i = 0; i<Input.touchCount; i++){
				if(Input.GetTouch(i).phase == TouchPhase.Moved && clicked)
				{
					Move(new Vector3(6.257f*Input.GetTouch(i).position.normalized.x, 1.5f, 0f));
				}
			}*/

		//}

		//--------------------bis hier touch---------------------
		







		//var temps = Time.time;
//		if(Input.GetMouseButton(0))
//		   {
//			clickedPosition.Set(((2f/115f)*Input.mousePosition.x-3f), -2.5f, -1f);
//			transform.position = clickedPosition;
//			Debug.Log("Mouse Position: =" + clickedPosition.x);
//			Debug.Log("Zeit =" + Time.deltaTime);
//			animator.SetBool("isNoticed", true);
//			}
		//if(Input.GetMouseButton(0) )
		//{
		//	clickedPosition.Set(((2f/115f)*Input.mousePosition.x-3f), -2.5f, -1f);
		//	transform.position = clickedPosition;
		//	Debug.Log("Mouse Position: =" + clickedPosition.x);
		//	animator.SetBool("isNoticed", true);

		//}
		//if(Input.GetMouseButtonUp(0))
		//{
		//	animator.SetBool("isNoticed", false);
		//}
	
	}
}
