using Data.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class BusinessItem
    {
        [Serializable]
        public struct BusinessProgressData
        {
            public int Level;
            public float ProfitProgress;
            public bool FirstModifyIsBuying { get; private set; }
            public bool SecondModifyIsBuying { get; private set; }


            public BusinessProgressData(int _level, bool _firstIsBuying, bool _secondIsBuying, float _profitProgress)
            {
                Level = _level;
                FirstModifyIsBuying = _firstIsBuying;
                SecondModifyIsBuying = _secondIsBuying;
                ProfitProgress = _profitProgress;
            }
        }


        #region Attributes
        
        public BusinessScriptableObject Model { get; private set; }
        public Action OnChange;
        private BusinessProgressData dynamicData;

        #endregion

        #region Properties

        public int Profit => Mathf.FloorToInt(dynamicData.Level * Model.BaseProfit * (1 + 
            (dynamicData.FirstModifyIsBuying? Model.FirstModify.ProfitPercent / 100f : 0f) +
            (dynamicData.SecondModifyIsBuying ? Model.SecondModify.ProfitPercent / 100f : 0f)));

        public int Level => dynamicData.Level;
        
        public int LevelUpCost => Mathf.FloorToInt((dynamicData.Level + 1) * Model.BaseCost);
        
        public float ProfitPercent
        {
            get => dynamicData.ProfitProgress;
            set
            {
                dynamicData.ProfitProgress = Mathf.Clamp(value, 0f, Model.BaseProfitDelay);
                OnChange?.Invoke();
            }
        }

        #endregion

        public BusinessItem(BusinessScriptableObject _model, BusinessProgressData data)
        {
            Model = _model;
            dynamicData = data;
        }

        public void LevelUp()
        {
            //if(LevelUpCost > )
        }
    }
}
