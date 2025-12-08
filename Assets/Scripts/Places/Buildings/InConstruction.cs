using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InConstruction : MonoBehaviour
{
    public Sprite PreviewSprite;

    [SerializeField] private Material validMat;
    [SerializeField] private Material invalidMat;

    private bool _canPlace = false;
    private bool _placed = false;
    
    private MeshRenderer _meshRenderer;
    private Material _defaultMat;

    private void OnEnable()
    {
        MouseManager.OnMouseMove += StickTo;
        MouseManager.OnMouseClick += OnClick;
        transform.gameObject.layer = 2; //ignore raycast layer
    }

    private void OnDisable()
    {
        PlaceBuilding();
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMat = _meshRenderer.material;
    }

    private void Update()
    {
        if(!_placed)
        {
            CanPlace();
            if (_canPlace)
                _meshRenderer.material = validMat;
            else
                _meshRenderer.material = invalidMat;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1.2f);
    }

    private bool CanPlace()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit[] allHits = Physics.SphereCastAll(ray, 1.2f);
        print("lenght: "+allHits.Length);
        foreach (var hit in allHits)
        {
            if (hit.collider.GetComponent<Place>())
            {
                print("donthiitttt");
                return _canPlace = false;
            }

            if (hit.collider.GetComponent<ConstructibleZone>())
            {
                print("hitttt");
                _canPlace = true;
            }
        }
        return _canPlace;
    }

    private void PlaceBuilding()
    {
        _placed = true;
        
        MouseManager.OnMouseMove -= StickTo;
        transform.gameObject.layer = 0; //default layer
        _meshRenderer.material = _defaultMat;
    }

    private void StickTo(Vector3 position)
    {
        transform.position = position;
    }

    private void OnClick()
    {
        if (_canPlace)
        {
            PlaceBuilding();
        }
    }
}