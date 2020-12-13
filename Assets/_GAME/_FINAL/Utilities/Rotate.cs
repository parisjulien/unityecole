using UnityEngine;

namespace Final
{

    ///<summary>
    /// Makes an object rotate around an axis continuously.
    ///</summary>
    [AddComponentMenu("_FINAL/Utilities/Rotate")]
    public class Rotate : MonoBehaviour
    {

        #region Properties

        private const int MAX_ANGLE = 360;

        [SerializeField]
        [Tooltip("Defines the speed of the rotation, in degrees per seconds")]
        private float m_RotationSpeed = 90f;

        [SerializeField]
        private Vector3 m_RotationAxis = Vector3.up;

        [SerializeField]
        private Space m_Space = Space.Self;

        private Vector3 m_InitialForward = Vector3.forward;
        private float m_WorldRotationAngle = 0f;
        private Space m_LastSpace = Space.Self;

        #endregion


        #region Lifecycle

        private void Awake()
        {
            if (m_Space == Space.World)
                m_InitialForward = transform.forward;

            m_LastSpace = m_Space;
        }

        private void Update()
        {
            // Reset initial forward vector and current rotation angle if the rotation space changes
            if (m_Space != m_LastSpace)
            {
                m_InitialForward = transform.forward;
                m_LastSpace = m_Space;
                m_WorldRotationAngle = 0f;
            }

            // Increase current rotation angle if the rotation is in world space
            if (m_Space == Space.World)
            {
                m_WorldRotationAngle += m_RotationSpeed * Time.deltaTime;
                // Keep the current rotation angle value between 0 and 360
                m_WorldRotationAngle += -Mathf.FloorToInt(m_WorldRotationAngle / MAX_ANGLE) * MAX_ANGLE;
            }

            // Apply rotation depending on the selected rotation space
            switch (m_Space)
            {
                case Space.World:
                transform.forward = Quaternion.AngleAxis(m_WorldRotationAngle, m_RotationAxis) * m_InitialForward;
                break;

                default:
                transform.rotation *= Quaternion.AngleAxis(m_RotationSpeed * Time.deltaTime, m_RotationAxis);
                break;
            }
        }

        #endregion

    }

}