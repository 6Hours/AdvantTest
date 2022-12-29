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
            public int Id;
            public int Level;
            public float ProfitProgress;
            public bool FirstModifyIsBuying;
            public bool SecondModifyIsBuying;

            public BusinessProgressData(int _id,int _level, bool _firstIsBuying, bool _secondIsBuying, float _profitProgress)
            {
                Id = _id;
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
        
        public bool FirstModifyIsBuying => dynamicData.FirstModifyIsBuying;
        public bool SecondModifyIsBuying => dynamicData.SecondModifyIsBuying;

        public float ProfitProgressTime
        {
            get => dynamicData.ProfitProgress;
            set
            {
                dynamicData.ProfitProgress = Mathf.Clamp(value, 0f, Model.BaseProfitDelay);
                if(dynamicData.ProfitProgress == Model.BaseProfitDelay)
                {
                    GameData.Instance.Balance += Profit;
                    dynamicData.ProfitProgress = 0f;
                }
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
            GameData.Instance.Balance -= LevelUpCost;
            dynamicData.Level += 1;
        }

        public void BuyFirstModify()
        {
            GameData.Instance.Balance -= Model.FirstModify.Cost;
            dynamicData.FirstModifyIsBuying = true;
        }

        public void BuySecondModify()
        {
            GameData.Instance.Balance -= Model.SecondModify.Cost;
            dynamicData.SecondModifyIsBuying = true;
        }
    }
}
