using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chords : MonoBehaviour {
    GameObject fingers;
    Transform fingers_trans;
    Transform index;
    Transform middle;
    Transform ring;
    Transform pinky;
    bool playing;

    // Use this for initialization
    void Start () {
        fingers = GameObject.Find("Fingers"); //gets Fingers gameObject
        fingers_trans = fingers.transform;
        playing = false;
        //initializes fingers to empty gameObjects
        index = fingers_trans.Find("Index");
        middle = fingers_trans.Find("Middle");
        ring = fingers_trans.Find("Ring");
        pinky = fingers_trans.Find("Pinky");
    }
	
	// Update is called once per frame
	void Update () {
        
        Event e = Event.current;
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("PLAYING A");
            index = fingers_trans.Find("3-2");
            middle = fingers_trans.Find("4-2");
            ring = fingers_trans.Find("5-2");
            index.gameObject.SetActive(true);
            middle.gameObject.SetActive(true);
            ring.gameObject.SetActive(true);
            playing = true;
        }

        //sets chord fingerings inactive
        else if (!Input.anyKey && playing) {
            //Debug.Log("LETTING GO");
            index.gameObject.SetActive(false);
            middle.gameObject.SetActive(false);
            ring.gameObject.SetActive(false);
            pinky.gameObject.SetActive(false);
            playing = false;
        }

        //resets fingers to empty gameobjects
        else {
            //Debug.Log("NOT PLAYING ANYTHIN");
            index = fingers_trans.Find("Index");
            middle = fingers_trans.Find("Middle");
            ring = fingers_trans.Find("Ring");
            pinky = fingers_trans.Find("Pinky");
        }
	}
}
