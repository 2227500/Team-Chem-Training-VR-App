using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Content.Interaction;
using UnityEngine;
//namespace UnityEngine.XR.Content.Interaction
//{
    public class SampleButtonPress : MonoBehaviour
    {


        [SerializeField]
        [Tooltip("Stores the button toggle used to enable comfort mode.")]
        XRPushButton m_ComfortModeToggle;

        [SerializeField]
        TextMeshPro switchStatus;

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

            m_ComfortModeToggle.toggleValue = pushButtonReady;

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
            switchStatus.text = m_ComfortModeToggle.value.ToString();
        }

        void DisableComfort()
        {
            pushButtonReady = false;
            switchStatus.text = m_ComfortModeToggle.value.ToString();

        }

    }
//}

