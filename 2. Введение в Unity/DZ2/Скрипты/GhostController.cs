using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float speed;

    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private GameObject _spawner;
    private GameManager _gameManager;
    private bool _isDead;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _gameManager = GameManager.GetGameManager();
    }

    private void Update()
    {
        if (!_isDead && _startPoint != null && _endPoint != null)
        {
            if ((_startPoint - _endPoint).sqrMagnitude > (_startPoint - gameObject.transform.position).sqrMagnitude)
            {
                _rigidbody.MovePosition(gameObject.transform.position + _direction * speed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject, 0.0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.LoseGame();
        }
    }

    public void SetWay(Vector3 endPoint)
    {
        _startPoint = gameObject.transform.position;
        _endPoint = endPoint;
        _direction = _endPoint - _startPoint;
        _direction.Normalize();
        gameObject.transform.LookAt(_endPoint);
    }

    public void SetSpawner(GameObject spawner)
    {
        _spawner = spawner;
    }

    public void Die()
    {
        _spawner.SendMessage("OnObjectDie");
        _isDead = true;
        Destroy(gameObject, 5.0f);
    }
}
