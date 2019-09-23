using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGM_Player : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] Playlist;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        source.clip = Playlist[0];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
