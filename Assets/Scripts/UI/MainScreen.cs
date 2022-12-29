using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI balanceText;

    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.OnBalanceChange += OnBalanceChanged;
    }

    private void OnDestroy()
    {
        GameData.Instance.OnBalanceChange -= OnBalanceChanged;
    }

    private void OnBalanceChanged(int value)
    {

    }
}
