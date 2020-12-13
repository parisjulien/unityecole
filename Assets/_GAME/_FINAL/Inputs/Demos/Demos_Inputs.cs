using UnityEngine;
using UnityEngine.InputSystem;

namespace Final.Demos
{

    ///<summary>
    /// This component is meant to test the new input system.
    /// Create an "Input Action" asset (go to Assets > Create > Input Action). Then, configure a Vector2 input named "Move", and a button
    /// input named "Fire".
    /// Put this script on an object in your scene, set your created Input Action asset as reference in the "Controls" field. Run the game,
    /// and so you can test your inputs configuration!
    ///</summary>
    [AddComponentMenu("_FINAL/Demos/Inputs")]
    public class Demos_Inputs : MonoBehaviour
    {

        #region Properties

        [Header("References")]

        [SerializeField]
        private InputActionAsset m_Controls = null;

        [Header("Settings")]

        [SerializeField, Range(1f, 10f)]
        private float m_MovementSpeed = 6f;

        private Vector2 m_MovementDirection = Vector2.zero;

        #endregion


        #region Lifecycle

        private void Awake()
        {
            InputAction moveAction = m_Controls.FindAction("Player/Move");
            moveAction.performed += (ctx) => { m_MovementDirection = ctx.ReadValue<Vector2>(); } ;
            moveAction.canceled += (ctx) => { m_MovementDirection = Vector2.zero; };

            InputAction fireAction = m_Controls.FindAction("Player/Fire");
            fireAction.started += (ctx) => { Fire(); };
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
            Move(m_MovementDirection, Time.deltaTime);
        }

        #endregion


        #region Public API

        /// <summary>
        /// Makes the object move in the given direction.
        /// </summary>
        /// <param name="_Direction">The direction you want the object to move.</param>
        /// <param name="_DeltaTime">The elapsed time since the last frame.</param>
        public void Move(Vector2 _Direction, float _DeltaTime)
        {
            if (_Direction == Vector2.zero)
                return;

            _Direction.Normalize();
            Vector3 direction3d = new Vector3(_Direction.x, 0f, _Direction.y);
            transform.position += direction3d * m_MovementSpeed * _DeltaTime;
            transform.forward = direction3d;
        }

        /// <summary>
        /// Makes the entity fire.
        /// </summary>
        public void Fire()
        {
            Debug.Log("Fire!");
        }

        #endregion

    }

}