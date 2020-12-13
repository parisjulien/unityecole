using UnityEngine;

namespace Final.Demos
{

    ///<summary>
    /// This component allows you to test the animations on a character.
    /// Place it in he scene, and set the reference of the Animator that has the character's animator controller. Use the speed slider and the
    /// control buttons from the inspector while the game is running in order to see how the animations behave.
    ///</summary>
    [AddComponentMenu("_FINAL/Demos/Character Animations")]
    public class Demos_CharacterAnimations : MonoBehaviour
    {

        #region Properties

        [Header("References")]

        [SerializeField]
        private Animator m_Animator = null;

        [Header("Controls")]

        [SerializeField, Range(0, 1)]
        [Tooltip("Defines the speed of the character. In the original Animator Controller, the speed is a value between 0 and 1, where 0 means Idle, 0.3 means Walk and 1 means Run.")]
        private float m_Speed = 0f;

        // NOTE: The buttons are drawn in the inspector using a custom editor. See script in /Editor directory.

        #endregion


        #region Lifecycle

        private void Awake()
        {
            if (!m_Animator) { m_Animator = GetComponentInChildren<Animator>(); }
            if (!m_Animator)
            {
                Debug.LogWarning("Missing Animator reference: Please set the Animator reference in order to play the animations.");
                return;
            }
        }

        private void Update()
        {
            if (m_Animator)
                m_Animator.SetFloat("speed", m_Speed);
        }

        #endregion


        #region Public API

        public void Idle()
        {
            m_Speed = 0f;
        }

        public void Walk()
        {
            m_Speed = 0.3f;
        }

        public void Run()
        {
            m_Speed = 1f;
        }

        public void Punch()
        {
            EnableAnimTrigger("punch");
        }

        public void Throw()
        {
            EnableAnimTrigger("throw");
        }

        public void Hit()
        {
            EnableAnimTrigger("hit");
        }

        public void Die()
        {
            EnableAnimTrigger("die");
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Enables the named trigger on the referenced Animator.
        /// </summary>
        /// <param name="_TriggerName">The name of the animation trigger you want to enable.</param>
        private void EnableAnimTrigger(string _TriggerName)
        {
            if (m_Animator)
                m_Animator.SetTrigger(_TriggerName);
        }

        #endregion

    }

}