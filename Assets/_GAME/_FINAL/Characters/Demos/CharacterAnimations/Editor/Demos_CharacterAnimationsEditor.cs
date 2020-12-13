using UnityEngine;
using UnityEditor;

namespace Final.Demos
{

    ///<summary>
    /// Custom editor for character animation tests script.
    /// It draws additional buttons in order to test animations easily.
    ///</summary>
    [CustomEditor(typeof(Demos_CharacterAnimations))]
    public class Demos_CharacterAnimationsEditor : Editor
	{

        private const string ANIMATOR_REFERENCE_PROP = "m_Animator";

		private Demos_CharacterAnimations m_CharacterAnimations = null;

        private SerializedProperty m_AnimatorReferenceProp = null;

        private void OnEnable()
        {
            // Cast the target and store it
            m_CharacterAnimations = target as Demos_CharacterAnimations;

            // Get the Animator component reference variable in the target script
            m_AnimatorReferenceProp = serializedObject.FindProperty(ANIMATOR_REFERENCE_PROP);
        }

        public override void OnInspectorGUI()
        {
            // Check for Animator component reference
            if(m_AnimatorReferenceProp.objectReferenceValue == null)
            {
                m_AnimatorReferenceProp.objectReferenceValue = m_CharacterAnimations.GetComponentInChildren<Animator>();
                serializedObject.ApplyModifiedProperties();

                // Display warning message if no Animator reference has been set
                if(m_AnimatorReferenceProp.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Missing Animator reference: Please set the Animator component reference that contain the character's animator controller in order to play animations as expected", MessageType.Warning);
                }
            }

            // Draw the original inspector
            base.OnInspectorGUI();

            // Display info message if the game is not currently running
            if(!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("You must enable Play mode in order to test animations", MessageType.Info);
            }
            GUI.enabled = EditorApplication.isPlaying;

            // Speed steps shortcuts
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Speed States", GUILayout.Width(EditorGUIUtility.labelWidth));

                if (GUILayout.Button("Idle"))
                    m_CharacterAnimations.Idle();

                if (GUILayout.Button("Walk"))
                    m_CharacterAnimations.Walk();

                if (GUILayout.Button("Run"))
                    m_CharacterAnimations.Run();
            }
            EditorGUILayout.EndHorizontal();

            // Animation triggers buttons
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Triggers", GUILayout.Width(EditorGUIUtility.labelWidth));

                if (GUILayout.Button("Punch"))
                    m_CharacterAnimations.Punch();

                if (GUILayout.Button("Throw"))
                    m_CharacterAnimations.Throw();

                if (GUILayout.Button("Hit"))
                    m_CharacterAnimations.Hit();

                if (GUILayout.Button("Die"))
                    m_CharacterAnimations.Die();
            }
            EditorGUILayout.EndHorizontal();

            GUI.enabled = true;
        }

    }

}