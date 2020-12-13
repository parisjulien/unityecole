using UnityEngine;

namespace Game
{

    ///<summary>
    /// This utility component can be used on animated characters to play animations directly from unity events.
    /// In the case of the movement, it also smoothes the acceleration/deceleration animation.
    ///</summary>
    [AddComponentMenu("_FINAL/Characters/Character Animator Utility")]
    public class CharacterAnimatorUtility : MonoBehaviour
    {

        #region Properties

        [Header("References")]

        [SerializeField]
        private Animator m_Animator = null;

        [Header("Settings")]

        [SerializeField]
        [Tooltip("Defines an acceleration curve, where X represents the duration and Y represents the maximum speed ratio (between 0 and 1). Using this allow you to smooth the animation.")]
        private AnimationCurve m_AccelerationCurve = new AnimationCurve();

        [SerializeField]
        [Tooltip("Defines an deceleration curve, where X represents the duration and Y represents the maximum speed ratio (between 0 and 1). Using this allow you to smooth the animation.")]
        private AnimationCurve m_DecelerationCurve = new AnimationCurve();

        // Cache

        // Defines the curves cursor position.
        private float m_MovementTimer = 0f;
        // Defines if the character is currently moving, or if it has stopped moving. This is used to evaluate the appropriate curve.
        private bool m_IsMoving = false;

        private int m_SpeedParameterID = -1;

        #endregion


        #region Lifecycle

        private void Awake()
        {
            if(!m_Animator) { m_Animator = GetComponent<Animator>(); }

            m_SpeedParameterID = Animator.StringToHash("speed");
        }

        private void Update()
        {
            EvaluateSpeed(Time.deltaTime);
        }

        #endregion


        #region Public API

        /// <summary>
        /// Makes the character accelerate.
        /// </summary>
        public void StartMovement()
        {
            m_IsMoving = true;
            m_MovementTimer = 0f;
        }

        /// <summary>
        /// Makes the character decelerate.
        /// </summary>
        public void StopMovement()
        {
            m_IsMoving = false;
            m_MovementTimer = 0f;
        }

        /// <summary>
        /// Enables the named trigger on the referenced Animator.
        /// </summary>
        /// <param name="_TriggerName">The name of the trigger to enable.</param>
        public void SetTrigger(string _TriggerName)
        {
            m_Animator.SetTrigger(_TriggerName);
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Uses the acceleration or deceleration curve (depending on the player state) to set the "speed" parameter on the animator, and
        /// smooth the animation transitions.
        /// </summary>
        /// <param name="_DeltaTime">The elapsed time since the last frame.</param>
        private void EvaluateSpeed(float _DeltaTime)
        {
            m_MovementTimer += _DeltaTime;
            AnimationCurve curve = m_IsMoving ? m_AccelerationCurve : m_DecelerationCurve;
            m_Animator.SetFloat(m_SpeedParameterID, curve.Evaluate(m_MovementTimer));
        }

        #endregion

    }

}