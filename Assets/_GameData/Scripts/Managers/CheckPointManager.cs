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

        GameObject objectToAdd = CreateObjectOnTop(parentTransform);
        objectToAdd.transform.SetParent(parentTransform);

        CreateObjectsInSequence(parentTransform);
    }

    private GameObject CreateObjectOnTop(Transform parentTransform)
    {
        Vector3 topObjectPosition = new Vector3(parentTransform.position.x, parentTransform.position.y + (_createCount - 1) * 0.128f + _offsetFromTop, parentTransform.position.z);
        return Instantiate(ObjectToAddOnTop, topObjectPosition, Quaternion.identity);
    }

    private void CreateObjectsInSequence(Transform parentTransform)
    {
        for (int i = 0; i < _createCount; i++)
        {
            Vector3 spawnPosition = new Vector3(parentTransform.position.x, _yPosition, parentTransform.position.z);
            GameObject newObject = Instantiate(Prefab, spawnPosition, Quaternion.identity);
            newObject.transform.SetParent(parentTransform);
            _yPosition += 0.1285f;
        }
    }
}
