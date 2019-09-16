using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using util;

public class Bullet : MonoBehaviour {
    private float _speed = 1f;
    private bool _canBreakBarrier = false;

    private void Update() {
        transform.Translate(_speed * Time.deltaTime * transform.up, Space.World);
    }

    private void UpdateBulletParams(int level) {
        _speed = Constant.BulletSpeed[level - 1];
        _canBreakBarrier = Constant.CanBulletBreakBarrier[level - 1];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case Tag.AirBarrier:
                Destroy(gameObject);
                break;
            case Tag.Wall:
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            case Tag.Barrier:
                if (_canBreakBarrier) {
                    Destroy(other.gameObject);
                }
                Destroy(gameObject);
                break;
            case Tag.Heart:
                Destroy(gameObject);
                other.gameObject.SendMessage("BeAttacked");
                break;
        }
    }
}