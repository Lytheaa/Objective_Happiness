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
        _data = GetComponentInParent<Villager>()._data;
    }

    private void Start() // Appel méthode au Start pour initialiser les graphics selon le métier 
    {
        //SetGraphics();
    }

    private void OnEnable()
    {
        _data.OnWorkChange.AddListener(SetGraphics);
    }
    private void OnDisable()
    {
        _data.OnWorkChange.RemoveListener(SetGraphics);
    }



    private void Update()
    {
        //this.SetGraphics(_data.WorkIndex);
    }

    /// Prévoir un Update si on veut changer les graphics en cours de jeu (changement de métier) ///

    private void SetGraphics(int workIndex)
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
        else if (_data.WorkIndex == 5)  //Itinerant graphics
        {
            _meshRenderer.material = _itinerantMaterial;
        }
    }

    //    private void SetGraphics(int workIndex)
    //{
    //    if (workIndex == 1)  //Picker graphics
    //    {
    //        _meshRenderer.material = _pickerMaterial;
    //    }
    //    else if (workIndex == 2)  //Woodsman graphics
    //    {
    //        _meshRenderer.material = _woodsmanMaterial;
    //    }
    //    else if (workIndex == 3)  //Miner graphics
    //    {
    //        _meshRenderer.material = _minerMaterial;
    //    }
    //    else if (workIndex == 4) //Builder graphics
    //    {
    //        _meshRenderer.material = _builderMaterial;
    //    }
    //    else if (workIndex == 5)  //Itinerant graphics
    //    {
    //        _meshRenderer.material = _itinerantMaterial;
    //    }
    //}
}
