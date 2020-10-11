using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public GameObject generateObject;
    public float generatorRadius;
    public int generateObjectCount;

    private List<GameObject> _generatedObjects;
    private Coroutine _generator;
    private Coroutine _objectsRounder;
    private int _generatedObjectsCount;

    private void Start()
    {
        _generatedObjects = new List<GameObject>();
        _generatedObjectsCount = 0;
    }

    private void Update()
    {
        if(_generatedObjectsCount < generateObjectCount && _generator == null)
        {
            _generator = StartCoroutine(nameof(GenerateObject));
        }

        if (_objectsRounder == null)
        {
            _objectsRounder = StartCoroutine(nameof(RoundGeneratedObjects));
        }
    }

    private IEnumerator GenerateObject()
    {
        GameObject obj = Instantiate(generateObject, gameObject.transform.position + Random.insideUnitSphere * generatorRadius, gameObject.transform.rotation);
        _generatedObjects.Add(obj);
        _generatedObjectsCount++;
        yield return new WaitForFixedUpdate();
        _generator = null;
    }

    private IEnumerator RoundGeneratedObjects()
    {
        for(int i = 0; i < _generatedObjects.Count; i++)
        {
            _generatedObjects[i].transform.RotateAround(_generatedObjects[i].transform.position, _generatedObjects[i].transform.up, 1.0f);
        }
        yield return new WaitForFixedUpdate();
        _objectsRounder = null;
    }
}
