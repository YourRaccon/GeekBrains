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
    public AudioClip audioAfterFound;

    private GameObject _target;
    private float _shootCoolDownTimer = 0f;
    private bool _foundTarget = false;

    protected new void Update()
    {
        if (!_foundTarget)
        {
            base.Update();
        } else
        {
            SetWay(_target.transform.position);
            base.Update();
            if (_shootCoolDownTimer <= 0)
            {
                Shoot();
                _shootCoolDownTimer = shootCoolDown;
            } else
            {
                _shootCoolDownTimer -= Time.deltaTime;
            }
        }
    }

    protected void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(targetTag))
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
