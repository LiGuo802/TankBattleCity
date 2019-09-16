using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {
    
    private bool IsPlayer;

    public GameObject PlayerPrefab;

    // Start is called before the first frame update
    void Start() {
        Invoke($"BornTank", 0.333f);
    }

    private void BornTank() {
        Instantiate(PlayerPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}