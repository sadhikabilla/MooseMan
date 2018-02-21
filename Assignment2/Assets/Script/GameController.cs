using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject mooseMan;
	public int maxScore;

	public int score;
	private Animator mooseAnimator;				// Reference to animator component of moose.
	private AudioSource audio;
    private bool musicStart;

	// Use this for initialization
	void Start () {
		score = 0;
		mooseAnimator = mooseMan.GetComponent<Animator>();
        mooseAnimator.speed = 0;
		audio = GetComponent<AudioSource> ();
		audio.volume = 0;
        musicStart = false;
	}

	void Update(){
	}

	public void AddScore(){
		score++;
		mooseAnimator.speed = score / 2;

		float value = (float)score / (float)maxScore;
		audio.volume = value;
        if (!musicStart && score > 0){
            audio.Play();
            musicStart = true;
        }

		if (score == maxScore) {
			EndGame ();
		}
	}

	void EndGame(){
		//mooseman dance
	}
}
