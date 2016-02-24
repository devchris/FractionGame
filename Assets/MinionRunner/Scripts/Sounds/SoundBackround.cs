using UnityEngine;
using System.Collections;

public class SoundBackround : MonoBehaviour {


    public AudioClip backround;
    AudioSource source;

	
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
