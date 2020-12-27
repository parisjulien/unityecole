using Final;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Final
{

    ///<summary>
    /// Setup input bindings and actions for a player.
    ///</summary>
    [AddComponentMenu("_FINAL/Characters/Player/Player Controller")]
    public class PlayerController : MonoBehaviour
    {

        #region Properties

        [Header("References")]

        [SerializeField]
        private InputActionAsset m_Controls = null;

        [SerializeField]
        private DirectionalMovement m_Movement = null;

        private Vector2 m_MovementDirection = Vector2.zero;

        #endregion


        #region Lifecycle

        private void Awake()
        {
            // Init references
            if(!m_Movement) { m_Movement = GetComponent<DirectionalMovement>(); }

            /* Setup input bindings */

            InputAction moveAction = m_Controls.FindAction("Player/Move");
            moveAction.performed += (ctx) => { m_MovementDirection = ctx.ReadValue<Vector2>(); };
            moveAction.canceled += (ctx) => { m_MovementDirection = Vector2.zero; };

            //InputAction fireAction = m_Controls.FindAction("Player/Fire");
            //fireAction.started += (ctx) => { Debug.Log("TODO: Player fire action"); };
        }

        private void OnEnable()
        {
            m_Controls.FindActionMap("Player").Enable();
        }

        private void OnDisable()
        {
            m_Controls.FindActionMap("Player").Disable();
        }

        private void Update()
        {
            if(m_Movement != null)
            {
                Vector3 movement3d = new Vector3(m_MovementDirection.x, 0f, m_MovementDirection.y);
                m_Movement.Move(movement3d, Time.deltaTime);
            }
        }

        #endregion

    }

}