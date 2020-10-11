using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MyFirstObjectSpawner : MonoBehaviour
{
    #region Fields

    public List<GameObject> spawnObjects;
    public Text counterText;
    public float spawnRadius = 10f;
    public float maxSpawnFrequency = 8f;
    public float minSpawnFrequency = 3f;
    public float chanceOfUnusualSpawn = 0.1f;
    public int spawnObjectCount = 10;

    private GameManager _gameManager;
    private float spawnTimer;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _gameManager = GameManager.GetGameManager();
        counterText.text = spawnObjectCount + " LEFT";
    }

    private void Update()
    {
        if (spawnObjectCount <= 0)
        {
            counterText.gameObject.SetActive(false);
            _gameManager.OpenMainDoor();
            Destroy(gameObject, 0f);
        }
        SpawnObject();
    }

    #endregion


    #region Methods

    private void SpawnObject()
    {
        if (spawnTimer <= 0)
        {
            Vector2 randomStartPoint = GetRandomPointOnCircle();
            Vector2 randomEndPoint = GetRandomPointOnCircle();
            Vector3 randomStartPosition = new Vector3(gameObject.transform.position.x + randomStartPoint.x, gameObject.transform.position.y, gameObject.transform.position.z + randomStartPoint.y);
            Vector3 randomEndPosition = new Vector3(gameObject.transform.position.x + randomEndPoint.x, gameObject.transform.position.y, gameObject.transform.position.z + randomEndPoint.y);

            GameObject newSpawnObject = GetRandomGameObjectFromList();

            GameObject newObject = Instantiate(newSpawnObject, randomStartPosition, gameObject.transform.rotation);
            newObject.SendMessage("SetWay", randomEndPosition);
            newObject.SendMessage("SetSpawner", gameObject);

            spawnTimer = Random.Range(minSpawnFrequency, maxSpawnFrequency);
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    private Vector2 GetRandomPointOnCircle()
    {
        float randAng = Random.Range(0, Mathf.PI * 2);
        return new Vector2(Mathf.Cos(randAng) * spawnRadius, Mathf.Sin(randAng) * spawnRadius);
    }

    private GameObject GetRandomGameObjectFromList()
    {
        GameObject newSpawnObject = null;
        foreach (GameObject spawnObject in spawnObjects)
        {
            float randomChance = Random.Range(0f, 1f);
            if (randomChance <= chanceOfUnusualSpawn)
            {
                newSpawnObject = spawnObject;
                break;
            }
        }
        if (newSpawnObject == null)
        {
            newSpawnObject = spawnObjects[0];
        }
        return newSpawnObject;
    }

    public void OnObjectDie()
    {
        spawnObjectCount--;
        counterText.text = spawnObjectCount + " LEFT";
    }

    #endregion
}
