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
    public GameObject AMinor;
    public GameObject BMinor;
    public GameObject CMinor;
    public GameObject DMinor;
    public GameObject EMinor;
    public GameObject FMinor;
    public GameObject GMinor;
    public GameObject OpenString;
    List<GameObject> chords = new List<GameObject>();
    
    public string strum = "NOT PLAYING";
    public float pinch = 0f;
    public float delta = 0f;
    public float diff = 50.0f;
    public float lastHeight = 0f;
    public string direction = "NONE";
    public float initHeight = 20f;
    public float filtering = 0.5f;
    public float pinchThreshold = 25f;
    public Text chordText;
    bool isStrumming = false;
    private bool isMinor = false;
    public int numPinches = 0;
    public int total = 0;



        // Use this for initialization
        void Start()
    {
        chords.AddRange(new List<GameObject>() { AMajor, BMajor, CMajor, DMajor, EMajor, FMajor, GMajor, AMinor, BMinor, CMinor, DMinor, EMinor, FMinor, GMinor, OpenString });
        chordText.text = "Not currently playing";

        
    }

    

    // Update is called once per frame
    void Update()
    {
        Event e = Event.current;
        if (Input.GetKeyDown(KeyCode.V))
        {
            isMinor = !isMinor;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (isMinor)
            {
                //Debug.Log("PLAYING A MINOR");
                lastPlayed = "A minor";
                PlayAMinor();
            }
            else
            {
                //Debug.Log("PLAYING A");
                lastPlayed = "A";
                PlayA();
            }
            
        }
        else if (Input.GetKey(KeyCode.C))
        {
            if (isMinor)
            {
                //Debug.Log("PLAYING C MINOR");
                lastPlayed = "C minor";
                PlayCMinor();
            }
            else
            {
                //Debug.Log("PLAYING C");
                lastPlayed = "C";
                PlayC();
            }
        }
        else if (Input.GetKey(KeyCode.G))
        {
            if (isMinor)
            {
                //Debug.Log("PLAYING G MINOR");
                lastPlayed = "G minor";
                PlayGMinor();
            }
            else
            {
                //Debug.Log("PLAYING G");
                lastPlayed = "G";
                PlayG();
            }
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (isMinor)
            {
                //Debug.Log("PLAYING D MINOR");
                lastPlayed = "D minor";
                PlayDMinor();
            }
            else
            {
                //Debug.Log("PLAYING D");
                lastPlayed = "D";
                PlayD();
            }
            
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (isMinor)
            {
                //Debug.Log("PLAYING E MINOR");
                lastPlayed = "E minor";
                PlayEMinor();
            }
            else
            {
                //Debug.Log("PLAYING E");
                lastPlayed = "E";
                PlayE();
            }
            
        }

        else if (Input.GetKey(KeyCode.F))
        {
            if (isMinor)
            {
                //Debug.Log("PLAYING F MINOR");
                lastPlayed = "F minor";
                PlayFMinor();
            }
            else
            {
                //Debug.Log("PLAYING F");
                lastPlayed = "F";
                PlayF();
            }
            
        }

        else if (Input.GetKey(KeyCode.B))
        {
            if (isMinor)
            {
                //Debug.Log("PLAYING B MINOR");
                lastPlayed = "B minor";
                PlayBMinor();
            }
            else
            {
                //Debug.Log("PLAYING B");
                lastPlayed = "B";
                PlayB();
            }
            
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

    private void PlayAMinor()
    {
        if (Input.GetKey(KeyCode.A) && isStrumming)
        {
            AMinor.SetActive(true);
            AMinor.GetComponent<AudioSource>().Play();
        }

        playing = true;
        chordText.text = "Now playing: A minor";
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

    private void PlayBMinor()
    {
        if (Input.GetKey(KeyCode.B) && isStrumming && isMinor)
        {
            BMinor.SetActive(true);
            BMinor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: B minor";
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

    private void PlayCMinor()
    {
        if (Input.GetKey(KeyCode.C) && isStrumming && isMinor)
        {
            CMinor.SetActive(true);
            CMinor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: C minor";
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

    private void PlayDMinor()
    {
        if (Input.GetKey(KeyCode.D) && isStrumming && isMinor)
        {
            DMinor.SetActive(true);
            DMinor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: D minor";
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

    private void PlayEMinor()
    {
        if (Input.GetKey(KeyCode.E) && isStrumming && isMinor)
        {
            EMinor.SetActive(true);
            EMinor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: E minor";
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

    private void PlayFMinor()
    {
        if (Input.GetKey(KeyCode.F) && isStrumming && isMinor)
        {
            FMinor.SetActive(true);
            FMinor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: F minor";
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

    private void PlayGMinor()
    {
        if (Input.GetKey(KeyCode.G) && isStrumming && isMinor)
        {
            GMinor.SetActive(true);
            GMinor.GetComponent<AudioSource>().Play();
        }
        playing = true;
        chordText.text = "Now playing: G minor";
    }

        private void PlayOpen()
    {
        if (!Input.anyKey)
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
       if (initHeight == 20f)
            {
                initHeight = hand_.GetPalmPose().position.y;
            }

       float current_pos = hand_.GetPalmPose().position.y;
       pinch = hand_.PinchDistance;
       if (pinch<pinchThreshold)
            {
                numPinches++;
            }
       total++;
       lastHeight = current_pos;

       delta = current_pos - initHeight;
       
       if (delta > diff)
            {
                Debug.Log("UP");
                direction = "UP";
                initHeight = current_pos;
                if (total*0.7 < numPinches)
                {
                    isStrumming = true;
                    Debug.Log("PLAYING UP");
                }
                numPinches = 0;
                total = 0;

            }
       else if (delta < -diff)
            {
                Debug.Log("DOWN");
                direction = "DOWN";
                initHeight = current_pos;
                if (total*0.7 < numPinches)
                {
                    isStrumming = true;
                    Debug.Log("PLAYING DOWN");
                }
                numPinches = 0;
                total = 0;
            }
       else
            {
                isStrumming = false;
            }

            if (isStrumming)
            {
                //Debug.Log("STRUMMING " + lastPlayed);
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
