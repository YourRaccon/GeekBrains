using UnityEngine;
using UnityEngine.UI;

public class MyFirstObjectSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float spawnRadius = 10f;
    public int spawnObjectCount = 10;
    public float maxSpawnFrequency = 8f;
    public float minSpawnFrequency = 3f;

    public Text counterText;

    private GameManager _gameManager;
    private float spawnTimer;

    private void Start()
    {
        _gameManager = GameManager.GetGameManager();
        spawnTimer = 0;
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
        if (spawnTimer <= 0)
        {
            SpawnObject();
            spawnTimer = Random.Range(3f, 8f);
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    private void SpawnObject()
    {
        Vector2 randomStartPoint = randomPointOnCircle();
        Vector2 randomEndPoint = randomPointOnCircle();
        GameObject newObject = Instantiate(spawnObject, new Vector3(gameObject.transform.position.x + randomStartPoint.x, gameObject.transform.position.y, gameObject.transform.position.z + randomStartPoint.y), gameObject.transform.rotation);
        newObject.SendMessage("SetWay", new Vector3(gameObject.transform.position.x + randomEndPoint.x, gameObject.transform.position.y, gameObject.transform.position.z + randomEndPoint.y));
        newObject.SendMessage("SetSpawner", gameObject);
    }

    private Vector2 randomPointOnCircle()
    {
        float randAng = Random.Range(0, Mathf.PI * 2);
        return new Vector2(Mathf.Cos(randAng) * spawnRadius, Mathf.Sin(randAng) * spawnRadius);
    }

    public void OnObjectDie()
    {
        spawnObjectCount--;
        counterText.text = spawnObjectCount + " LEFT";
    }
}
