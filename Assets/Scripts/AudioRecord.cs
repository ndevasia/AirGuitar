using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine;

public class AudioRecord : MonoBehaviour {
    AudioSource audioSource;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();
    public bool recognized = false;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        actions.Add("Start", StartRecording);
        actions.Add("Stop", StopRecording);
        actions.Add("Play back", Playback);
        

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

    private void StartRecording()
    {
        Debug.Log("start recording with list " + Microphone.devices);
        audioSource.clip = Microphone.Start("", true, 10, 44100);
        Debug.Log("is recording " + Microphone.IsRecording(""));
    }
    private void StopRecording()
    {
        Debug.Log("stop recording");
        Microphone.End("");
        Debug.Log("is recording " + Microphone.IsRecording(""));
    }

    private void Playback()
    {
        Debug.Log("playback");
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("IS RECORDING " + Microphone.IsRecording(""));
	}
}
