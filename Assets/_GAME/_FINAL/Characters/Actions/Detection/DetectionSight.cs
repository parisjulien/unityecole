using Boo.Lang;
using System.Security.Principal;
using UnityEngine;

namespace Final
{

    ///<summary>
    /// Detects objects in a range or/and in a sight cone.
    ///</summary>
    [AddComponentMenu("_FINAL/Characters/Actions/Detection Sight")]
    public class DetectionSight : MonoBehaviour
    {

        #region Properties

        [Header("References")]

        [SerializeField]
        [Tooltip("The referenced collider is used to apply \"Ignore Self\" option. That option won't work if set to true but this field is empty")]
        private Collider m_Collider = null;

        [Header("Settings")]

        [SerializeField, Min(.05f)]
        [Tooltip("Defines how far this entity can detect objects")]
        private float m_SightRange = 8f;

        [SerializeField, Range(1f, 360f)]
        [Tooltip("Defines the angle of the detection cone (in degrees)")]
        private float m_SighAngle = 160f;

        [SerializeField]
        [Tooltip("Defines an offset to add to this object's transform position")]
        private Vector3 m_DetectionOriginOffset = Vector3.zero;

        [SerializeField]
        [Tooltip("Defines the layers that can be detected when checking if objects are in range. You should target only the layers that the objects to detect are on")]
        private LayerMask m_RangeDetectionLayer = ~0;

        [SerializeField]
        [Tooltip("Defines the layers that can be detected as \"obstacles\" when checking if a detected object in range is in sight. You should target all possible layers")]
        private LayerMask m_SightDetectionLayer = ~0;

        [SerializeField]
        [Tooltip("If the selected detection layers include the current object layer, this object will detect itself. If this option is set to true, the object won't consider itself as something in sight")]
        private bool m_IgnoreSelf = true;

#if UNITY_EDITOR

        [System.Serializable]
        private class DetectionSightDebugSettings
        {
            [SerializeField]
            public Color sightRangeGizmosColor = Color.red;

            [SerializeField]
            public Color sightAngleGizmosColor = Color.red;

            [SerializeField]
            public Color detectionOriginGizmosColor = Color.magenta;

            [SerializeField, Min(.5f)]
            public float sightAngleGizmoAngleInterval = 5f;

            [SerializeField, Min(0)]
            public float detectionOriginSphereRadius = .15f;
        }

        [Header("Debug")]

        [SerializeField]
        private DetectionSightDebugSettings m_DebugSettings = new DetectionSightDebugSettings();

#endif

        #endregion


        #region Lifecycle

        private void Awake()
        {
            if(!m_Collider) { m_Collider = GetComponent<Collider>(); }
        }

        #endregion


        #region Public API

        /// <summary>
        /// Checks if this object has something in sight.
        /// </summary>
        public bool HasSomethingInSight()
        {
            return GetColliderInSight();
        }

        /// <summary>
        /// Gets the first collider detected in the detection range. Note that this method doesn't check the detection angle. Also, it just
        /// gets one of the detected objects in range, which is not guaranteed to be the closest.
        /// </summary>
        /// <returns>Returns the detected collider, otherwise null.</returns>
        public Collider GetColliderInRange()
        {
            Collider[] objectsInRange = Physics.OverlapSphere(DetectionOrigin, m_SightRange, m_RangeDetectionLayer);
            foreach(Collider collider in objectsInRange)
            {
                // If the object detects itself, but "Ignore Self" option is enabled, skip the current object in range
                if (m_Collider && collider == m_Collider && m_IgnoreSelf)
                    continue;
                else
                    return collider;
            }
            return null;
        }

        /// <summary>
        /// Gets the first GameObject detected in the detection range. Note that this method doesn't check the detection angle. Also, it
        /// just gets one of the detected objects in range, which is not guaranteed to be the closest.
        /// </summary>
        /// <returns>Returns the detected GameObject, otherwise null.</returns>
        public GameObject GetObjectInRange()
        {
            Collider objectInSight = GetColliderInRange();
            return objectInSight ? objectInSight.gameObject : null;
        }

        /// <summary>
        /// Gets all the colliders in the detection range. Note that this method doesn't check the detection angle.
        /// </summary>
        /// <returns>Returns an array of all the detected colliders.</returns>
        public Collider[] GetAllCollidersInRange()
        {
            Collider[] objectsInRange = Physics.OverlapSphere(DetectionOrigin, m_SightRange, m_RangeDetectionLayer);

            if(m_IgnoreSelf)
            {
                List<Collider> output = new List<Collider>();
                foreach(Collider collider in objectsInRange)
                {
                    // If the object detects itself, but "Ignore Self" option is enabled, skip the current object in range
                    if (m_Collider && collider == m_Collider)
                        continue;
                    else
                        output.Add(collider);
                }
                return output.ToArray();
            }

            return objectsInRange;
        }

        /// <summary>
        /// Gets all the GameObject in the detection range. Note that this method doesn't check the detection angle.
        /// </summary>
        /// <returns>Returns an array of all the detected GameObjects.</returns>
        public GameObject[] GetAllObjectsInRange()
        {
            Collider[] objectsInRange = GetAllCollidersInRange();
            GameObject[] objs = new GameObject[objectsInRange.Length];
            for(int i = 0; i < objectsInRange.Length; i++)
            {
                objs[i] = objectsInRange[i].gameObject;
            }
            return objs;
        }

        /// <summary>
        /// Gets the first collider in sight (in the detection range and in the detection angle).
        /// Note that this method just gets one of the detected objects in range, which is not guaranteed to be the closest.
        /// </summary>
        /// <returns>Returns the found collider, otherwise null.</returns>
        public Collider GetColliderInSight()
        {
            Collider collider = GetColliderInRange();
            return collider && IsInSight(collider) ? collider : null;
        }

        /// <summary>
        /// Gets the first GameObject in sight (in the detection range and in the detection cone).
        /// Note that this method just gets one of the detected objects in range, which is not guaranteed to be the closest.
        /// </summary>
        /// <returns>Returns the found GameObject, otherwise null.</returns>
        public GameObject GetObjectInSight()
        {
            Collider colliderInSight = GetColliderInSight();
            return colliderInSight ? colliderInSight.gameObject : null;
        }

        /// <summary>
        /// Gets all colliders in sight (in the detection range and in the detection cone).
        /// </summary>
        /// <returns>Returns all the colliders in sight.</returns>
        public Collider[] GetAllCollidersInSight()
        {
            Collider[] objectsInRange = GetAllCollidersInRange();
            List<Collider> objectsInSight = new List<Collider>();

            foreach (Collider collider in objectsInRange)
            {
                if (IsInSight(collider))
                    objectsInSight.Add(collider);
            }

            return objectsInSight.ToArray();
        }

        /// <summary>
        /// Gets all GameObjects in sight (in the detection range and in the detection cone).
        /// </summary>
        /// <returns>Returns all the GameObjects in sight.</returns>
        public GameObject[] GetAllObjectsInSight()
        {
            Collider[] collidersInSight = GetAllCollidersInSight();
            GameObject[] objectsInSight = new GameObject[collidersInSight.Length];
            for(int i = 0; i < collidersInSight.Length; i++)
            {
                objectsInSight[i] = collidersInSight[i].gameObject;
            }
            return objectsInSight;
        }

        /// <summary>
        /// Gets the detection origin point, which is this object's position + the offset.
        /// </summary>
        public Vector3 DetectionOrigin
        {
            get { return transform.position + m_DetectionOriginOffset; }
        }

        #endregion


        #region Private method

        /// <summary>
        /// Checks if the given collider is in sight (so it's in the detection cone, and not hidden behind another collider).
        /// </summary>
        /// <param name="_Target">The collider you want to detect, assuming the collider is in the detection range.</param>
        private bool IsInSight(Collider _Target)
        {
            // Trace a raycast to the detected object
            Vector3 toCollider = _Target.transform.position - DetectionOrigin;

            // Check if the target is in the detection sight cone
            if (Vector3.Angle(transform.forward, toCollider) <= m_SighAngle / 2f)
            {
                Physics.Raycast(DetectionOrigin, toCollider, out RaycastHit hitInfos, m_SightRange, m_SightDetectionLayer);
                // If the raycast doesn't hit anything or hits the detected object, it means that it's visible
                return hitInfos.collider == null || hitInfos.collider == _Target;
            }

            return false;
        }

        #endregion


        #region Debug

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            // Draw the detection origin point
            Gizmos.color = m_DebugSettings.detectionOriginGizmosColor;
            Gizmos.DrawLine(transform.position, DetectionOrigin);
            Gizmos.DrawSphere(DetectionOrigin, m_DebugSettings.detectionOriginSphereRadius);

            // Draw sight range gizmo
            Gizmos.color = m_DebugSettings.sightRangeGizmosColor;
            Vector3 start = DetectionOrigin;
            Gizmos.DrawWireSphere(start, m_SightRange);

            // Draw sight angle gizmo right line
            Gizmos.color = m_DebugSettings.sightAngleGizmosColor;
            Quaternion rotation = Quaternion.AngleAxis(m_SighAngle / 2, Vector3.up);
            Vector3 direction = rotation * transform.forward;
            Gizmos.DrawLine(start, start + direction * m_SightRange);

            int steps = Mathf.FloorToInt(m_SighAngle / m_DebugSettings.sightAngleGizmoAngleInterval);
            float angle = -m_SighAngle / 2;
            for (int i = 0; i <= steps; i++)
            {
                rotation = Quaternion.AngleAxis(angle, Vector3.up);
                direction = rotation * transform.forward;
                Gizmos.DrawLine(start, start + direction * m_SightRange);

                angle += m_DebugSettings.sightAngleGizmoAngleInterval;
            }
        }

#endif

        #endregion

    }

}