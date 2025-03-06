using DG.Tweening;
using UnityEngine;

public class FOVAnim : MonoBehaviour
{
    void Start()
    {
        Camera.main.transform.DOMoveY(0.1f, 3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
