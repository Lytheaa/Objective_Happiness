using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _schoolMenu;

    private VillagersGraphics _graphicsSelected; // le villageois actuellement sélectionné

    private Villager _villagerSelected;


    private void Awake()
    {
        _schoolMenu.SetActive(false);
    }

    private void OnEnable()
    {
        MouseManager.OnObjectClicked += ReturnVillagerSelected;
        //MouseManager.OnObjectClicked += SelectVillager;
    }
    private void OnDisable()
    {
        MouseManager.OnObjectClicked -= ReturnVillagerSelected;
        //MouseManager.OnObjectClicked -= SelectVillager;

    }

    ///TEST METHODE RETOURNE VILLAGER SCRIPT 

    //private void SelectVillager(GameObject clickedObject)
    //{
    //    Villager villager = clickedObject.GetComponentInParent<Villager>();

    //    // Si on clique sur rien, désélectionne le villageois actuel
    //    //if (clickedObject == null)
    //    //{
    //    //    DeselectCurrentVillager();
    //    //    _schoolMenu.SetActive(false);
    //    //    return;
    //    //}

    //    if (villager != null)
    //    {
    //        Debug.Log("villager retourné");
    //        _villagerSelected = villager;
    //        //BOOL sur villager Data ? Is Selected? 

    //    }
    //    else
    //    {
    //        Debug.Log("Impossible de récupérer le villageois");
    //        _villagerSelected = null;
    //        ////DeselectCurrentVillager();
    //        //_schoolMenu.SetActive(false);
    //        //_villagerSelected = null;
    //    }
    //}

    ///METHODE TEST : NE FONCTIONNE PAS 

    private void ReturnVillagerSelected(GameObject clickedObject)
    {
        Villager villager = clickedObject.GetComponentInParent<Villager>();

        // Si on clique sur rien, désélectionne le villageois actuel
        if (clickedObject == null)
        {
            DeselectCurrentVillager();
            _schoolMenu.SetActive(false);
            return;
        }

        if (villager != null)
        {

            _villagerSelected = villager;

            Debug.Log("villager retourné");
            //_villagerSelected.Graphics.IsSelected = true;

            if (_villagerSelected != null && _villagerSelected != villager)
            {
                _villagerSelected.Graphics.DisactiveOutline();
                _villagerSelected.Graphics.IsSelected = false;
            }

            if (!_villagerSelected.Graphics.IsSelected)
            {
                _schoolMenu.SetActive(true);
                _villagerSelected.Graphics.ActiveOutline();
                _villagerSelected.Graphics.IsSelected = true;
                _graphicsSelected = _villagerSelected.Graphics;
            }
            else
            {
                _villagerSelected.Graphics.DisactiveOutline();
                _villagerSelected.Graphics.IsSelected = false;
                _graphicsSelected = null;
                _schoolMenu.SetActive(false);
            }
        }
        else
        {
            //DeselectCurrentVillager();
            _schoolMenu.SetActive(false);
            Debug.Log("Impossible de récupérer le villageois");
            _villagerSelected = null;
        }
    }

    /// METHODE GRAPHICS INITIALE : FONCTIONNE 

    //private void GraphicsSelectVillager(GameObject clickedObject)
    //{
    //    // Si on clique sur rien, désélectionne le villageois actuel
    //    if (clickedObject == null)
    //    {
    //        DeselectCurrentVillager();
    //        _schoolMenu.SetActive(false);
    //        return;
    //    }

    //    // Récupère le script graphique du villageois cliqué
    //    VillagersGraphics graphics = clickedObject.GetComponentInParent<VillagersGraphics>();

    //    if (graphics != null)
    //    {
    //        // Si on clique sur un villageois différent du précédent
    //        if (_graphicsSelected != null && _graphicsSelected != graphics)
    //        {
    //            _graphicsSelected.DisactiveOutline();
    //            _graphicsSelected.IsSelected = false;
    //        }

    //        // Toggle la sélection
    //        if (!graphics.IsSelected)
    //        {
    //            _schoolMenu.SetActive(true);
    //            graphics.ActiveOutline();
    //            graphics.IsSelected = true;
    //            _graphicsSelected = graphics;
    //        }
    //        else
    //        {
    //            graphics.DisactiveOutline();
    //            graphics.IsSelected = false;
    //            _graphicsSelected = null;
    //            _schoolMenu.SetActive(false);
    //        }
    //    }
    //    else
    //    {
    //        // Si on clique sur autre chose que villageois, désélectionne le précédent
    //        DeselectCurrentVillager();
    //        _schoolMenu.SetActive(false);
    //    }
    //}

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


