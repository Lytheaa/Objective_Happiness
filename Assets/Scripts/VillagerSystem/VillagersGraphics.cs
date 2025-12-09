using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagersGraphics : MonoBehaviour
{
    public VillagerData _data;
    private MeshRenderer _meshRenderer;

    /// COLORS  - Test avec des materials : à changer pour des components Image ? ///
    [SerializeField] private Material _pickerMaterial;
    [SerializeField] private Material _woodsmanMaterial;
    [SerializeField] private Material _minerMaterial;
    [SerializeField] private Material _builderMaterial;
    [SerializeField] private Material _itinerantMaterial;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _data = GetComponentInParent<VillagerData>();
    }

    private void Start() // Appel méthode au Start pour initialiser les graphics selon le métier 
    {

    }

    private void OnEnable()
    {
        _data.OnWorkChange += SetGraphics;
    }
    private void OnDisable()
    {
        _data.OnWorkChange -= SetGraphics;
    }

    private void SetGraphics(int workIndex)
    {
        Debug.Log($"Set graphics called with work index: {workIndex}");
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
}
