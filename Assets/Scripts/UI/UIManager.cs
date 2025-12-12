using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; } // Singleton

    [SerializeField] private GameObject _schoolMenu;

    private Villager _villagerSelected; // le villageois actuellement sélectionné

    private void Awake()
    {
        _schoolMenu.SetActive(false);
    }

    private void OnEnable()
    {
        MouseManager.OnObjectClicked += ReturnVillagerSelected;
    }
    private void OnDisable()
    {
        MouseManager.OnObjectClicked -= ReturnVillagerSelected;
    }

    private void ReturnVillagerSelected(GameObject clickedObject)
    {
        Villager villager = clickedObject.GetComponentInParent<Villager>();

        if (clickedObject == null)
        {
            DeselectCurrentVillager();
            _schoolMenu.SetActive(false);
            return;
        }

        if (villager != null)
        {
            // Si on clique sur un villageois différent du précédent
            if (_villagerSelected != null && _villagerSelected != villager) 
            {
                _villagerSelected.Graphics.IsSelected = false;
                _villagerSelected.Graphics.DisactiveOutline();
            }

            if (!villager.Graphics.IsSelected)
            {
                _schoolMenu.SetActive(true);
                villager.Graphics.ActiveOutline();
                villager.Graphics.IsSelected = true;

                _villagerSelected = villager;
            }
            else
            {
                villager.Graphics.DisactiveOutline();
                villager.Graphics.IsSelected = false;
                _villagerSelected = null;
                _schoolMenu.SetActive(false);
            }
        }
        else
        {
            DeselectCurrentVillager();
            _villagerSelected = null;

            _schoolMenu.SetActive(false);
            Debug.Log("Impossible de récupérer le villageois");
        }
    }

    private void DeselectCurrentVillager()
    {
        if (_villagerSelected != null)
        {
            _villagerSelected.Graphics.DisactiveOutline();
            _villagerSelected.Graphics.IsSelected = false;
            _villagerSelected = null;
        }
    }

}