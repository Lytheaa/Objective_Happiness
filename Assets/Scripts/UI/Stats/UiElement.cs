using DG.Tweening;
using UnityEngine;

namespace UI.stats
{
    public class UiElement : MonoBehaviour, IShow
    {
        private RectTransform _rectTransform;
        [SerializeField] private float initialHeight;
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Show(bool show)
        {
            if (show)
            {
                _rectTransform.DOSizeDelta(new Vector2(_rectTransform.sizeDelta.x, initialHeight), .2f);
            }
            else
            {
                _rectTransform.DOSizeDelta(new Vector2(_rectTransform.sizeDelta.x, 0), .2f);
            }
        }
    }
}
