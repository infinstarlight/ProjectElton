using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using UnityEngine;

public class ScanPostProcess : MonoBehaviour
{
    private Sequence satSequence;
    // Start is called before the first frame update
    void Start()
    {
        satSequence = DOTween.Sequence();
        ActivateEffect();
    }

   public void ActivateEffect()
   {
        var Saturation = ScriptableObject.CreateInstance<ColorGrading>();
        Saturation.enabled.Override(true);
        Saturation.saturation.Override(1.0f);
        var volume = PostProcessManager.instance.QuickVolume(LayerMask.NameToLayer("Postprocessing"), 100f, Saturation);
        volume.weight = 0f;

        satSequence
          .Append(DOTween.To(() => volume.weight, x => volume.weight = x, 1f, 1f))
            .AppendInterval(5f)
            .Append(DOTween.To(() => volume.weight, x => volume.weight = x, 0f, 1f))
              .OnComplete(() =>
            {
                RuntimeUtilities.DestroyVolume(volume, true, true);
                Destroy(this);
            });
   }
}
