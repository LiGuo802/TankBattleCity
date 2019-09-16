using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Invoke($"ExplodeEnd", 0.167f);
    }

    private void ExplodeEnd() {
        Destroy(gameObject);
    }

}