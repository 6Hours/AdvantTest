using UnityEngine;

namespace Data.LocalizationField.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LocalizationGroup", menuName = "Localization")]
    public class LocalizationGroupScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public struct LocalizationKeyStruct
        {
            public string Key;
            public string Value;
        }

        public LocalizationKeyStruct[] Pairs;
    }
}
