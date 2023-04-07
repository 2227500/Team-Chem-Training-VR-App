using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// Use this class to present locomotion control schemes and configuration preferences,
    /// and respond to player input in the UI to set them.
    /// </summary>
    /// <seealso cref="LocomotionManager"/>
    public class SampleButtonPress : MonoBehaviour
    {


        [SerializeField]
        [Tooltip("Stores the button toggle used to enable comfort mode.")]
        XRPushButton m_ComfortModeToggle;

        public bool pushButtonReady;


        void ConnectControlEvents()
        {

            m_ComfortModeToggle.onPress.AddListener(EnableComfort);
            m_ComfortModeToggle.onRelease.AddListener(DisableComfort);

        }

        void DisconnectControlEvents()
        {
            m_ComfortModeToggle.onPress.RemoveListener(EnableComfort);
            m_ComfortModeToggle.onRelease.RemoveListener(DisableComfort);
        }

        void InitializeControls()
        {

            m_ComfortModeToggle.toggleValue = pushButtonReady;//(m_Manager.enableComfortMode);

        }

        protected void OnEnable()
        {

            ConnectControlEvents();
            InitializeControls();
        }

        protected void OnDisable()
        {
            DisconnectControlEvents();
        }

        void EnableComfort()
        {
            pushButtonReady = true;
        }

        void DisableComfort()
        {
            pushButtonReady = false;
        }

    }
}

