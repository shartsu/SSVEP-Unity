﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoxFlicker : MonoBehaviour {

	private int updateFrameCounter;
	private int[] patternArray;
	private Image box;

	public void Setting(int[] c_patternArray, Image c_box)
	{
		this.patternArray = c_patternArray;
		c_box.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
		this.box = c_box;

	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Box (int flagMan) {

		if (flagMan == 0)
			updateFrameCounter = 0;
	
		if (patternArray [flagMan] == 1) {
			if (patternArray [flagMan - 1] == 0)
				++updateFrameCounter;
	
			box.color = new Color (1.00f, 1.00f, 1.00f, 1.00f);
			//Debug.Log ("patternArray[" + flagMan + "]: " + patternArray [flagMan]);
		} else {
		
			box.color = new Color (1.00f, 1.00f, 1.00f, 0.00f);
			//Debug.Log ("patternArray[" + flagMan + "]: " + patternArray [flagMan]);
		}
	}

	public void Flip (int flagMan) {
		//Debug
		if (flagMan == 0)
			updateFrameCounter = 0;

		box.color = new Color (1.00f, 1.00f, 1.00f, 1.00f);

		Vector3 theScale = box.transform.localScale;

		//10Hz
		if (patternArray [flagMan] == 1) {
			if (patternArray [flagMan - 1] == 0)
				++updateFrameCounter;
			theScale.x *= -1;
		} else {
			theScale.x *= -1;
		}
		box.transform.localScale = theScale;
	}

	//Debug
	public string getCounter () {
		return updateFrameCounter.ToString ();
	}

	public void resetCounter () {
		updateFrameCounter = 0;
	}
	
}
