using UnityEngine;
using UnityEngine.UI;

public class VillagersGraphics : MonoBehaviour
{
    private Villager _villager;
    [SerializeField]private Image _workIcon;

    [SerializeField]private GameObject _outline;

    [SerializeField]private bool _isSelected = false;
    public bool IsSelected { get { return _isSelected; } set { _isSelected = value; } }

    [Header("Graphics parameters")]
    [SerializeField] private Sprite _pickerIcon;
    [SerializeField] private Sprite _woodsmanIcon;
    [SerializeField] private Sprite _minerIcon;
    [SerializeField] private Sprite _builderIcon;
    [SerializeField] private Sprite _itinerantIcon;

    private void Awake()
    {
        //_workIcon = GetComponentInChildren<Image>();
        _villager = GetComponentInParent<Villager>();

        _outline = transform.parent.Find("Outline").gameObject;
        _outline.SetActive(false);
    }

    /// EVENT LISTENER///
    
    private void OnEnable()
    {
        _villager.Data.OnWorkChange += SetGraphics;
    }
    private void OnDisable()
    {
        _villager.Data.OnWorkChange -= SetGraphics;
    }

    private void SetGraphics(int workIndex)
    {
        if (workIndex == 1)  //Picker graphics
        {
            _workIcon.sprite = _pickerIcon;
        }
        else if (workIndex == 2)  //Woodsman graphics
        {
            _workIcon.sprite = _woodsmanIcon;
        }
        else if (workIndex == 3)  //Miner graphics
        {
            _workIcon.sprite = _minerIcon;
        }
        else if (workIndex == 4) //Builder graphics
        {
            _workIcon.sprite = _builderIcon;
        }
        else if (workIndex == 5)  //Itinerant graphics
        {
            _workIcon.sprite = _itinerantIcon;
        }
    }

    public void ActiveOutline()
    {
        if (_outline != null)
            _outline.SetActive(true);
    }

    public void DisactiveOutline()
    {
        if (_outline != null)
            _outline.SetActive(false);
    }
}
