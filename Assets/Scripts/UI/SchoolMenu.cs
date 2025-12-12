using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolMenu : MonoBehaviour
{
    public PlacesManager _placesManager;

    [SerializeField] private Image[] _imagesButtons = new Image[4];
    //[SerializeField] private Graphics[] _imagesButtons = new Graphics[4];
    private GameObject _container;

    /// Work Buttons

    private void Awake()
    {
        _placesManager = PlacesManager.Instance;
    }


    private void Update()
    {
        if(this.gameObject.activeSelf)
        {
        for (int i = 0; i < _imagesButtons.Length; i++)
        {
            if (_placesManager.SchoolWaypoints.Count > 0) // S'il y a au moins une école en jeu 
            {
                _imagesButtons[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                _imagesButtons[i].color = new Color(1, 1, 1, 0.25f);
            }
        }

        }
    }
}