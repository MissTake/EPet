using UnityEngine;
using System.Collections;

public class winpet_behavior : MonoBehaviour {
	public static Animator animator;
	private float timer;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
		animator.SetBool("win", false);
		timer = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	
	}

	public void setAnimation(string parameter)
	{
		StartCoroutine(parameter);
	}



	public IEnumerator win()
	{
		animator.SetBool("win", true);
		yield return new WaitForSeconds(3f);
		//animator.SetBool("win", false);
		Debug.Log("inCoroutine");
		Application.LoadLevel("scene01");
		yield return new WaitForSeconds(0f);
	}

//
//		IEnumerator DoSomethingInAWhile(int a, Action<int> onComplete)
//		{
//			a = a + DoFirstThing();
//			yield return new WaitForSeconds(1);
//			a = a + DoSecondThing();
//			yield return new WaitForSeconds(2);
//			onComplete(a);
//		}
}
	