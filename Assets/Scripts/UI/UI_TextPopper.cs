using DG.Tweening;
using TMPro;
using UnityEngine;

public class UI_TextPopper : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TextMeshUI;

    public void PopText(string text)
    {
        transform.localScale = Vector3.zero;
        TextMeshUI.text = text;
        transform.DOShakeRotation(.3f, 1, 5, 10);
        Sequence textAnimation = DOTween.Sequence();
        textAnimation.Append(transform.DOScale(1.3f, .05f));
        textAnimation.Append(transform.DOScale(1f, .01f));
        textAnimation.Append(transform.DOMoveY(transform.position.y + 50, .2f));
        textAnimation.AppendCallback(() =>
        {
            Destroy(gameObject);
        });
    }
}
