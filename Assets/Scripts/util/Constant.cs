namespace util {
    public static class Constant {
        // -------------------------------------------------------------------------------------
        //                                    玩家数值定义
        // -------------------------------------------------------------------------------------
        // [数值]玩家移动速度
        public static readonly float[] TankSpeed = new[] {3f, 3.5f, 4f, 4.5f};

        // [数值]玩家攻击CD
        public static readonly float[] AttackCd = new[] {0.4f, 0.3f, 0.3f, 0.3f};

        // [数值]玩家子弹速度
        public static readonly float[] BulletSpeed = new[] {5f, 5f, 6f, 6f};

        // [数值]玩家子弹能力
        public static readonly bool[] CanBulletBreakBarrier = new[] {false, false, false, true};

        // -------------------------------------------------------------------------------------
        //                                    敌机数值定义
        // -------------------------------------------------------------------------------------
        // 敌人种类数量
        public const int EnemyTypeCount = 5;

        // 敌人类型定义
        public const int EnemyNormal = 0; // 普通
        public const int EnemyQuick = 1; // 高移速
        public const int EnemyArmorL1 = 2; // 白色装甲
        public const int EnemyArmorL2 = 3; // 黄色装甲
        public const int EnemyArmorL3 = 4; // 绿色装甲
        public const int EnemyNormalRed = EnemyTypeCount + EnemyNormal;
        public const int EnemyQuickRed = EnemyTypeCount + EnemyQuick;
        public const int EnemyArmorL1Red = EnemyTypeCount + EnemyArmorL1;
        public const int EnemyArmorL2Red = EnemyTypeCount + EnemyArmorL2;
        public const int EnemyArmorL3Red = EnemyTypeCount + EnemyArmorL3;

        // [数值]玩家移动速度
        public static readonly float[] EnemyTankSpeed = new[] {3f, 3.5f, 4.5f, 4.5f, 4.5f};

        // [数值]玩家攻击CD
        public static readonly float[] EnemyAttackCd = new[] {0.4f, 0.3f, 0.3f, 0.3f, 0.3f};

        // [数值]玩家子弹速度
        public static readonly float[] EnemyBulletSpeed = new[] {5f, 5f, 6f, 6f, 6f};
    }
}