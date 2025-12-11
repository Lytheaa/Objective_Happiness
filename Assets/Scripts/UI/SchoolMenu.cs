using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolMenu : MonoBehaviour
{
    public PlacesManager _placesManager;

    /// Work Buttons

    private void Awake()
    {
        _placesManager = PlacesManager.Instance;
    }


    private void Update()
    {
        if (_placesManager.SchoolWaypoints.Count > 0) // S'il y a au moins une école en jeu 
        {
           //this.Image.background.SetColor(0, 0, 0,100);
            
        } else
        {
            //this.Image.SetColor(0, 0, 0, 100);

            ///Griser images + lock interaction
        }
    }
}
