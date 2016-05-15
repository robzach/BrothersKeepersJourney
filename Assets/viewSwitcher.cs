
using System;
using UnityEngine;
using System.Collections;

public class viewSwitcher : MonoBehaviour
	{

	public GameObject cam;
	private int locationCode = 0;

	private Vector3 pledgePrayerProverb = 	new Vector3 (20f,0f,0f);
	private Vector3	groupDiscussion = 		new Vector3 (0f,0f,0f);
	private Vector3 basketballMovie = 		new Vector3 (60f,0f,0f);
	private Vector3 basketballStill = 		new Vector3 (80f,0f,0f);
	private Vector3 creed = 				new Vector3 (40f,0f,0f);



	AudioSource groupDiscussionAudio;
	AudioSource creedAudio;

	Vector3 mainCam;

	void Start(){
		
		Debug.Log ("viewSwitcher script started");

		AudioSource[] audios = GetComponents<AudioSource> ();
		groupDiscussionAudio = audios [0];
		creedAudio = audios [1];

	}

	void Update(){

		if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)){ // triggered by ViewMaster screen-tap button
			locationCode ++;
			locationCode = locationCode % 5; // will loop around once a user has gone through the whole experience
			Debug.Log ("location = " + locationCode);
			camMover ();
		}

	}

	void camMover(){


		switch (locationCode) {

		case 0:
			GameObject.FindGameObjectWithTag ("cardboard").transform.position = pledgePrayerProverb;
			GameObject.FindGameObjectWithTag ("cardboard").transform.Rotate(Vector3.zero, Space.World);
			creedAudio.Stop (); // if user loops through, must be called to stop scene 5's audio
			break;

		case 1:
			GameObject.FindGameObjectWithTag ("cardboard").transform.position = groupDiscussion;
			GameObject.FindGameObjectWithTag ("cardboard").transform.Rotate(Vector3.zero, Space.World);
			// group discussion audio is attached to cardboardMain
			groupDiscussionAudio.Play();
			break;

		case 2:
			GameObject.FindGameObjectWithTag ("cardboard").transform.position = basketballMovie;	
			GameObject.FindGameObjectWithTag ("cardboard").transform.Rotate(Vector3.zero, Space.World);
			groupDiscussionAudio.Stop (); // in case still playing from previous scene

			((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();

			// MovieTexture won't work on a phone, apparently, so this is broken.
//			Renderer r = GetComponent<Renderer> ();
//			MovieTexture movie = (MovieTexture)r.material.mainTexture;
//			if (movie.isPlaying) {
//				movie.Pause();
//			}
//			else {
//				movie.Play();
//			}

			break;

		case 3:
			GameObject.FindGameObjectWithTag("cardboard").transform.position = basketballStill;
			GameObject.FindGameObjectWithTag ("cardboard").transform.Rotate(Vector3.zero, Space.World);
			break;

		case 4:
			GameObject.FindGameObjectWithTag ("cardboard").transform.position = creed;
			GameObject.FindGameObjectWithTag ("cardboard").transform.Rotate(Vector3.back, Space.World);
			creedAudio.Play();
			break;
		}
	}
}