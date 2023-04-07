using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// Use this class to present locomotion control schemes and configuration preferences,
    /// and respond to player input in the UI to set them.
    /// </summary>
    /// <seealso cref="LocomotionManager"/>
    public class SampleDial : MonoBehaviour
    {

        const float k_MaxTurnSpeed = 180f;

        const string k_DegreeFormat = "###";

        const string k_TurnSpeedUnitLabel = "°/s";


        [SerializeField]
        [Tooltip("Stores the toggle lever used to choose the locomotion type between move/strafe and teleport/turn for the left hand.")]
        XRLever m_LeftHandLocomotionTypeToggle;

        
       

        [SerializeField]
        [Tooltip("Stores the knob used to set turn speed.")]
        XRKnob m_TurnSpeedKnob;


        [SerializeField]
        [Tooltip("The label that shows the current turn speed value.")]
        TextMeshPro m_TurnSpeedLabel;

        [SerializeField]
        [Tooltip("Stores the behavior that will be used to configure locomotion control schemes and configuration preferences.")]
        LocomotionManager m_Manager;

        [SerializeField]
        [Tooltip("Stores the GameObject reference used to turn on and off the movement direction toggle in the 3D UI for the left hand.")]
        GameObject m_LeftHandMovementDirectionSelection;

        [SerializeField]
        [Tooltip("Stores the GameObject reference used to turn on and off the turn style toggle in the 3D UI for the left hand.")]
        GameObject m_LeftHandTurnStyleSelection;


        void ConnectControlEvents()
        {
            m_LeftHandLocomotionTypeToggle.onLeverActivate.AddListener(EnableLeftHandMoveAndStrafe);
            m_LeftHandLocomotionTypeToggle.onLeverDeactivate.AddListener(EnableLeftHandTeleportAndTurn);


            m_TurnSpeedKnob.onValueChange.AddListener(SetTurnSpeed);

        }

        void DisconnectControlEvents()
        {
            m_LeftHandLocomotionTypeToggle.onLeverActivate.RemoveListener(EnableLeftHandMoveAndStrafe);
            m_LeftHandLocomotionTypeToggle.onLeverDeactivate.RemoveListener(EnableLeftHandTeleportAndTurn);


            m_TurnSpeedKnob.onValueChange.RemoveListener(SetTurnSpeed);
        }

        void InitializeControls()
        {
            var isLeftHandMoveAndStrafe = m_Manager.leftHandLocomotionType == LocomotionManager.LocomotionType.MoveAndStrafe;

            m_LeftHandLocomotionTypeToggle.value = isLeftHandMoveAndStrafe;



            m_TurnSpeedKnob.value = m_Manager.smoothTurnProvider.turnSpeed / k_MaxTurnSpeed;



            m_TurnSpeedLabel.text = $"{m_Manager.smoothTurnProvider.turnSpeed.ToString(k_DegreeFormat)}{k_TurnSpeedUnitLabel}";
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

        void EnableLeftHandMoveAndStrafe()
        {
            m_Manager.leftHandLocomotionType = LocomotionManager.LocomotionType.MoveAndStrafe;
            m_LeftHandMovementDirectionSelection.SetActive(true);
            m_LeftHandTurnStyleSelection.SetActive(false);
        }

        void EnableLeftHandTeleportAndTurn()
        {
            m_Manager.leftHandLocomotionType = LocomotionManager.LocomotionType.TeleportAndTurn;
            m_LeftHandMovementDirectionSelection.SetActive(false);
            m_LeftHandTurnStyleSelection.SetActive(true);
        }

        //void SetLeftMovementDirectionHeadRelative()
        //{
        //    m_Manager.dynamicMoveProvider.leftHandMovementDirection = DynamicMoveProvider.MovementDirection.HeadRelative;
        //}

        //void SetLeftMovementDirectionHandRelative()
        //{
        //    m_Manager.dynamicMoveProvider.leftHandMovementDirection = DynamicMoveProvider.MovementDirection.HandRelative;
        //}

        //void SetRightMovementDirectionHeadRelative()
        //{
        //    m_Manager.dynamicMoveProvider.rightHandMovementDirection = DynamicMoveProvider.MovementDirection.HeadRelative;
        //}


        void SetTurnSpeed(float knobValue)
        {
            m_Manager.smoothTurnProvider.turnSpeed = Mathf.Lerp(m_TurnSpeedKnob.minAngle, m_TurnSpeedKnob.maxAngle, knobValue);
            m_TurnSpeedLabel.text = $"{m_Manager.smoothTurnProvider.turnSpeed.ToString(k_DegreeFormat)}{k_TurnSpeedUnitLabel}";
        }
    }
}

