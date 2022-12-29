using Data.ScriptableObjects;
using MyCore.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data
{
    public class ProgressData
    {
        [System.Serializable]
        public struct ProgressDataStruct
        {
            public List<BusinessItem.BusinessProgressData> Items;

            public ProgressDataStruct(List<BusinessItem.BusinessProgressData> _items)
            {
                Items = _items;
            }
        }

        public List<BusinessItem> BusinessItems { get; private set; }
        
        private ProgressDataStruct progressData;


        public ProgressData()
        {
            BusinessItems = new List<BusinessItem>();

            //models 
            BusinessScriptableObject[] Models = Resources.LoadAll<BusinessScriptableObject>("Configs");

            //progress
            BinarySerialFileService.LoadFromFile(ref progressData, "Progress");

            if(progressData.Items == null || progressData.Items.Count == 0)
            {
                progressData.Items = new List<BusinessItem.BusinessProgressData> {
                new BusinessItem.BusinessProgressData(1, 1, false, false, 0f)};
            }

            foreach(var model in Models)
            {
                if (progressData.Items.Any(item => item.Id == model.Id))
                {
                    BusinessItems.Add(
                        new BusinessItem(model, progressData.Items.First(item => item.Id == model.Id)));
                }
                else
                {
                    BusinessItems.Add(
                        new BusinessItem(model, new BusinessItem.BusinessProgressData(model.Id, 0, false, false, 0f)));
                }
            }
        }

        public void SaveData()
        {
            progressData.Items.Clear();
            foreach (var item in BusinessItems)
            {
                if (item.Level > 0)
                    progressData.Items.Add(new BusinessItem.BusinessProgressData(
                        item.Model.Id,
                        item.Level,
                        item.FirstModifyIsBuying,
                        item.SecondModifyIsBuying,
                        item.ProfitProgressTime));
            }
            BinarySerialFileService.SaveInFile(progressData, "Progress");
        }
    }
}
