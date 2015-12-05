﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoxController : MonoBehaviour {

	//Declare UDPReceiver
	private UDPReceiver udprcv22222;
	private UDPReceiver udprcv22223;
	public Text text22223;

	//private string portNum;

	public GameObject systemObj1;
	public GameObject systemObj2;
	public GameObject systemObj3;
	public GameObject systemObj4;
	public GameObject systemObj5;
	public GameObject systemObj6;
	public GameObject systemObj7;
	public GameObject systemObj8;
	public GameObject systemObj9;
	public GameObject systemObj10;
	public GameObject systemObj11;

	public Image box1;
	public Image box2;
	public Image box3;
	public Image box4;
	public Text text1;
	public Text text2;

	public Text text10;
	public Text text12;
	public Text text15;
	public Text text20;

	private float updateDuration;
	private int updateFrameCounter;
	private int updateFrameCounter10Hz;
	private int updateFrameCounter12Hz;
	private int updateFrameCounter15Hz;
	private int updateFrameCounter20Hz;
	
	private int flagMan;

	public int[] pattern30 = new int[] {
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1
	};

	public int[] pattern20 = new int[] {
		0, 0, 1, 0, 0, 1, 0, 0, 1, 0,
		0, 1, 0, 0, 1, 0, 0, 1, 0, 0,
		1, 0, 0, 1, 0, 0, 1, 0, 0, 1,
		0, 0, 1, 0, 0, 1, 0, 0, 1, 0,
		0, 1, 0, 0, 1, 0, 0, 1, 0, 0,
		1, 0, 0, 1, 0, 0, 1, 0, 0, 1,
	};

	public int[] pattern15 = new int[] {
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1,
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1,
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1,
	};

	public int[] pattern12 = new int[] {
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1
	};

	public int[] pattern10 = new int[] {
		0, 0, 0, 1, 1, 1, 0, 0, 0, 1,
		1, 1, 0, 0, 0, 1, 1, 1, 0, 0,
		0, 1, 1, 1, 0, 0, 0, 1, 1, 1,
		0, 0, 0, 1, 1, 1, 0, 0, 0, 1,
		1, 1, 0, 0, 0, 1, 1, 1, 0, 0,
		0, 1, 1, 1, 0, 0, 0, 1, 1, 1
	};

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;

		//Set UDPReceiver instance
		udprcv22222 = GetComponent<UDPReceiver> ();
		udprcv22223 = GetComponent<UDPReceiver> ();

		//Port number set
		udprcv22222.PORT_SET (22222);
		udprcv22223.PORT_SET (22223);

		box1 = systemObj1.GetComponent<Image>();
		box2 = systemObj2.GetComponent<Image>();
		box3 = systemObj3.GetComponent<Image>();
		box4 = systemObj4.GetComponent<Image>();

		//Alpha (Firstly Off)
		box1.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
		box2.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
		box3.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
		box4.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
		//Check On-Off

		text1 = systemObj5.GetComponent<Text> ();
		text2 = systemObj6.GetComponent<Text> ();

		text10 = systemObj7.GetComponent<Text> ();
		text12 = systemObj8.GetComponent<Text> ();
		text15 = systemObj9.GetComponent<Text> ();
		text20 = systemObj10.GetComponent<Text> ();

		text22223 = systemObj11.GetComponent<Text> ();
	
		updateDuration = 0.0f;
		updateFrameCounter = 0;
		updateFrameCounter10Hz = 0;
		updateFrameCounter12Hz = 0;
		updateFrameCounter15Hz = 0;
		updateFrameCounter20Hz = 0;

		flagMan = 0;

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("========= For Debug =========");
	
		//Call UDPReceiver 
		//!Action! Not sure whether it should be set here
		Debug.Log ("udprcv(22222):" + udprcv22222.PORT_GET ());
		Debug.Log ("udprcv(22223):" + udprcv22223.PORT_GET ());

		//Show their UDP signals
		text22223.text = udprcv22223.PORT_GET ();

		updateDuration += Time.deltaTime;
		//Debug.Log("updateDuration :" +  updateDuration);
		
		++updateFrameCounter;
		//Debug.Log("updateFrameCounter :" +  updateFrameCounter);

		if (updateFrameCounter % 60 == 0) {
			text1.text = updateDuration.ToString ();
			text2.text = updateFrameCounter.ToString ();
		}

		++flagMan;
		if (flagMan == 60) {
			flagMan = 0;

			//Counter to assure flashing frequencies for each boxes on production
			updateFrameCounter10Hz = 0;
			updateFrameCounter12Hz = 0;
			updateFrameCounter15Hz = 0;
			updateFrameCounter20Hz = 0;

		}

		//10Hz
		if (pattern10 [flagMan] == 1) {
			if(pattern10 [flagMan-1] == 0)
				++updateFrameCounter10Hz;

			text10.text = updateFrameCounter10Hz.ToString ();

			box1.color = new Color(1.00f, 1.00f, 1.00f, 1.00f);
			//Debug.Log ("pattern10[" + flagMan + "]: " + pattern10 [flagMan]);
		} else {

			box1.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
			//Debug.Log ("pattern10[" + flagMan + "]: " + pattern10 [flagMan]);
		}

		//12Hz
		if (pattern12 [flagMan] == 1) {
			if(pattern12 [flagMan-1] == 0)
				++updateFrameCounter12Hz;
			text12.text = updateFrameCounter12Hz.ToString ();

			box2.color = new Color(1.00f, 1.00f, 1.00f, 1.00f);
			//Debug.Log ("pattern12[" + flagMan + "]: " + pattern12 [flagMan]);
		} else {
			box2.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
			//Debug.Log ("pattern12[" + flagMan + "]: " + pattern12 [flagMan]);
		}
		
		//15Hz
		if (pattern15 [flagMan] == 1) {
			if(pattern15 [flagMan-1] == 0)
				++updateFrameCounter15Hz;
			text15.text = updateFrameCounter15Hz.ToString ();

			box3.color = new Color(1.00f, 1.00f, 1.00f, 1.00f);
			//Debug.Log ("pattern15[" + flagMan + "]: " + pattern15 [flagMan]);
		} else {
			box3.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
			//Debug.Log ("pattern15[" + flagMan + "]: " + pattern15 [flagMan]);
		}

		//20Hz
		if (pattern20 [flagMan] == 1) {
			if(pattern20 [flagMan-1] == 0)
				++updateFrameCounter20Hz;
			text20.text = updateFrameCounter20Hz.ToString ();

			box4.color = new Color(1.00f, 1.00f, 1.00f, 1.00f);
			//Debug.Log ("pattern20[" + flagMan + "]: " + pattern20 [flagMan]);
		} else {
			box4.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
			//Debug.Log ("pattern20[" + flagMan + "]: " + pattern20 [flagMan]);
		}
	
	}
}