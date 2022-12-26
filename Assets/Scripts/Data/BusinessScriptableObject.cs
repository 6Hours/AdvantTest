using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Business", menuName = "Business Config")]
    public class BusinessScriptableObject : ScriptableObject
    {
        [Serializable]
        public struct ModifyData
        {
            public string NameId;
            public int Cost;
            public int ProfitPercent;
        }

        [SerializeField] private int id;
        [SerializeField] private string nameId;
        [SerializeField] private int baseProfitDelay;
        [SerializeField] private int baseCost;
        [SerializeField] private int baseProfit;
        [SerializeField] private ModifyData firstModify;
        [SerializeField] private ModifyData secondModify;

        public int Id => id;
        public string NameId => NameId;
        public int BaseProfitDelay => baseProfitDelay;
        public int BaseCost => baseCost;
        public int BaseProfit => baseProfit;
        public ModifyData FirstModify => firstModify;
        public ModifyData SecondModify => secondModify;
    }
}