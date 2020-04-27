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
    List<GameObject> bars = new List<GameObject>();
    public Text chordText;
    public RigidHand rigid;

    // Use this for initialization
    void Start () {
        chord_fingers = GameObject.Find("ChordFingers"); //gets Fingers gameObject
        fingers_trans = chord_fingers.transform;
        //initializes fingers to empty gameObjects
        index = fingers_trans.Find("ChordIndex");
        middle = fingers_trans.Find("ChordMiddle");
        ring = fingers_trans.Find("ChordRing");
        pinky = fingers_trans.Find("ChordPinky");
        bars.AddRange(new List<GameObject>() { bar1, bar2 });
        chordText.text = "Not currently playing";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            PressA();
        }

        else if (Input.GetKey(KeyCode.B))
        {
            PressB();
        }

        else if (Input.GetKey(KeyCode.C))
        {
            PressC();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            PressD();
        }

        else if (Input.GetKey(KeyCode.E))
        {
            PressE();
        }

        else if (Input.GetKey(KeyCode.F))
        {
            PressF();
        }

        else if (Input.GetKey(KeyCode.G))
        {
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
        else if (!rigid.recognized)
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
}
