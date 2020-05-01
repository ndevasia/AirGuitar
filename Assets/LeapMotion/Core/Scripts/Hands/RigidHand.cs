/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2018.                                 *
 * Leap Motion proprietary and confidential.                                  *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

namespace Leap.Unity {
  /** A physics model for our rigid hand made out of various Unity Collider. */
  public class RigidHand : SkeletalHand {
    //globals go here
    
    bool playing;
    
    public string lastPlayed;

    public GameObject AMajor;
    public GameObject BMajor;
    public GameObject CMajor;
    public GameObject DMajor;
    public GameObject EMajor;
    public GameObject FMajor;
    public GameObject GMajor;
    public GameObject OpenString;
    List<GameObject> chords = new List<GameObject>();
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();
    public bool recognized = false;
    public string strum = "NOT PLAYING";
    public float diff = 0.06f;
    public float height = 20f;
    //public GameObject Chords;
    public float filtering = 0.5f;
    public Text chordText;
    bool isStrumming = false;


        // Use this for initialization
        void Start()
    {
        chords.AddRange(new List<GameObject>() { AMajor, BMajor, CMajor, DMajor, EMajor, FMajor, GMajor, OpenString });
        chordText.text = "Not currently playing";
        
        //this is not necessary get rid of it at some point
        actions.Add("A major", PlayA);
        actions.Add("B major", PlayB);
        actions.Add("C major", PlayC);
        actions.Add("D major", PlayD);
        actions.Add("E major", PlayE);
        actions.Add("F major", PlayF);
        actions.Add("G major", PlayG);
        

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
        Debug.Log("LAST PLAYED IS "+ lastPlayed);
        Event e = Event.current;
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("PLAYING A");
            lastPlayed = "A";
            PlayA();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("PLAYING C");
            lastPlayed = "C";
            PlayC();
        }
        else if (Input.GetKey(KeyCode.G))
        {
            Debug.Log("PLAYING G");
            lastPlayed = "G";
            PlayG();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("PLAYING D");
            lastPlayed = "D";
            PlayD();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("PLAYING E");
            lastPlayed = "E";
            PlayE();
        }

        else if (Input.GetKey(KeyCode.F))
        {
            //Debug.Log("PLAYING F");
            lastPlayed = "F";
            PlayF();
        }

        else if (Input.GetKey(KeyCode.B))
        {
            //Debug.Log("PLAYING B");
            lastPlayed = "B";
            PlayB();
        }
        else
            {
                lastPlayed = "OPEN";
            }

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

    private void PlayA()
    {
        if (Input.GetKey(KeyCode.A) && isStrumming)
        {
            AMajor.SetActive(true);
            AMajor.GetComponent<AudioSource>().Play();
        }
        
        playing = true;
        chordText.text = "Now playing: A major";
    }

    private void PlayB()
    {
        if (Input.GetKey(KeyCode.B) && isStrumming)
        {
            BMajor.SetActive(true);
            BMajor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: B major";
    }

    private void PlayC()
    {
        if (Input.GetKey(KeyCode.C) && isStrumming)
        {
            CMajor.SetActive(true);
            CMajor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: C major";
    }


    private void PlayD()
    {
        if (Input.GetKey(KeyCode.D) && isStrumming)
        {
            DMajor.SetActive(true);
            DMajor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: D major";
    }

    private void PlayE()
    {
        if (Input.GetKey(KeyCode.E) && isStrumming)
        {
            EMajor.SetActive(true);
            EMajor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: E major";
    }

    private void PlayF()
    {
        if (Input.GetKey(KeyCode.F) && isStrumming)
        {
            FMajor.SetActive(true);
            FMajor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: F major";
    }

    private void PlayG()
    {
        if (Input.GetKey(KeyCode.G) && isStrumming)
        {
            GMajor.SetActive(true);
            GMajor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: G major";
    }

    private void PlayOpen()
    {
        if (!Input.anyKey || recognized)
        {
            OpenString.SetActive(true);
            OpenString.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: open string";
    }

    public string lastChord()
    {
        return lastPlayed;
    }
    
        public override ModelType HandModelType {
      get {
        return ModelType.Physics;
      }
    }

    public override bool SupportsEditorPersistence() {
      return true;
    }

    public override void InitHand() {
      base.InitHand();
    }

    public override void UpdateHand() {
       if (height == 20f)
            {
                height = hand_.GetPalmPose().position.y;
            }

            //float grabThreshold = 0.5f;
       //Debug.Log(hand_.GetPalmPose().position.y);
       float current_pos = hand_.GetPalmPose().position.y;
       
       
       if (current_pos - height > diff)
            {
                height = current_pos;
                isStrumming = true;
                //fAMajor.SetActive(true);
                //AMajor.GetComponent<AudioSource>().Play();
                //Debug.Log("UPSTRUM " + Chords.GetComponent<Chords>.);
            }
       else if (current_pos-height < - diff)
            {
                height = current_pos;
                isStrumming = true;
                //CMajor.SetActive(true);
               // CMajor.GetComponent<AudioSource>().Play();
                //Debug.Log("DOWNSTRUM " + Chords.lastChord());
            }
        else
            {
                isStrumming = false;
            }
            if (isStrumming)
            {
                Debug.Log("STRUMMING " + lastPlayed);
                if (lastPlayed == "A")
                {
                    PlayA();
                }
                else if (lastPlayed == "B")
                {
                    PlayB();
                }
                else if (lastPlayed == "C")
                {
                    PlayC();
                }
                else if (lastPlayed == "D")
                {
                    PlayD();
                }
                else if (lastPlayed == "E")
                {
                    PlayE();
                }
                else if (lastPlayed == "F")
                {
                    PlayF();
                }
                else if (lastPlayed == "G")
                {
                    PlayG();
                }
                else if (lastPlayed == "OPEN")
                {
                    PlayOpen();
                }

            }
       

      for (int f = 0; f < fingers.Length; ++f) {
        if (fingers[f] != null) {
          fingers[f].UpdateFinger();
          // Debug.Log(fingers[f].name + "  " + fingers[f].GetTipPosition());
                }
      }

      if (palm != null) {
        Rigidbody palmBody = palm.GetComponent<Rigidbody>();
        if (palmBody) {
          palmBody.MovePosition(GetPalmCenter());
          palmBody.MoveRotation(GetPalmRotation());
        } else {
          palm.position = GetPalmCenter();
          palm.rotation = GetPalmRotation();
        }
      }

      if (forearm != null) {
        // Set arm dimensions.
        CapsuleCollider capsule = forearm.GetComponent<CapsuleCollider>();
        if (capsule != null) {
          // Initialization
          capsule.direction = 2;
          forearm.localScale = new Vector3(1f / transform.lossyScale.x, 1f / transform.lossyScale.y, 1f / transform.lossyScale.z);

          // Update
          capsule.radius = GetArmWidth() / 2f;
          capsule.height = GetArmLength() + GetArmWidth();
        }

        Rigidbody forearmBody = forearm.GetComponent<Rigidbody>();
        if (forearmBody) {
          forearmBody.MovePosition(GetArmCenter());
          forearmBody.MoveRotation(GetArmRotation());
        } else {
          forearm.position = GetArmCenter();
          forearm.rotation = GetArmRotation();
        }
      }
    }
  }
  
}
