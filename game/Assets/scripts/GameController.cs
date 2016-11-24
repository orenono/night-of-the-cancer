﻿/*
 *  This script will hold variables and fuctions, that will
 *  hold their value throughout the game. This can be useful
 *  when we are changing scenes and we want to pass any data
 *  between the scenes.
*/

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private int correctAns = 0;
	private bool[] isTriggerUsed = new bool[8];
	private bool countdown = false;
	GameObject player;
	Vector2 playerPos;
	GameObject enemy;
	Vector2 enemyPos;
	Health health;
	float currHealth;

	void Awake() {

		// If an instance already exists, destroy this one
		if (instance != null)
			Destroy (this.gameObject);

		// Otherwise, make this the instance
		else
			instance = this;

		// Enable persistence across scenes
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		

	}

	/////////////////////////////////////////////
	//		QuestionTrigger Methods
	/////////////////////////////////////////////

	public void SetTriggerUse (int index, bool toggle) {
		isTriggerUsed[index] = toggle;
	}

	public bool GetTriggerUsed (int index) {
		return isTriggerUsed[index];
	}

	/////////////////////////////////////////////
	//		Score Methods
	/////////////////////////////////////////////

	public void IncreaseScore() {
		correctAns++;
	}

	public int GetNumberOfQuestions () {
		return Questions.qa.GetLength (0);
	}

	public int GetCorrectAnswerCount() {
		return correctAns;
	}

	public double GetScorePercentage() {
		return GetCorrectAnswerCount() / GetNumberOfQuestions ();
	}

	/////////////////////////////////////////////
	//		UI Methods
	/////////////////////////////////////////////

	public bool isCountdownPlaying() {
		return countdown;
	}

	public void SetCountdownActive(bool toggle) {
		countdown = toggle;
	}
		
	/////////////////////////////////////////////
	//		Data Persistent Methods
	/////////////////////////////////////////////

	public void SaveData (string str) {
		switch(str) {
		case "Player":
			if (player == null)
				player = GameObject.Find (str);

			playerPos = player.transform.position;
			break;

		case "Enemy":
			if (enemy == null)
				enemy = GameObject.Find (str);

			enemyPos = enemy.transform.position;
			break;

		case "Healthbar":
			if (health == null)
				health = GameObject.FindObjectOfType (typeof(Health)) as Health;

			currHealth = health.GetCurrentHealth ();
			break;
		}

	}

	public void LoadData (string str) {
		switch(str) {
		case "Player":
			if (player == null)
				player = GameObject.Find (str);

			player.transform.position = playerPos;
			break;

		case "Enemy":
			if (enemy == null)
				enemy = GameObject.Find (str);

			enemyPos = enemyPos - new Vector2 (0, 5f);
			enemy.transform.position = enemyPos;
			break;

		case "Healthbar":
			if (health == null)
				health = GameObject.FindObjectOfType (typeof(Health)) as Health;

			health.SetCurrentHealth(currHealth);
			break;
		}

	}
		

}
