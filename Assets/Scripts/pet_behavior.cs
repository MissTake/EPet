using UnityEngine;
using System.Collections;

public class pet_behavior : MonoBehaviour {
	private Vector3 clickedPosition;
	//public float speed;
	//public int movement = 1;
	public static Animator animator;
	private float clickedTime;
	private float timer = 0;
	private float clickStartTime;
	private Vector2 clickStartPosition;
	private bool petClicked;
	private float[] speeds = new float[30];
	private float averageSpeed;
	float lastSwitched;


	// Use this for initialization
	void Start () {

		animator = GetComponentInChildren<Animator>();
		animator.SetBool("is_noticed", false);
		animator.SetBool("is_tickled", false);
		animator.SetBool("is_purred", false);
		clickedTime = 0f;
		clickStartTime = 0;
		clickStartPosition.Set(0, 0);
		petClicked = false;
		speeds.Initialize();
		averageSpeed = 0;
		lastSwitched = 0f;
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


		//----------------------speed referenced state of the pet

		if(Input.GetMouseButtonDown(0) && ClickManager.IsClicked(Input.mousePosition, this.name))
		{
			clickStartTime = timer;
			clickStartPosition = Input.mousePosition;
			petClicked = true;
			speeds.Initialize();
		}

		else if(Input.GetMouseButtonDown(0) && !ClickManager.IsClicked(Input.mousePosition, this.name))
		{
			petClicked = false;
		}




		if(Input.GetMouseButton(0) && petClicked)
		{
			//calculate length for x and y movement
			float tmpx = Input.mousePosition.x-clickStartPosition.x;
			float tmpy = Input.mousePosition.y-clickStartPosition.y;
			float tmpt = timer - clickStartTime;


			averageSpeed = GetSpeed(tmpx, tmpy, tmpt);
			//keep state at least vor a second
			float keepstate = 0.4f;

			if(averageSpeed<=180 && timer - lastSwitched > keepstate)
			{
				animator.SetBool("is_purred", true);
				animator.SetBool("is_tickled", false);
				lastSwitched = timer;
			}
			else if(averageSpeed>180 && timer - lastSwitched > keepstate)
			{
				animator.SetBool("is_tickled", true);
				animator.SetBool("is_purred", false);
				lastSwitched = timer;
			}


			//set current values for time and position
			clickStartTime = timer;
			clickStartPosition = Input.mousePosition;
		}

		if(Input.GetMouseButtonUp(0))
		{
			animator.SetBool("is_tickled", false);
			animator.SetBool("is_purred", false);
		}


		//----------------------------end speed function




		//-----------------------------needed for all solutions, with time and with speed
		/*
		if(Input.GetMouseButtonDown(0))
		{
			clickedTime = timer;
		}
		*/

		//---- solution with right mouse button-------------
		/*
		if(Input.GetMouseButton(1) && ClickManager.IsClicked(Input.mousePosition, this.name))
		{
			animator.SetBool("is_purred", true);
		}
		else
		{
			animator.SetBool("is_purred", false);
		}


		if(Input.GetMouseButton(0) && ClickManager.IsClicked(Input.mousePosition, this.name))
		{

			StartCoroutine("tickle");
			//animator.SetBool("is_tickled", true);
		}
		else
		{
			//animator.SetBool("is_tickled", false);
		}
		*/
		//------------end solution with right mouse button


		//--------------------solution with time start
		/*

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

		*/

		//-------------------------------solution with time end




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


	private float GetSpeed(float xVector, float yVector, float difTime)
	{
		float avgSpeed = 0;
		float speed = 0;
		float tmpsum = 0;

		//clear all values for speeds
		//speeds.Initialize();

		//aktuellen wert fuer geschwindigkeit ausrechnen
		speed = Mathf.Sqrt((xVector * xVector) + (yVector * yVector)) / (difTime);
		//Debug.Log(speed);


		//alle array elemente eine stelle nach vorn rücken
		for(int i = 0; i < (speeds.Length - 1); i++)
		{
			speeds[i] = speeds[i+1];
			//Debug.Log("speed" + speeds[i]);
		}

		//neuen Wert hinten anstellen
		speeds[9] = speed;


		
		//Mittelwert aus allen Werten berechnen

		for(int i = 0; i < speeds.Length; i++)
		{
			tmpsum += speeds[i];
		}
		
		avgSpeed = tmpsum / speeds.Length;
		
		Debug.Log("average Speed " + averageSpeed);

		return avgSpeed;
	}
}
