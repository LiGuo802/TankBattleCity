using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    public GameObject ExplodeEffectPrefab;
    public Sprite DeadHeart;

    private SpriteRenderer _renderer;

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void BeAttacked() {
        Instantiate(ExplodeEffectPrefab, transform.position, Quaternion.identity);
        _renderer.sprite = DeadHeart;
    }
}