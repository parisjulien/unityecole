using UnityEngine;
using UnityEngine.InputSystem;

namespace Final.Demos
{

    ///<summary>
    /// 
    ///</summary>
    [AddComponentMenu("_FINAL/Demos/Characters/Detection Character Controller")]
    public class Demos_DetectionCharacterController : MonoBehaviour
    {

        #region Properties

        [Header("References")]

        [SerializeField]
        private InputActionAsset m_Controls = null;

        [SerializeField]
        private DirectionalMovement m_Movement = null;

        [SerializeField]
        private DetectionSight m_Detection = null;

        private Vector2 m_MovementDirection = Vector2.zero;

        #endregion


        #region Lifecycle

        private void Awake()
        {
            // Init references
            if (!m_Movement) { m_Movement = GetComponent<DirectionalMovement>(); }
            if (!m_Detection) { m_Detection = GetComponent<DetectionSight>(); }

            /* Setup input bindings */

            InputAction moveAction = m_Controls.FindAction("Player/Move");
            moveAction.performed += (ctx) => { m_MovementDirection = ctx.ReadValue<Vector2>(); };
            moveAction.canceled += (ctx) => { m_MovementDirection = Vector2.zero; };

            m_Controls.Enable();
        }

        private void Update()
        {
            if (m_Movement != null)
            {
                Vector3 movement3d = new Vector3(m_MovementDirection.x, 0f, m_MovementDirection.y);
                m_Movement.Move(movement3d, Time.deltaTime);
            }

            GameObject objectInSight = m_Detection.GetObjectInSight();
            if(objectInSight)
                Debug.Log("Object " + name + " has " + objectInSight.name + " in sight!");
        }

        #endregion

    }

}