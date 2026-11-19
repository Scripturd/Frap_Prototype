using System.Collections.Generic;
using UnityEditor;

namespace Frap
{
    public static class StartupConfig
    {
        private static readonly string _editorPrefsKey = "StartupMode";

        public static string StartupMode
        {
            get
            {
                return EditorPrefs.GetString(_editorPrefsKey, "Default");
            }
            set
            {
                EditorPrefs.SetString(_editorPrefsKey, value);
            }
        }
    }
}