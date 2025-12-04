using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    [SerializeField] private Transform sourcePos;
    [SerializeField] private Transform targetPos;

    private void Update()
    {
        transform.position+= (targetPos.position - transform.position).normalized * Time.deltaTime;
        if(transform.position==targetPos.position)
            transform.position=sourcePos.position;
    }
}
