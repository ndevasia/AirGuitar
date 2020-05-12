using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine;
using UnityEngine.UI;

public class AudioRecord : MonoBehaviour {
    AudioSource audioSource;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();
    public bool recognized = false;
    private bool isPlaying = false;
    public Text recordingText;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        actions.Add("Start", StartRecording);
        actions.Add("Stop", StopRecording);
        actions.Add("Play back", Playback);
        

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        recordingText.text = "Not currently recording";
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        recognized = true;
        Debug.Log(speech.text);
        if (speech.text == "Start" && isPlaying)
        {
            //dont do anything
        }
        else if (speech.text == "Stop" && !isPlaying)
        {
            //dont do anything
        }
        else
        {
            actions[speech.text].Invoke();
        }
        
    }

    private void StartRecording()
    {
        Debug.Log("start recording with list " + Microphone.devices);
        audioSource.clip = Microphone.Start("", true, 3000, 44100);
        isPlaying = true;
        recordingText.text = "Currently recording";
    }
    private void StopRecording()
    {
        Debug.Log("stop recording");
        Microphone.End("");
        isPlaying = false;
        recordingText.text = "Not currently recording";
    }

    private void Playback()
    {
        Debug.Log("playback");
        audioSource.Play();
        recordingText.text = "Playing back";
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("IS RECORDING " + Microphone.IsRecording(""));
	}
}
