using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVeloctiyMove : MonoBehaviour {

	public GameObject rHand;
	public GameObject lHand;

	public float goalSpeed = 0.5f;
	public float errorRange = 0.1f;

	public float time = 2.5f;

	private float lastY = 0.0f;
	private float motionDiff = 0.001f;

	private float speed = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Mathf.Abs(rHand.transform.position.y - lastY) > motionDiff)
		{
			speed = Mathf.Abs(rHand.transform.position.y - lastY) / Time.deltaTime;
			lastY = rHand.transform.position.y;
			Debug.Log(speed);

		}
	}
}
