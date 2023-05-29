using UnityEngine;
using DG.Tweening;

public class CollectablesAnimation : MonoBehaviour
{
    private void Start()
    {
        transform.DORotate(new Vector3(0, 180, 0), 3f).SetLoops(-1);
        transform.DOMoveY(3,0.5f).SetLoops(-1,LoopType.Yoyo);
    }
}
