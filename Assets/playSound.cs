using UnityEngine;
using System.Collections;

public class playSound : MonoBehaviour {

	public Transform cam;
	public Transform lookAt;
	public string audioName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		gameObject.GetComponent<AudioSource> ().loop = false;

		if (Physics.Raycast (cam.position, lookAt.position - cam.position, out hit, 100.0f)) { // if looking at the attached object
//			print ("Found an object - distance: " + hit.distance);
//			Debug.Log(gameObject.GetComponent<AudioSource> ().clip.name);

			bool alreadyPlayed = false;

			if (hit.transform.gameObject.GetComponent<AudioSource> () != null) { // if the object has an AudioSource attached to it
				if (string.Equals (hit.transform.gameObject.GetComponent<AudioSource> ().clip.name, audioName)) { // only play the sound associated with that object
					if (!alreadyPlayed) {
						if (!gameObject.GetComponent<AudioSource> ().isPlaying) { // if it's not already playing
							gameObject.GetComponent<AudioSource> ().Play (); // play it
//						gameObject.GetComponent<AudioSource>.PlayOneShot; // tried to use PlayOneShot, nope, will use clamp instead
//							gameObject.GetComponent<AudioSource> ().tim
						}
					}
				} else {
					gameObject.GetComponent<AudioSource> ().Stop (); // otherwise stop
				}
			}
		} else {
			gameObject.GetComponent<AudioSource> ().Stop (); // if not looking at the thing in question, stop playing
		}
	}
}