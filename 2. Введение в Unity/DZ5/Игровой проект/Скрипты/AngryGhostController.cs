using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryGhostController : GhostController
{
    public string targetTag;
    public float speedInAngryMode;
    public GameObject bulletObject;
    public GameObject bulletSpawnPoint;
    public float shootCoolDown;
    public float maxDistanceToTarget;
    public float stopFollowWaitingTime;
    public AudioClip audioAfterFound;

    private GameObject _target;
    private Vector3 _baseEndPoint;
    private float _baseSpeed;
    private float _shootCoolDownTimer = 0f;
    private float _stopFollowWaitingTimer;
    private bool _foundTarget = false;

    protected new void Start()
    {
        base.Start();
        _baseSpeed = speed;
    }

    protected new void Update()
    {
        if (!_foundTarget)
        {
            if (_stopFollowWaitingTimer <= 0)
            {
                base.Update();
            } else
            {
                _stopFollowWaitingTimer -= Time.deltaTime;
            }
        } else
        {
            GoToTarget();
            print((gameObject.transform.position - _target.transform.position).sqrMagnitude);
            if (maxDistanceToTarget * maxDistanceToTarget < (gameObject.transform.position - _target.transform.position).sqrMagnitude)
            {
                print("STOP");
                StopFollowTarget();
            }
        }
    }

    protected void GoToTarget()
    {
        SetWayToTarget(_target.transform.position);
        base.Update();
        if (_shootCoolDownTimer <= 0)
        {
            Shoot();
            _shootCoolDownTimer = shootCoolDown;
        }
        else
        {
            _shootCoolDownTimer -= Time.deltaTime;
        }
    }

    protected void StopFollowTarget()
    {
        SetWay(_baseEndPoint);
        _stopFollowWaitingTimer = stopFollowWaitingTime;
        speed = _baseSpeed;
        _foundTarget = false;
    }

    public new void SetWay(Vector3 endPoint)
    {
        base.SetWay(endPoint);
        _baseEndPoint = endPoint;
    }

    public void SetWayToTarget(Vector3 endPoint)
    {
        base.SetWay(endPoint);
    }

    protected void OnTriggerEnter(Collider collider)
    {
        if (!_foundTarget && collider.gameObject.CompareTag(targetTag))
        {
            _target = collider.gameObject;
            _foundTarget = true;
            _audioSource.PlayOneShot(audioAfterFound);
            speed = speedInAngryMode;
        }
    }

    protected void Shoot()
    {
        GameObject newBullet = Instantiate(bulletObject, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        newBullet.SendMessage("SetWay", _target.transform.position);
    }
}
