    using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject text;
	public Text inst;
	public bool entry;

	void Show()
	{
		inst = text.GetComponentInChildren<Text> ();
		inst.color = Color.clear;
	}
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
		fade ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			entry = true;
	}	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			entry = false;
	}
	 
	void fade()
	{
			if (entry)
				inst.color = Color.Lerp (inst.color, Color.white, 5f * Time.deltaTime);
		    else
			 	inst.color = Color.Lerp (inst.color, Color.clear, 5f * Time.deltaTime);
	}
}
