﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chords : MonoBehaviour {
    GameObject fingers;
    Transform fingers_trans;
    Transform index;
    Transform middle;
    Transform ring;
    Transform pinky;
    bool playing;
    public Text chordText;

    public Sprite IndexSprite;
    public Sprite MiddleSprite;
    public Sprite RingSprite;
    public Sprite PinkySprite;
    public GameObject bar1;
    public GameObject bar2;
    List<GameObject> bars = new List<GameObject>();

    public GameObject AMajor;
    public GameObject BMajor;
    public GameObject CMajor;
    public GameObject DMajor;
    public GameObject EMajor;
    public GameObject FMajor;
    public GameObject GMajor;
    List<GameObject> chords = new List<GameObject>();

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
        chordText.text = "Not currently playing";
        bars.AddRange(new List<GameObject>() { bar1, bar2 });
        chords.AddRange(new List<GameObject>() { AMajor, BMajor, CMajor, DMajor, EMajor, FMajor, GMajor });
    }
	
	// Update is called once per frame
	void Update () {
        
        Event e = Event.current;
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("PLAYING A");
            if (Input.GetKeyDown(KeyCode.A))
            {
                AMajor.SetActive(true);
                AMajor.GetComponent<AudioSource>().Play();
            }
            index = fingers_trans.Find("3-2");
            middle = fingers_trans.Find("4-2");
            ring = fingers_trans.Find("5-2");
            index.gameObject.SetActive(true);
            middle.gameObject.SetActive(true);
            ring.gameObject.SetActive(true);
            playing = true;
            chordText.text = "Now playing: A major";
        }
        

        else if (Input.GetKey(KeyCode.C))
        {
            //Debug.Log("PLAYING C");
            if (Input.GetKeyDown(KeyCode.C))
            {
                CMajor.SetActive(true);
                CMajor.GetComponent<AudioSource>().Play();
            }
            index = fingers_trans.Find("5-1");
            middle = fingers_trans.Find("3-2");
            ring = fingers_trans.Find("2-3");
            index.gameObject.SetActive(true);
            middle.gameObject.SetActive(true);
            ring.gameObject.SetActive(true);
            playing = true;
            chordText.text = "Now playing: C major";
        }
        else if (Input.GetKey(KeyCode.G))
        {
            //Debug.Log("PLAYING G");
            if (Input.GetKeyDown(KeyCode.G))
            {
                GMajor.SetActive(true);
                GMajor.GetComponent<AudioSource>().Play();
            }
            index = fingers_trans.Find("2-2");
            middle = fingers_trans.Find("1-3");
            ring = fingers_trans.Find("6-3");
            index.gameObject.SetActive(true);
            middle.gameObject.SetActive(true);
            ring.gameObject.SetActive(true);
            playing = true;
            chordText.text = "Now playing: G major";
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("PLAYING D");
            if (Input.GetKeyDown(KeyCode.D))
            {
                DMajor.SetActive(true);
                DMajor.GetComponent<AudioSource>().Play();
            }
            index = fingers_trans.Find("4-2");
            middle = fingers_trans.Find("6-2");
            ring = fingers_trans.Find("5-3");
            index.gameObject.SetActive(true);
            middle.gameObject.SetActive(true);
            ring.gameObject.SetActive(true);
            playing = true;
            chordText.text = "Now playing: D major";
        }
        else if (Input.GetKey(KeyCode.E))
        {
            //Debug.Log("PLAYING E");
            if (Input.GetKeyDown(KeyCode.E))
            {
                EMajor.SetActive(true);
                EMajor.GetComponent<AudioSource>().Play();
            }
            index = fingers_trans.Find("4-1");
            middle = fingers_trans.Find("3-2");
            ring = fingers_trans.Find("2-2");
            index.gameObject.SetActive(true);
            middle.gameObject.SetActive(true);
            ring.gameObject.SetActive(true);
            playing = true;
            chordText.text = "Now playing: E major";
        }

        else if (Input.GetKey(KeyCode.F))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FMajor.SetActive(true);
                FMajor.GetComponent<AudioSource>().Play();
            }
            //Debug.Log("PLAYING F");
            bar1.SetActive(true);
            middle = fingers_trans.Find("4-2");
            ring = fingers_trans.Find("2-3");
            pinky = fingers_trans.Find("3-3");
            //weird bug here where unity latency causes sprites not to update fast enough on calling update
            //got to do it manually for bar chords i guess
            middle.GetComponent<SpriteRenderer>().sprite = MiddleSprite;
            ring.GetComponent<SpriteRenderer>().sprite = RingSprite;
            pinky.GetComponent<SpriteRenderer>().sprite = PinkySprite;
            middle.gameObject.SetActive(true);
            ring.gameObject.SetActive(true);
            pinky.gameObject.SetActive(true);
            playing = true;
            chordText.text = "Now playing: F major";
        }

        else if (Input.GetKey(KeyCode.B))
        {
            //Debug.Log("PLAYING B");
            if (Input.GetKeyDown(KeyCode.B))
            {
                BMajor.SetActive(true);
                BMajor.GetComponent<AudioSource>().Play();
            }
            bar2.SetActive(true);
            middle = fingers_trans.Find("3-4");
            ring = fingers_trans.Find("4-4");
            pinky = fingers_trans.Find("5-4");
            //weird bug here where unity latency causes sprites not to update fast enough on calling update
            //got to do it manually for bar chords i guess
            middle.GetComponent<SpriteRenderer>().sprite = MiddleSprite;
            ring.GetComponent<SpriteRenderer>().sprite = RingSprite;
            pinky.GetComponent<SpriteRenderer>().sprite = PinkySprite;
            middle.gameObject.SetActive(true);
            ring.gameObject.SetActive(true);
            pinky.gameObject.SetActive(true);
            playing = true;
            chordText.text = "Now playing: B major";
        }

        //sets chord fingerings inactive
        else if (!Input.anyKey && playing) {
            //Debug.Log("LETTING GO");
            index.gameObject.SetActive(false);
            middle.gameObject.SetActive(false);
            ring.gameObject.SetActive(false);
            pinky.gameObject.SetActive(false);
            for (int i = 0; i < bars.Count; i++)
            {
                GameObject bar = bars[i];
                bar.SetActive(false);
            }
            playing = false;
            
        }

        //resets fingers to empty gameobjects
        else {
            //Debug.Log("NOT PLAYING ANYTHIN");
            index = fingers_trans.Find("Index");
            middle = fingers_trans.Find("Middle");
            ring = fingers_trans.Find("Ring");
            pinky = fingers_trans.Find("Pinky");
            chordText.text = "Not currently playing";
        }

        index.GetComponent<SpriteRenderer>().sprite = IndexSprite;
        middle.GetComponent<SpriteRenderer>().sprite = MiddleSprite;
        ring.GetComponent<SpriteRenderer>().sprite = RingSprite;
        pinky.GetComponent<SpriteRenderer>().sprite = PinkySprite;

        for (int i = 0; i < chords.Count; i++)
        {
            GameObject curChord = chords[i];
            if (!curChord.GetComponent<AudioSource>().isPlaying)
            {
                curChord.SetActive(false);
            }
        }

    }
}
