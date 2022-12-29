using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BusinessVisualizator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image progressLine;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI profitText;

        [SerializeField] private Button levelUpBtn;
        [SerializeField] private TextMeshProUGUI levelUpBtnText;

        [SerializeField] private Button modify1Btn;
        [SerializeField] private TextMeshProUGUI modify1BtnText;

        [SerializeField] private Button modify2Btn;
        [SerializeField] private TextMeshProUGUI modify2BtnText;

        private BusinessItem item;

        void Start()
        {
            levelUpBtn.onClick.AddListener(LevelUpPress);
            modify1Btn.onClick.AddListener(Modify1Press);
            modify2Btn.onClick.AddListener(Modify2Press);
        }

        void Update()
        {
            if (item != null)
            {
                if (item.Level > 0)
                {
                    item.ProfitProgressTime += Time.deltaTime;

                }
                UpdateView();
            }
        }

        public void SetItem(BusinessItem _item)
        {
            item = _item;
        }

        private void LevelUpPress()
        {
            item.LevelUp();
        }

        private void Modify1Press()
        {
            item.BuyFirstModify();
        }

        private void Modify2Press()
        {
            item.BuySecondModify();
        }

        private void UpdateView()
        {
            progressLine.fillAmount = item.ProfitProgressTime / item.Model.BaseProfitDelay;

            levelText.text = string.Format("Lvl\n{0}", item.Level);

            profitText.text = string.Format("Profit\n{0}", item.Profit);

            levelUpBtn.interactable = GameData.Instance.Balance > item.LevelUpCost;
            levelUpBtnText.text = string.Format("LVL UP\nCost: {0}", item.LevelUpCost);
            //Modification
            modify1Btn.interactable = !item.FirstModifyIsBuying && GameData.Instance.Balance > item.Model.FirstModify.Cost;
            modify1BtnText.text = string.Format(
                "{0}\nProfit {1}\nCost: {2}", 
                item.Model.FirstModify.NameId,
                item.Model.FirstModify.ProfitPercent,
                item.Model.FirstModify.Cost);

            modify1Btn.interactable = !item.FirstModifyIsBuying && GameData.Instance.Balance > item.Model.SecondModify.Cost;
            modify1BtnText.text = string.Format(
                "{0}\nProfit {1}\nCost: {2}",
                item.Model.FirstModify.NameId,
                item.Model.FirstModify.ProfitPercent,
                item.Model.FirstModify.Cost);
        }
    }
}
