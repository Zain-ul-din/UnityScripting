using System.Collections;
using System.Collections.Generic;
using Randoms.GridSystem;
using UnityEngine;

public class GridSystemTesting : MonoBehaviour {
    private void Awake () {
        GridSystem gridSystem = new GridSystem( 10, 10, 2f);
    }
}
