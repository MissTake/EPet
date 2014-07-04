using UnityEngine;
using System.Collections;

public class reactiongame_element_behavior : MonoBehaviour {
	private float timer;
	private float lastChanged;
	private float keepState;
	private float nextState;
	private bool state;
	// ToDo: Level management
	int level;
	public int roundcount;

	//Animator laden
	public Animator animator;
	private static int count;

	public winpet_behavior pet;




	// Use this for initialization
	void Start () {
		timer = 0f;
		lastChanged = 0f;
		keepState = Random.Range(2, 10);
		nextState = 0f;
		state = false;
		level = 1;
		count = 0;
		roundcount = 12;

		animator = GetComponentInChildren<Animator>();
		animator.SetBool("is_hit", false);
		animator.SetBool("not_hit", false);
		animator.SetBool("appear", false);

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Sprite spr;
		SpriteRenderer sprRenderer = (SpriteRenderer)renderer;


		//wurde das spiel gewonnen?
		if (count >= roundcount)
		{
			//Debug.Log("You Win!" + timer.ToString());
			//winpet_behavior.
			pet.setAnimation("win");
			animator.SetBool("appear", false);
			animator.SetBool("is_hit", false);
			animator.SetBool("not_hit", false);
			
			//Application.LoadLevel("scene01");
			
		}

		//wenn die Zeit, die das objekt im Status bleiben soll,
		//vergangen ist, dann soll der nächste status ermittelt werden.
		if((lastChanged + keepState) - timer <= 0 && ((state && Input.GetMouseButtonDown(0) && !ClickManager.IsClicked(Input.mousePosition, this.name)) || !Input.GetMouseButton(0) ))
		{
			nextState = Random.value;
			if(nextState >= 0f && nextState < 0.8)
			{
				state = false;
			}
			else if(nextState >= 0.8 && nextState < 1f)
			{
				state = true;
			}
			else
			{
				Debug.LogError("nextState not between 0 and 1");
			}

			if(state)
			{
				//spr = Resources.Load<Sprite>("good");
				//Debug.Log("State Good" + this.name);
				//sprRenderer.sprite = spr;
				this.animator.SetBool("appear", true);
			}
			else if(!state)
			{
				//spr = Resources.Load<Sprite>("");
				//Debug.Log("State Empty" + this.name);
				//sprRenderer.sprite = spr;
				//this.animator.SetBool("appear", false);
				StartCoroutine("notHit");
				animator.SetBool("appear", false);
			}
			else
			{
				Debug.LogError("no defined State in element" + this.name);
			}
			//Debug.Log("State value" + nextState);

			//muss noch statusabhängig gemacht werden --> leeres feld soll länger sein als besetztes feld
			if(state)
			{
				keepState = 2f;
			}
			else if(!state)
			{
			keepState = Random.Range(1, 5);
			}
			//Debug.Log("keep in State for " + keepState);
			//Debug.Log("ObjectName: " + this.name);
			lastChanged = timer;

		}
		else if(state && Input.GetMouseButtonDown(0) && ClickManager.IsClicked(Input.mousePosition, this.name))
		{
			Debug.Log("Object hit " + this.name);
			state = false;
			lastChanged = timer;
			//spr = Resources.Load<Sprite>("");
			//Debug.Log("State Empty" + this.name);
			//sprRenderer.sprite = spr;
			StartCoroutine("hit");
			count += 1;
			Debug.Log("Count = " + count);
			animator.SetBool("appear", false);
			keepState = Random.Range(1, 5);
		}
		else
		{
			//Debug.Log("I am in else");
		}

		
//		if(Input.GetMouseButtonDown(0) && ClickManager.IsClicked(Input.mousePosition, this.name) && this.state)
//		{
//			Debug.Log("Object hit " + this.name);
//			//feedbacktext_behavior.setText("Object hit");
//		}
//		else if(Input.GetMouseButtonDown(0) && (!ClickManager.IsClicked(Input.mousePosition, this.name) || !this.state))
//		{
//			Debug.Log("Did not hit");
//		}
	
	}


	public IEnumerator hit()
	{
		animator.SetBool("is_hit", true);
		yield return new WaitForSeconds(1.1f);
		animator.SetBool("is_hit", false);
		yield return new WaitForSeconds(0f);
	}

	public IEnumerator notHit()
	{
		animator.SetBool("not_hit", true);
		yield return new WaitForSeconds(1.1f);
		animator.SetBool("not_hit", false);
		yield return new WaitForSeconds(0f);
	}
	
	

}
