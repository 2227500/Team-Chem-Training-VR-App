using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace UnityEngine.XR.Content.Interaction
{
    
    public class SampleDial : MonoBehaviour
    {

        const float k_MaxTurnSpeed = 180f;

        const string k_DegreeFormat = "###";

        const string k_TurnSpeedUnitLabel = "°/s";



        [SerializeField]
        [Tooltip("Stores the knob used to set turn speed.")]
        XRKnob m_TurnSpeedKnob;


        [SerializeField]
        [Tooltip("The label that shows the current turn speed value.")]
        TextMeshPro m_TurnSpeedLabel;

        public float knobRotateValue;

        void ConnectControlEvents()
        {
            m_TurnSpeedKnob.onValueChange.AddListener(SetTurnSpeed);    

        }

        void DisconnectControlEvents()
        {

            m_TurnSpeedKnob.onValueChange.RemoveListener(SetTurnSpeed);
        }

        void InitializeControls()
        {           
            m_TurnSpeedKnob.value = knobRotateValue / k_MaxTurnSpeed;
            m_TurnSpeedLabel.text = $"{knobRotateValue.ToString(k_DegreeFormat)}{k_TurnSpeedUnitLabel}";
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


        void SetTurnSpeed(float knobValue)
        {
            knobRotateValue = Mathf.Lerp(m_TurnSpeedKnob.minAngle, m_TurnSpeedKnob.maxAngle, knobValue);
            m_TurnSpeedLabel.text = $"{knobRotateValue.ToString(k_DegreeFormat)}{k_TurnSpeedUnitLabel}";
        }

        //public float leverRotateValue;
        //public void LeverTurnAngle()
        //{
        //    float turnValue = 0;
        //    leverRotateValue = Mathf.Lerp(m_LeftHandLocomotionTypeToggle.minAngle, m_LeftHandLocomotionTypeToggle.maxAngle, turnValue);
        //    m_LeverTurnAngleLabel.text = $"{knobRotateValue.ToString(k_DegreeFormat)}{k_TurnSpeedUnitLabel}";
        //}

        //private void Update()
        //{
        //    Debug.Log(m_LeverTurnAngleLabel.text);
        //}
    }
}

