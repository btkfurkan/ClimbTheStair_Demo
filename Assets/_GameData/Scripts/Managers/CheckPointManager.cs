using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject ObjectToAddOnTop; 
    private float _yPosition = 0.072f;
    private int _createCount = 80;
    private float _offsetFromTop = 0.3f;

    void Start()
    {
        Transform parentTransform = transform;

        
        Vector3 topObjectPosition = new Vector3(parentTransform.position.x, parentTransform.position.y + (_createCount - 1) * 0.128f + _offsetFromTop, parentTransform.position.z);

        
        GameObject objectToAdd = Instantiate(ObjectToAddOnTop, topObjectPosition, Quaternion.identity);

       
        objectToAdd.transform.SetParent(parentTransform);

        for (int i = 0; i < _createCount; i++)
        {
            Vector3 spawnPosition = new Vector3(parentTransform.position.x, _yPosition, parentTransform.position.z);
            GameObject newObject = Instantiate(Prefab, spawnPosition, Quaternion.identity);
            newObject.transform.SetParent(parentTransform);
            _yPosition += 0.128f;
        }
    }
}
