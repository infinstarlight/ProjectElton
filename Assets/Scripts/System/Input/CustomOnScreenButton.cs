using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using DG.Tweening;
using UnityEngine.UI;

////TODO: custom icon for OnScreenButton component

namespace UnityEngine.InputSystem.OnScreen
{
    /// <summary>
    /// A button that is visually represented on-screen and triggered by touch or other pointer
    /// input.
    /// </summary>
    [AddComponentMenu("Input/Custom On-Screen Button")]
    public class CustomOnScreenButton : OnScreenControl, IPointerDownHandler, IPointerUpHandler
    {
        private Image buttonImage;
        private Material buttonMaterial;
        public void OnPointerUp(PointerEventData eventData)
        {
            SendValueToControl(0.0f);
            buttonMaterial.DOFade(0.05f, 0.50f);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SendValueToControl(1.0f);
            buttonMaterial.DOFade(1.0f, 0.50f);
        }

        ////TODO: pressure support
        /*
        /// <summary>
        /// If true, the button's value is driven from the pressure value of touch or pen input.
        /// </summary>
        /// <remarks>
        /// This essentially allows having trigger-like buttons as on-screen controls.
        /// </remarks>
        [SerializeField] private bool m_UsePressure;
        */

        private void Start()
        {

            buttonImage = GetComponent<Image>();
            buttonMaterial = buttonImage.material;
        }

        [InputControl(layout = "Button")]
        [SerializeField]
        private string m_ControlPath;

        protected override string controlPathInternal
        {
            get => m_ControlPath;
            set => m_ControlPath = value;
        }
    }
}
