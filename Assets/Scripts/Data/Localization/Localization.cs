using Data.LocalizationField.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.LocalizationField
{
    public class Localization
    {
        private Dictionary<string, string> localization;

        public Localization()
        {
            localization = new Dictionary<string, string>();

            var groups = Resources.LoadAll<LocalizationGroupScriptableObject>("LocalizationGroups");
            foreach (var group in groups)
            {
                foreach(var pair in group.Pairs)
                    if(!localization.TryAdd(pair.Key, pair.Value))
                    {
                        Debug.LogError("Intersect between loaclization rows: Key:" + pair.Key + " Value:"+ pair.Value);
                    }
            }
        }

        public string this[string key]
        {
            get => localization[key];
        }
    }
}