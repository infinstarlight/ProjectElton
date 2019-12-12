using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class ID_ScanPostProcess : MonoBehaviour
{

     /// <summary>
    /// Retrieve current state of left stick.
    /// </summary>
    public float WeightValue { get; set; }
    public PostProcessVolume myVolume;
    public ColorGrading myColorGrading;
    // Start is called before the first frame update
    void Start()
    {
        myVolume = GetComponent<PostProcessVolume>();
        myColorGrading = myVolume.profile.GetSetting<ColorGrading>();
    }

  
}
