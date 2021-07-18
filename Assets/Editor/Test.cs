
using Hextant;
using Hextant.Editor;
using UnityEditor;
using UnityEngine;

namespace Test
{
    [Settings(SettingsUsage.EditorUser, "A boolean setting")]
    public sealed class TestSettings : Settings<TestSettings>
    {
        public bool Boolean { get => _boolean; set => Set(ref _boolean, value); }
        [SerializeField, Tooltip("A boolean value, true by default")] 
        private bool _boolean = true;

        [SettingsProvider]
        static SettingsProvider GetSettingsProvider() => instance.GetSettingsProvider();
    }

    [InitializeOnLoad]
    public class EditorTest
    {
        [MenuItem("Do Test/Print")]
        public static void Print()
        {
            Debug.Log(TestSettings.instance.Boolean);
        }

        [MenuItem("Do Test/Set to false")]
        public static void SetToFalse()
        {
            Debug.Log(TestSettings.instance.Boolean);
            TestSettings.instance.Boolean = false;
        }
    }
}