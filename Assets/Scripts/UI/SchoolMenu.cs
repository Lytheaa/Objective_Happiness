using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolMenu : MonoBehaviour
{
    public PlacesManager _placesManager;
    public UIManager _uIManager;

    [SerializeField] private Toggle[] _togglesSchoolMenu = new Toggle[4];

    private void Awake()
    {
        _placesManager = PlacesManager.Instance;
        _uIManager = UIManager.Instance;

        foreach (Toggle toggles in _togglesSchoolMenu)
        {
            toggles.interactable = false;
            toggles.isOn = false;
        }

    }

    private void Update()
    {
        SchoolMenuGraphics();
    }


    private void SchoolMenuGraphics()
    {
        if (this.gameObject.activeSelf)
        {
            if (_placesManager.SchoolWaypoints.Count > 0) // S'il y a au moins une école en jeu 
            {
                foreach (Toggle toggle in _togglesSchoolMenu)
                {
                    toggle.interactable = true;
                    toggle.image.color = new Color(1, 1, 1, 1);
                }

            }
            else // S'il n'y a pas d'école
            {
                foreach (Toggle toggle in _togglesSchoolMenu)
                {
                    toggle.interactable = false;
                    toggle.image.color = new Color(1, 1, 1, 0.25f);

                }

            }
        }
    }

}
