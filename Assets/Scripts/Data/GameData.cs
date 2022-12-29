using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class GameData : Singleton<GameData>
    {
        #region Attributes
        public Localization Localization { get; private set; }
        public ProgressData Progress { get; private set; }
        public Action<int> OnBalanceChange;

        private int balance; //maybe long?

        #endregion

        #region Properties

        public int Balance
        {
            get { return balance; }
            set { 
                balance = value < 0? 0 : value;
                OnBalanceChange?.Invoke(balance);
            }
        }

        #endregion

        public override void Awake()
        {
            base.Awake();

            Localization = new Localization();
            Progress = new ProgressData();


        }
        private void OnApplicationQuit()
        {
            
        }
    }
}
