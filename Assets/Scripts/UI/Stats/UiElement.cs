using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.stats
{
    public class UiElement : MonoBehaviour, IShow
    {
        //private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        
        [SerializeField] private bool _isActiveAtStart = false;
        [SerializeField] private float initialHeight;
        private void Awake()
        {
            // _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            if(!_isActiveAtStart) _canvasGroup.DOFade(0, 0).SetUpdate(true);
            else _canvasGroup.DOFade(1, 0).SetUpdate(true);
        }

        public void Show(bool show, Sequence sequ)
        {
            if (show)
            {
                // _rectTransform.DOSizeDelta(new Vector2(_rectTransform.sizeDelta.x, initialHeight), .2f);
                sequ.Insert(0,_canvasGroup.DOFade(1, .5f));
            }
            else
            {
                sequ.Insert(0, _canvasGroup.DOFade(0, .15f));
            }
        }
    }
}
