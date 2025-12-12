using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolToggleBehaviour : MonoBehaviour
{
    private Toggle _toggle;

    private UIManager _uIManager;

    //private int _workId; 

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        _uIManager = UIManager.Instance; /// Impossible de le récupérer dans l'Awake, pb d'ordre d'exécution des scripts /!\
    }

    private void Update()
    {

    }

    public void ChangeJob(int workIndex)
    {
        if (_toggle.isOn)
        {
            //Villager villager = _uIManager.VillagerSelected;
            //villager.Data.WantToGoSchool = true;

            _uIManager.VillagerSelected.Data.WantToGoSchool = true;


            //villager.Work.SetWork(workIndex);
        }
    }
}
