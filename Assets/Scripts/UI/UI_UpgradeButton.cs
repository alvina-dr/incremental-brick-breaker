using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum UpgradeButtonState
    {
        Deactivated = 0,
        Buyable = 1,
        Bought = 2
    }

    [ReadOnly]
    public UI_UpgradeMenu UpgradeMenu;
    public UI_UpgradeButton PreviousDependency;
    public UpgradeButtonState ButtonState;
    public Button Button;
    public bool CanBuySeveralTimes;
    public UnityEvent UpgradeEvent;
    public int Price;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private string _upgradeName;
    [SerializeField] private string _upgradeDescription;
    [SerializeField] private UI_LineRenderer _lineRenderer;
    [SerializeField] private GameObject _outline;
    [SerializeField] private GameObject _infiniteSymbol;

    private int _upgradeIndex;
    [SerializeField] private TextMeshProUGUI _upgradeIndexText;

    public void CheckState()
    {

        _priceText.text = (Price + Price * _upgradeIndex) + "$";

        if (CanBuySeveralTimes)
        {
            _infiniteSymbol.SetActive(true);

            if (_upgradeIndex != 0)
            {
                _upgradeIndexText.gameObject.SetActive(true);
                _upgradeIndexText.text = "." + _upgradeIndex.ToString();
            } 
            else
            {
                _upgradeIndexText.gameObject.SetActive(false);
            }
        }
        else
        {
            _upgradeIndexText.gameObject.SetActive(false);
            _infiniteSymbol.SetActive(false);
        }

        if (PreviousDependency == null || PreviousDependency.ButtonState == UpgradeButtonState.Bought)
        {
            // Make interactible
            Button.interactable = true;
            gameObject.SetActive(true);

            // Set line between dependencies
            if (PreviousDependency != null)
            {
                Vector2 positionDelta = PreviousDependency.transform.localPosition - transform.localPosition;
                _lineRenderer.points[1].x = positionDelta.x;
                _lineRenderer.points[1].y = positionDelta.y;
            }

            if (ButtonState == UpgradeButtonState.Bought)
            {
                Button.interactable = false;
            }
            else
            {
                if ((Price + Price * _upgradeIndex) <= GameManager.Instance.CurrentScore)
                {
                    // Show that you can buy
                }
                else
                {
                    // Show that you can't buy
                    Button.interactable = false;
                }
            }
        }
        else
        {
            // Deactivate interaction
            Button.interactable = false;
            gameObject.SetActive(false);
        }
    }

    public void Activate()
    {
        if (!CanBuySeveralTimes)
        {
            ButtonState = UpgradeButtonState.Bought;
            Button.interactable = false;
        }
        else
        {
            Button.interactable = true;
            _upgradeIndex++;
        }
    }

    public void Upgrade()
    {
        GameManager.Instance.SubstractScore((Price + Price * _upgradeIndex));
        Activate();
        UpgradeMenu.UpdateMenu();
        UpgradeEvent?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UpgradeMenu.SetUpgradeInfo(string.Empty, string.Empty);
        _outline.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UpgradeMenu.SetUpgradeInfo(_upgradeName, _upgradeDescription);
        _outline.SetActive(true);
    }
}
