using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolMenu : MonoBehaviour
{
    [SerializeField] private Toggle[] _togglesSchoolMenu = new Toggle[4];

    private void Awake()
    {

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
            if (PlacesManager.Instance.SchoolWaypoints.Count > 0) // S'il y a au moins une �cole en jeu 
            {
                foreach (Toggle toggle in _togglesSchoolMenu)
                {
                    toggle.interactable = true;
                    toggle.image.color = new Color(1, 1, 1, 1);
                }
            }
            else // S'il n'y a pas d'�cole
            {
                foreach (Toggle toggle in _togglesSchoolMenu)
                {
                    toggle.interactable = false;
                    toggle.image.color = new Color(1, 1, 1, 0.6f);
                }
            }
        }
    }

}
