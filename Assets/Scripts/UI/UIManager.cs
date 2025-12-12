using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _schoolMenu;

    private VillagersGraphics _graphicsSelected; // le villageois actuellement sélectionné


    private void Awake()
    {
        _schoolMenu.SetActive(false);
    }

    private void OnEnable()
    {
        MouseManager.OnObjectClicked += SelectVillager;
    }
    private void OnDisable()
    {
        MouseManager.OnObjectClicked -= SelectVillager;
    }

    private void SelectVillager(GameObject clickedObject)
    {
        // Si on clique sur rien, désélectionne le villageois actuel
        if (clickedObject == null)
        {
            DeselectCurrentVillager();
            _schoolMenu.SetActive(false);
            return;
        }

        // Récupère le script graphique du villageois cliqué
        VillagersGraphics graphics = clickedObject.GetComponentInParent<VillagersGraphics>();

        if (graphics != null)
        {
            // Si on clique sur un villageois différent du précédent
            if (_graphicsSelected != null && _graphicsSelected != graphics)
            {
                _graphicsSelected.DisactiveOutline();
                _graphicsSelected.IsSelected = false;
            }

            // Toggle la sélection
            if (!graphics.IsSelected)
            {
                _schoolMenu.SetActive(true);
                graphics.ActiveOutline();
                graphics.IsSelected = true;
                _graphicsSelected = graphics;
            }
            else
            {
                graphics.DisactiveOutline();
                graphics.IsSelected = false;
                _graphicsSelected = null;
                _schoolMenu.SetActive(false);
            }
        }
        else
        {
            // Si on clique sur autre chose que villageois, désélectionne le précédent
            DeselectCurrentVillager();
            _schoolMenu.SetActive(false);
        }
    }

    private void DeselectCurrentVillager()
    {
        if (_graphicsSelected != null)
        {
            _graphicsSelected.DisactiveOutline();
            _graphicsSelected.IsSelected = false;
            _graphicsSelected = null;
        }
    }
}


