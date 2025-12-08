using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagersGraphics : MonoBehaviour
{
    public VillagerDataSO _data;
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
        _data = GetComponentInParent<VillagerManager>()._data;
    }

    private void Start() // Appel méthode au Start pour initialiser les graphics selon le métier 
    {
        SetGraphics();
    }

    /// Prévoir un Update si on veut changer les graphics en cours de jeu (changement de métier) ///

    private void SetGraphics()
    {
        if (_data.WorkIndex == 1)  //Picker graphics
        {
            _meshRenderer.material = _pickerMaterial;
        }
        else if (_data.WorkIndex == 2)  //Woodsman graphics
        {
            _meshRenderer.material = _woodsmanMaterial;
        }
        else if (_data.WorkIndex == 3)  //Miner graphics
        {
            _meshRenderer.material = _minerMaterial;
        }
        else if (_data.WorkIndex == 4) //Builder graphics

        {
            _meshRenderer.material = _builderMaterial;
        }
        else if (_data.WorkIndex == 5) //Itinerant graphics
        {
            _meshRenderer.material = _itinerantMaterial;
        }
    }
}
