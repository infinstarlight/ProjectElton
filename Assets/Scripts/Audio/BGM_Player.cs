using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGM_Player : MonoBehaviour
{
    private static BGM_Player instance = null;
    public static BGM_Player Instance { get { return instance; } }
    private AudioSource source;
    public AudioClip[] Playlist;
    private int NextTrackNum = 0;

    public float FadeTime;

    private float currentClipLength;

    public bool bShouldFadeOut = false;
    public bool bShouldFadeIn = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();

       
    }

    // Start is called before the first frame update
    void Start()
    {
        source.clip = Playlist[0];
        source.Play();
         if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        TrackChange();
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
        source.Play();
    }
    void PlayNextTrack()
    {
        if (bShouldFadeIn)
        {
            StartCoroutine(FadeIn(source, FadeTime));
        }
        if (bShouldFadeOut)
        {
            StartCoroutine(FadeOut(source, FadeTime));
        }
        NextTrackNum++;
        source.clip = Playlist[NextTrackNum];
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
