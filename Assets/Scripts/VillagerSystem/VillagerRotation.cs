using UnityEngine;

public class VillagerRotation : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main; 
    }

    void LateUpdate()
    {
        Vector3 lookPosition = mainCamera.transform.position - transform.position;
        lookPosition.y = 0; 

        if (lookPosition != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookPosition);
    }
}