using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using util;

public class EnemyArmorL1 : Enemy {
    protected override int GetType() {
        return Constant.EnemyArmorL1;
    }

    protected override bool isRed() {
        return false;
    }
}