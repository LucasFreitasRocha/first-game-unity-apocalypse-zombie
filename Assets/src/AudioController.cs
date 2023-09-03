using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioSource instanceAudioSource;
    // Start is called before the first frame update
     void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        instanceAudioSource = audioSource;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
