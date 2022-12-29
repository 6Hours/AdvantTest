using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI balanceText;

    [SerializeField] private RectTransform container;
    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.OnBalanceChange += OnBalanceChanged;

        var prefab = container.GetComponentInChildren<BusinessVisualizator>();
        foreach(var business in GameData.Instance.Progress.BusinessItems)
        {
            Instantiate(prefab, container).SetItem(business);
        }
    }

    private void OnDestroy()
    {
        GameData.Instance.OnBalanceChange -= OnBalanceChanged;
    }

    private void OnBalanceChanged(int value)
    {
        balanceText.text = value.ToString();
    }
}
