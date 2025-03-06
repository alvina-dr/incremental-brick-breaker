using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color _activated;
    [SerializeField] private Color _deactivated;
    [SerializeField] private Image _background;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _background.color = _activated;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _background.color = _deactivated;
    }
}
