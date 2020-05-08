using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity;

public class LightUpFingers : MonoBehaviour {
    public GameObject chord_fingers;
    Transform fingers_trans;
    Transform index;
    Transform middle;
    Transform ring;
    Transform pinky;
    public Sprite IndexSprite;
    public Sprite MiddleSprite;
    public Sprite RingSprite;
    public Sprite PinkySprite;
    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    List<GameObject> bars = new List<GameObject>();
    public Text chordText;
    public Text minorText;
    public RigidHand rigid;
    private bool isMinor = false;

    // Use this for initialization
    void Start () {
        chord_fingers = GameObject.Find("ChordFingers"); //gets Fingers gameObject
        fingers_trans = chord_fingers.transform;
        //initializes fingers to empty gameObjects
        index = fingers_trans.Find("ChordIndex");
        middle = fingers_trans.Find("ChordMiddle");
        ring = fingers_trans.Find("ChordRing");
        pinky = fingers_trans.Find("ChordPinky");
        bars.AddRange(new List<GameObject>() { bar1, bar2, bar3 });
        chordText.text = "Not currently playing";
        minorText.text = "Minor: " + isMinor;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isMinor = !isMinor;
            minorText.text = "Minor: " + isMinor;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (isMinor)
                PressAMinor();
            else
                PressA();
        }

        else if (Input.GetKey(KeyCode.B))
        {
            if (isMinor)
                PressBMinor();
            else
                PressB();
        }

        else if (Input.GetKey(KeyCode.C))
        {
            if (isMinor)
                PressCMinor();
            else
                PressC();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (isMinor)
                PressDMinor();
            else
                PressD();
        }

        else if (Input.GetKey(KeyCode.E))
        {
            if (isMinor)
                PressEMinor();
            else
                PressE();
        }

        else if (Input.GetKey(KeyCode.F))
        {
            if (isMinor)
                PressFMinor();
            else
                PressF();
        }

        else if (Input.GetKey(KeyCode.G))
        {
            if (isMinor)
                PressGMinor();
            else
                PressG();
        }

        //sets chord fingerings inactive
        else if (!Input.anyKey)
        {
            index.gameObject.SetActive(false);
            middle.gameObject.SetActive(false);
            ring.gameObject.SetActive(false);
            pinky.gameObject.SetActive(false);
            for (int i = 0; i < bars.Count; i++)
            {
                GameObject bar = bars[i];
                bar.SetActive(false);
            }
            chordText.text = "Not currently playing";
        }

        //resets fingers to empty gameobjects
        else 
        {
            index = fingers_trans.Find("ChordIndex");
            middle = fingers_trans.Find("ChordMiddle");
            ring = fingers_trans.Find("ChordRing");
            pinky = fingers_trans.Find("ChordPinky");
            chordText.text = "Not currently playing";
        }

        index.GetComponent<SpriteRenderer>().sprite = IndexSprite;
        middle.GetComponent<SpriteRenderer>().sprite = MiddleSprite;
        ring.GetComponent<SpriteRenderer>().sprite = RingSprite;
        pinky.GetComponent<SpriteRenderer>().sprite = PinkySprite;

    }

    private void PressA()
    {
        index = fingers_trans.Find("3-2");
        middle = fingers_trans.Find("4-2");
        ring = fingers_trans.Find("5-2");
        index.gameObject.SetActive(true);
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        chordText.text = "Fingering A major";
    }

    private void PressAMinor()
    {
        index = fingers_trans.Find("5-1");
        middle = fingers_trans.Find("3-2");
        ring = fingers_trans.Find("4-2");
        index.gameObject.SetActive(true);
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        chordText.text = "Fingering A minor";
    }

    private void PressB()
    {

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
        chordText.text = "Fingering B major";

    }

    private void PressBMinor()
    {

        bar2.SetActive(true);
        middle = fingers_trans.Find("5-3");
        ring = fingers_trans.Find("3-4");
        pinky = fingers_trans.Find("4-4");
        //weird bug here where unity latency causes sprites not to update fast enough on calling update
        //got to do it manually for bar chords i guess
        middle.GetComponent<SpriteRenderer>().sprite = MiddleSprite;
        ring.GetComponent<SpriteRenderer>().sprite = RingSprite;
        pinky.GetComponent<SpriteRenderer>().sprite = PinkySprite;
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        pinky.gameObject.SetActive(true);
        chordText.text = "Fingering B minor";

    }

    private void PressC()
    {
        index = fingers_trans.Find("5-1");
        middle = fingers_trans.Find("3-2");
        ring = fingers_trans.Find("2-3");
        index.gameObject.SetActive(true);
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        chordText.text = "Fingering C major";

    }

    private void PressCMinor()
    {

        bar3.SetActive(true);
        middle = fingers_trans.Find("5-4");
        ring = fingers_trans.Find("3-5");
        pinky = fingers_trans.Find("4-5");
        //weird bug here where unity latency causes sprites not to update fast enough on calling update
        //got to do it manually for bar chords i guess
        middle.GetComponent<SpriteRenderer>().sprite = MiddleSprite;
        ring.GetComponent<SpriteRenderer>().sprite = RingSprite;
        pinky.GetComponent<SpriteRenderer>().sprite = PinkySprite;
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        pinky.gameObject.SetActive(true);
        chordText.text = "Fingering C minor";

    }

    private void PressD()
    {
        index = fingers_trans.Find("4-2");
        middle = fingers_trans.Find("6-2");
        ring = fingers_trans.Find("5-3");
        index.gameObject.SetActive(true);
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        chordText.text = "Fingering D major";

    }

    private void PressDMinor()
    {
        index = fingers_trans.Find("6-1");
        middle = fingers_trans.Find("4-2");
        ring = fingers_trans.Find("5-3");
        index.gameObject.SetActive(true);
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        chordText.text = "Fingering D minor";

    }

    private void PressE()
    { 
        index = fingers_trans.Find("4-1");
        middle = fingers_trans.Find("3-2");
        ring = fingers_trans.Find("2-2");
        index.gameObject.SetActive(true);
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        chordText.text = "Fingering E major";
    }

    private void PressEMinor()
    {
        middle = fingers_trans.Find("2-2");
        ring = fingers_trans.Find("3-2");
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        chordText.text = "Fingering E minor";
    }

    private void PressF() //to pay respects
    {
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
        chordText.text = "Fingering F major";
    }

    private void PressFMinor() 
    {
        bar1.SetActive(true);
        ring = fingers_trans.Find("2-3");
        pinky = fingers_trans.Find("3-3");
        //weird bug here where unity latency causes sprites not to update fast enough on calling update
        //got to do it manually for bar chords i guess
        ring.GetComponent<SpriteRenderer>().sprite = RingSprite;
        pinky.GetComponent<SpriteRenderer>().sprite = PinkySprite;
        ring.gameObject.SetActive(true);
        pinky.gameObject.SetActive(true);
        chordText.text = "Fingering F minor";
    }

    private void PressG()
    {
        index = fingers_trans.Find("2-2");
        middle = fingers_trans.Find("1-3");
        ring = fingers_trans.Find("6-3");
        index.gameObject.SetActive(true);
        middle.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
        chordText.text = "Fingering G major";
    }

    private void PressGMinor() //to pay respects
    {
        bar3.SetActive(true);
        ring = fingers_trans.Find("2-5");
        pinky = fingers_trans.Find("3-5");
        //weird bug here where unity latency causes sprites not to update fast enough on calling update
        //got to do it manually for bar chords i guess
        ring.GetComponent<SpriteRenderer>().sprite = RingSprite;
        pinky.GetComponent<SpriteRenderer>().sprite = PinkySprite;
        ring.gameObject.SetActive(true);
        pinky.gameObject.SetActive(true);
        chordText.text = "Fingering G minor";
    }
}
