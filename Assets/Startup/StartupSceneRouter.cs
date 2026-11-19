using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Frap
{
    public class StartupSceneRouter : MonoBehaviour
    {
        public static readonly Dictionary<string, string> _startupModeSceneMapping = new()
        {
            { "Default", "Default" },
            { "Movement Prototyping", "MovementPrototyping" },
        };

        private void Awake()
        {
            string startupScene = _startupModeSceneMapping[StartupConfig.StartupMode];

            if (Application.CanStreamedLevelBeLoaded(startupScene))
            {
                Debug.Log($"Loading scene '{startupScene}' for StartupMode: {StartupConfig.StartupMode}");
                SceneManager.LoadScene(startupScene);
            }
            else
            {
                Debug.LogError($"Failed to load scene '{startupScene}'.  \n You might have forgotten to add it or there might be a typo.");
            }
        }
    }
}