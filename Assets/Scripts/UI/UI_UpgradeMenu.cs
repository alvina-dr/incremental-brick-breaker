using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpgradeMenu : MonoBehaviour
{
    public List<UI_UpgradeButton> UpgradeButtonList = new();
    [SerializeField] private TextMeshProUGUI _upgradeNameText;
    [SerializeField] private TextMeshProUGUI _upgradeDescriptionText;

    [Button]
    public void FindAllUpgradeButton()
    {
        UpgradeButtonList.Clear();
        UpgradeButtonList = GetComponentsInChildren<UI_UpgradeButton>().ToList();
        for (int i = 0; i < UpgradeButtonList.Count; i++)
        {
            UpgradeButtonList[i].UpgradeMenu = this;
        }
    }

    public void OpenMenu()
    {
        UpdateMenu();
    }

    public void UpdateMenu()
    {
        for (int i = 0; i < UpgradeButtonList.Count; i++)
        {
            UpgradeButtonList[i].CheckState();
        }
    }

    public void SetUpgradeInfo(string name, string description)
    {
        _upgradeNameText.text = name;
        _upgradeDescriptionText.text = description;
    }
}
