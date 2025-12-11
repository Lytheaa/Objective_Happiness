using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolMenu : MonoBehaviour
{
    public PlacesManager _placesManager;

    [SerializeField] public Image[] _imagesButtons = new Image[4];

    /// Work Buttons

    private void Awake()
    {
        _placesManager = PlacesManager.Instance;

        for (int i = 0; i < _imagesButtons.Length; i++)
        {
            _imagesButtons[i] = GetComponentInChildren<Image>();
        }
        
    }


    private void Update()
    {
        if (_placesManager.SchoolWaypoints.Count > 0) // S'il y a au moins une école en jeu 
        {
            //this.Sprite.Image.background.SetColor(0, 0, 0, 100);

        } else
        {
            //this.Image.SetColor(0, 0, 0, 100);

            ///Griser images + lock interaction
        }
    }
}
