using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeOfLife;

    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private GameManager _gameManager;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _gameManager = GameManager.GetGameManager();
        Destroy(gameObject, timeOfLife);
    }

    private void Update()
    {
        if (_direction != null)
        {
            _rigidbody.MovePosition(gameObject.transform.position + _direction * speed * Time.deltaTime);
        }
    }

    public void SetWay(Vector3 endPoint)
    {
        Vector3 startPoint = gameObject.transform.position;
        _direction = endPoint - startPoint;
        _direction.Normalize();
        gameObject.transform.LookAt(endPoint);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.LoseGame();
            Destroy(gameObject, 0f);
        }
    }
}
