using UnityEngine;
using TMPro;
using DG.Tweening;

public class UI_TextValue : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textUI;

    public void SetTextValue(string text, bool animation = true)
    {
        if (animation)
        {
            Sequence textAnimation = DOTween.Sequence();
            textAnimation.Append(transform.DOScale(1.3f, .05f));
            textAnimation.AppendCallback(() => _textUI.text = text);
            textAnimation.Append(transform.DOScale(1f, .01f));
            textAnimation.Play();
        }
        else
        {
            _textUI.text = text;
        }
    }
}
