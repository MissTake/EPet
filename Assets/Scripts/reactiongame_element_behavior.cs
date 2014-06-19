using UnityEngine;
using System.Collections;

public class reactiongame_element_behavior : MonoBehaviour {
	private float timer;
	private float lastChanged;
	private float keepState;
	private float nextState;
	public bool state;





	// Use this for initialization
	void Start () {
		timer = 0f;
		lastChanged = 0f;
		keepState = Random.Range(2, 10);
		nextState = 0f;
		state = false;

	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Sprite spr;
		SpriteRenderer sprRenderer = (SpriteRenderer)renderer;

		//wenn die Zeit, die das objekt im Status bleiben soll,
		//vergangen ist, dann soll der nächste status ermittelt werden.
		if((lastChanged + keepState) - timer <= 0)
		{
			nextState = Random.value;
			if(nextState >= 0f && nextState < 0.7)
			{
				state = false;
			}
			else if(nextState >= 0.7 && nextState < 1f)
			{
				state = true;
			}
			else
			{
				Debug.LogError("nextState not between 0 and 1");
			}

			if(state)
			{
				spr = Resources.Load<Sprite>("good");
				Debug.Log("State Good" + this.name);
				sprRenderer.sprite = spr;
			}
			else if(!state)
			{
				spr = Resources.Load<Sprite>("empty");
				Debug.Log("State Empty" + this.name);
				sprRenderer.sprite = spr;
			}
			else
			{
				Debug.LogError("no defined State in element" + this.name);
			}
			//Debug.Log("State value" + nextState);

			//muss noch statusabhängig gemacht werden --> leeres feld soll länger sein als besetztes feld
			keepState = Random.Range(2, 10);
			//Debug.Log("keep in State for " + keepState);
			//Debug.Log("ObjectName: " + this.name);
			lastChanged = timer;

		}
	
	}
}
