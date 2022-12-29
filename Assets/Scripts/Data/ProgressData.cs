using Data.ScriptableObjects;
using MyCore.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class ProgressData
    {
        public struct ProgressDataStruct
        {
            public List<BusinessItem.BusinessProgressData> Items;
        }

        public List<BusinessItem> BusinessItems { get; private set; }

        public ProgressData()
        {
            BusinessItems = new List<BusinessItem>();

            //models 
            BusinessScriptableObject[] Models = Resources.LoadAll<BusinessScriptableObject>("Configs");

            //progress
            ProgressDataStruct progress;
            progress.Items = new List<BusinessItem.BusinessProgressData>();

            BinarySerialFileService.LoadFromFile(ref progress, "Progress");

            foreach(var model in Models)
            {

                BusinessItems.Add(new BusinessItem(model,));
            }
        }

        public void SaveData()
        {

        }
    }
}
