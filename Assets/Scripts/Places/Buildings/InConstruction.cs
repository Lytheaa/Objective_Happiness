using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InConstruction : Place
{
    public Sprite PreviewSprite;
    public float ConstructionProgress { get { return _constructionProgress; } set { _constructionProgress = Math.Clamp(value, 0, 1); }}
    private float _constructionProgress = 0;
    
    [Header("PlacingMode")]
    [SerializeField] private Material validMat;
    [SerializeField] private Material invalidMat;
    
    [Header("Mason Work")]
    [Range(0,1)] public float progressAmount = .1f;

    [Header("Gizmos")] [SerializeField] private bool showGizmos = false;

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
        if (!showGizmos) return;
        
        Gizmos.DrawSphere(transform.position, 1.2f);
    }

    public override void PreAction(Villager villager)
    {
        print("preAction");
        //start villager animation
        //make it dont move
    }

    public override void Action(Villager villager)
    {
        print("action");
        if (!_placed) return;
        
        ConstructionProgress += progressAmount;
        if(ConstructionProgress >= 1)
            enabled = false;
    }

    public override void PostAction(Villager villager)
    {
        print("postAction");
        //disable villager working anim
        //make it move again
    }

    private bool CanPlace()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit[] allHits = Physics.SphereCastAll(ray, 1.2f);
        //print("lenght: "+allHits.Length);
        foreach (var hit in allHits)
        {
            if (hit.collider.GetComponent<Place>())
            {
                return _canPlace = false;
            }

            if (hit.collider.GetComponent<ConstructibleZone>())
            {
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