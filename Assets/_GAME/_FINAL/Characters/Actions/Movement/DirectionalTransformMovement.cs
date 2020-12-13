using UnityEngine;
using UnityEngine.Events;

namespace Final
{

    ///<summary>
    /// Makes an object move in a direction by changing its transform position.
    ///</summary>
    [AddComponentMenu("_FINAL/Characters/Actions/Movement/Directional Transform Movement")]
    public class DirectionalTransformMovement : DirectionalMovement
    {

        #region Properties

        [Header("Settings")]

        [SerializeField, Min(.05f)]
        [Tooltip("Defines the movement speed of the object(in units/s)")]
        private float m_Speed = 6f;

        [SerializeField]
        [Tooltip("If true, makes the object rotate toward its movement direction")]
        private bool m_LookInMovementDirection = true;

        [Header("Events")]

        [SerializeField]
        [Tooltip("Called when the object starts moving")]
        private UnityEvent m_OnBeginMove = new UnityEvent();

        [SerializeField]
        [Tooltip("Called each time Move() is called with a non-zero direction vector. Emits the movement direction as parameter")]
        private Vector3Event m_OnUpdateMove = new Vector3Event();

        [SerializeField]
        [Tooltip("Called when the object stops moving")]
        private UnityEvent m_OnEndMove = new UnityEvent();

        // Cache

        // Flag for triggering move events at the appropriate time.
        private bool m_WasMoving = false;

        #endregion


        #region Public API

        /// <summary>
        /// Makes the object move in the given direction, by changing its transform position.
        /// You should call this method even if the given direction is 0, in order to trigger the events as expected.
        /// Note that if "Look In Movement Direction" option is set to true, the object will also rotate toward the given direction.
        /// </summary>
        /// <param name="_Direction">The direction you want the object to move.</param>
        /// <param name="_DeltaTime">The elapsed time since the last frame.</param>
        /// <returns>Returns true if the object has moved successfully, otherwise false.</returns>
        public override bool Move(Vector3 _Direction, float _DeltaTime)
        {
            // If the direction is zero, trigger OnEndMove event if needed, and return false
            if (_Direction == Vector3.zero)
            {
                if (m_WasMoving)
                {
                    m_WasMoving = false;
                    m_OnEndMove.Invoke();
                }
                return false;
            }
            // Else, if the direction is valid, trigger OnBeginMove if needed
            else
            {
                if(!m_WasMoving)
                {
                    m_WasMoving = true;
                    m_OnBeginMove.Invoke();
                }
            }

            // Apply movement
            _Direction.Normalize();
            transform.position += _Direction * m_Speed * _DeltaTime;

            // Apply rotation if needed
            if (m_LookInMovementDirection)
                transform.forward = _Direction;

            // Trigger OnUpdateMove event, and send the current movement direction
            m_OnUpdateMove.Invoke(_Direction);

            return true;
        }

        /// <summary>
        /// Called when the object starts moving.
        /// </summary>
        public UnityEvent OnBeginMove
        {
            get { return m_OnBeginMove; }
        }

        /// <summary>
        /// Called each time Move() is called with a non-zero direction vector. Emits the movement direction as parameter.
        /// </summary>
        public Vector3Event OnUpdateMove
        {
            get { return m_OnUpdateMove; }
        }

        /// <summary>
        /// Called when the object stops moving.
        /// </summary>
        public UnityEvent OnEndMove
        {
            get { return m_OnEndMove; }
        }

        #endregion

    }

}