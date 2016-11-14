﻿using UnityEngine;
using System.Collections;

public class AnswerWithMouse : MonoBehaviour {

	public static bool lockAnswer = false;

	private AudioSource hoverAudio;

	// Use this for initialization
	void Start () {

		if (hoverAudio == null)
			hoverAudio = GetComponent <AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {

		// Capture the clicked answer and store it 
		QuestionController.selectedAnswer = gameObject.name;

		// Lock the selected answer, so the player can't change it
		QuestionController.choiceSelected = "y";
		lockAnswer = true;


	}

	void OnMouseEnter() {
		hoverAudio.Play ();
	}
}
