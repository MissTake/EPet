using UnityEngine;
using System.Collections;

public class pet_behavior : MonoBehaviour {
	private Vector3 clickedPosition;
	public float speed;
	//public int movement = 1;
	public static Animator animator;
	private float clickedTime;
	private float timer = 0;
	private float clickStartTime;
	private Vector2 clickStartPosition;
	private bool petClicked;


	// Use this for initialization
	void Start () {

		animator = GetComponentInChildren<Animator>();
		animator.SetBool("is_noticed", false);
		animator.SetBool("is_tickled", false);
		animator.SetBool("is_purred", false);
		speed = 0.1f;
		clickedTime = 0f;
		clickStartTime = 0;
		clickStartPosition.Set(0, 0);
		petClicked = false;
	
	}


	void Move(Vector3 position) {

		clickedPosition.Set(position.x, position.y, position.z);

		Debug.Log("New Position: " + clickedPosition);		
		transform.position = clickedPosition;

	}



	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//float clickTime = 0f;



		//---------------------------start velocity test

		float speed = 0;

		if(Input.GetMouseButtonDown(0) && ClickManager.IsClicked(Input.mousePosition, this.name))
		{
			clickStartTime = timer;
			clickStartPosition = Input.mousePosition;
			petClicked = true;

		}
		else if(Input.GetMouseButtonDown(0) && !ClickManager.IsClicked(Input.mousePosition, this.name))
		{
			petClicked = false;
		}

		if(Input.GetMouseButton(0) && petClicked)
		{
			//speed = sqrt(x²+y²) / deltatime
			float tmpx = Input.mousePosition.x-clickStartPosition.x;
			float tmpy = Input.mousePosition.y - clickStartPosition.y;
			speed = Mathf.Sqrt((tmpx * tmpx) + (tmpy * tmpy)) / (timer - clickStartTime);
			Debug.Log("speed: " + speed);
			clickStartTime = timer;
			clickStartPosition = Input.mousePosition;
			//if()
			//{
			//
			//}
		}






		//---------------------------end velocity test






		if(Input.GetMouseButtonDown(0))
		{
			clickedTime = timer;
		}

		//check if the Object Pet is clicked
		if(Input.GetMouseButton(0))
		{
			if(ClickManager.IsClicked(Input.mousePosition, this.name))
			{

				//Debug.Log("object is clicked");

				if(timer - clickedTime < 0.6)
				{
					//animator.SetBool("is_tickled", true);
					//Debug.Log("hihi");
					StartCoroutine("tickle");

				}
				else if(timer-clickedTime >=0.6)
				{
					//animator.SetBool("is_tickled", false);
					animator.SetBool("is_purred", true);
					//StartCoroutine("purr");
					//Debug.Log("*schnurr*");
				}
				else
				{
					//animator.SetBool("is_tickled", false);
					Debug.Log("clicked time smaller than zero...");
				}



			    //if((timer-clickedTime)<0.3)
				//{
				//animator.SetBool("is_tickled", true);
				//}

			}
			else
			{
				//animator.SetBool("is_tickled", false);
				//Debug.Log("object not clicked");
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			animator.SetBool("is_purred", false);
			petClicked = false;
		}

		//if(timer-clickedTime>0.3)
		//{
		//	animator.SetBool("is_tickled", false);
		//}
		
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

	public IEnumerator tickle()
	{
		animator.SetBool("is_tickled", true);
		yield return new WaitForSeconds(0.6f);
		animator.SetBool("is_tickled", false);
		yield return new WaitForSeconds(0f);
	}

	public IEnumerator purr()
	{
		animator.SetBool("is_purred", true);
		yield return new WaitForSeconds(1f);
		animator.SetBool("is_purred", false);
		yield return new WaitForSeconds(0f);
	}
}
