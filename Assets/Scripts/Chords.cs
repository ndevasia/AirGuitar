using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Windows.Speech;

public class Chords : MonoBehaviour
{
    GameObject fingers;
    Transform fingers_trans;
    Transform index;
    Transform middle;
    Transform ring;
    Transform pinky;
    bool playing;
    public Text chordText;
    public string lastPlayed;

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
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();
    private bool recognized = false;

    // Use this for initialization
    void Start()
    {
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

        actions.Add("A major", A);
        actions.Add("B major", B);
        actions.Add("C major", C);
        actions.Add("D major", D);
        actions.Add("E major", E);
        actions.Add("F major", F);
        actions.Add("G major", G);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        recognized = true;
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        Event e = Event.current;
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("PLAYING A");
            lastPlayed = "A";
            A();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            //Debug.Log("PLAYING C");
            lastPlayed = "C";
            C();
        }
        else if (Input.GetKey(KeyCode.G))
        {
            //Debug.Log("PLAYING G");
            lastPlayed = "G";
            G();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("PLAYING D");
            lastPlayed = "G";
            D();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            //Debug.Log("PLAYING E");
            lastPlayed = "E";
            E();
        }

        else if (Input.GetKey(KeyCode.F))
        {
            //Debug.Log("PLAYING F");
            lastPlayed = "F";
            F();
        }

        else if (Input.GetKey(KeyCode.B))
        {
            //Debug.Log("PLAYING B");
            lastPlayed = "B";
            B();
        }

        //sets chord fingerings inactive
        else if (!Input.anyKey && playing && !recognized)
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
            playing = false;

        }

        //resets fingers to empty gameobjects
        else if (!recognized)
        {
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

        bool flag = false;
        for (int i = 0; i < chords.Count; i++)
        {
            GameObject curChord = chords[i];
            if (!curChord.GetComponent<AudioSource>().isPlaying)
            {
                curChord.SetActive(false);
            }
            else
            {
                flag = true;
            }
        }
        if (flag)
        {
            recognized = true;
        }
        else
        {
            recognized = false;
        }

    }

    private void A()
    {
        if (Input.GetKeyDown(KeyCode.A) || recognized)
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

    private void B()
    {
        if (Input.GetKeyDown(KeyCode.B) || recognized)
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

    private void C()
    {
        if (Input.GetKeyDown(KeyCode.C) || recognized)
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

    private void D()
    {
        if (Input.GetKeyDown(KeyCode.D) || recognized)
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

    private void E()
    {
        if (Input.GetKeyDown(KeyCode.E) || recognized)
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

    private void F()
    {
        if (Input.GetKeyDown(KeyCode.F) || recognized)
        {
            FMajor.SetActive(true);
            FMajor.GetComponent<AudioSource>().Play();
        }
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

    private void G()
    {
        if (Input.GetKeyDown(KeyCode.G) || recognized)
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

    public string lastChord()
    {
        return lastPlayed;
    }
}