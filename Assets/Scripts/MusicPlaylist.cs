using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaylist : MonoBehaviour
{
    public AudioClip[] Tracks;

    private void Start() 
    {
        if(Tracks == null)
        {
            Debug.LogWarning("There are no tracks in the Music Playlist!");
        }    
    }
}
