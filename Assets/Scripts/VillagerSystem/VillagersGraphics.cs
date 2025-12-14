using UnityEngine;

public class VillagersGraphics : MonoBehaviour
{
    private Villager _villager;
    private MeshRenderer _meshRenderer;

    [SerializeField]private GameObject _outline;

    [SerializeField]private bool _isSelected = false;
    public bool IsSelected { get { return _isSelected; } set { _isSelected = value; } }

    [Header("Graphics parameters")]
    /// COLORS  - Test avec des materials : à changer pour des components Image ? ///
    [SerializeField] private Material _pickerMaterial;
    [SerializeField] private Material _woodsmanMaterial;
    [SerializeField] private Material _minerMaterial;
    [SerializeField] private Material _builderMaterial;
    [SerializeField] private Material _itinerantMaterial;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
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
        //_data.OnWorkChange -= SetGraphics;
        _villager.Data.OnWorkChange -= SetGraphics;
    }

    private void SetGraphics(int workIndex)
    {
        if (workIndex == 1)  //Picker graphics
        {
            _meshRenderer.material = _pickerMaterial;
        }
        else if (workIndex == 2)  //Woodsman graphics
        {
            _meshRenderer.material = _woodsmanMaterial;
        }
        else if (workIndex == 3)  //Miner graphics
        {
            _meshRenderer.material = _minerMaterial;
        }
        else if (workIndex == 4) //Builder graphics
        {
            _meshRenderer.material = _builderMaterial;
        }
        else if (workIndex == 5)  //Itinerant graphics
        {
            _meshRenderer.material = _itinerantMaterial;
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
