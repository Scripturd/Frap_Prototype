using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Frap
{
    public class BootstrapConfigWindow : EditorWindow
    {
        private static readonly string _title = "Bootstrap Config";

        private string _selectedMode;


        [MenuItem("Frap/Startup Mode")]
        public static void ShowWindow()
            => GetWindow<BootstrapConfigWindow>(_title);

        private void OnEnable()
        {
            _selectedMode = StartupConfig.StartupMode;
        }

        private void OnGUI()
        {
            GUILayout.Label("Select Startup Mode", EditorStyles.boldLabel);

            GUILayout.Space(15);

            EditorGUI.BeginChangeCheck();
            int selectedModeIndex = EditorGUILayout.Popup(
                "Startup Mode",
                Array.IndexOf(StartupSceneRouter._startupModeSceneMapping.Keys.ToArray(), _selectedMode),
                StartupSceneRouter._startupModeSceneMapping.Keys.ToArray()
            );
            string selectedMode = StartupSceneRouter._startupModeSceneMapping.Keys.ElementAt(selectedModeIndex);

            if (EditorGUI.EndChangeCheck())
            {
                //Debug.Log($"StartupMode set to: {_selectedMode}");
                _selectedMode = selectedMode;
                StartupConfig.StartupMode = _selectedMode;

                Repaint();
            }
        }

    }
}