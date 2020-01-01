using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGM_Player : MonoBehaviour
{
    private static BGM_Player instance = null;
    public static BGM_Player Instance { get { return instance; } }
    public AudioSource source;
    public AudioClip[] Playlist;
    private int NextTrackNum = 0;

    private int PlaylistLength;

    public float FadeTime;

    public bool bShouldMute = false;
    public bool bShouldFadeOut = false;
    public bool bShouldFadeIn = false;
    public MusicPlaylist GetMusicPlaylist;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindMusicPlaylist();

    }



    // Start is called before the first frame update
    void Start()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
        PlayFirstTrack();
        PlaylistLength = Playlist.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (source.time >= source.clip.length)
        {
            if (NextTrackNum < PlaylistLength)
            {
                PlayNextTrack();
            }
            else
            {
                ResetPlaylist();
            }

        }

        if (bShouldMute)
        {
            source.volume = 0;
        }


    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }

    public void CallFadeOut()
    {

        StartCoroutine(FadeOut(source, 1.0f));
    }
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }

    IEnumerator TrackChange()
    {
        yield return new WaitForSeconds(source.clip.length);
        PlayNextTrack();

    }
    void PlayNextTrack()
    {

        if (!source.loop)
        {
            NextTrackNum++;
            if (NextTrackNum >= PlaylistLength)
            {
                ResetPlaylist();
            }

            source.clip = Playlist[NextTrackNum];
        }





        if (bShouldFadeIn)
        {
            StartCoroutine(FadeIn(source, FadeTime));
        }
        if (bShouldFadeOut)
        {
            StartCoroutine(FadeOut(source, FadeTime));
        }
        source.Play();



    }

    void ResetPlaylist()
    {
        NextTrackNum = 0;
        PlayNextTrack();
    }

    void ToggleLoop(bool bShouldLoop)
    {
        if (bShouldLoop)
        {
            source.loop = bShouldLoop;
        }
        else
        {
            source.loop = false;
        }
    }
    void PlayFirstTrack()
    {
        if(!GetMusicPlaylist)
        {
            FindMusicPlaylist();
        }
        if (bShouldFadeIn)
        {
            StartCoroutine(FadeIn(source, FadeTime));
        }
        if (bShouldFadeOut)
        {
            StartCoroutine(FadeOut(source, FadeTime));
        }
        NextTrackNum = 0;
        source.clip = Playlist[NextTrackNum];
        source.Play();
    }

    void FindMusicPlaylist()
    {
        if (source)
        {
            GetMusicPlaylist = FindObjectOfType<MusicPlaylist>();
            if (GetMusicPlaylist)
            {
                Playlist = GetMusicPlaylist.Tracks;
                PlayFirstTrack();
            }

        }
    }

    // void OnGUI()
    // {
    //     int w = Screen.width, h = Screen.height;

    //     GUIStyle style = new GUIStyle();

    //     Rect rect = new Rect(0, 0, w, h * 2 / 100);
    //     style.alignment = TextAnchor.LowerRight;
    //     style.fontSize = h * 2 / 100;
    //     style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
    //     currentClipLength = source.clip.length;
    //     string text = string.Format("{0:0.0} ms", currentClipLength);
    //     GUI.Label(rect, text, style);
    // }
}
