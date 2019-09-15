using UnityEngine;

namespace util {
    public static class Log {
        private const string Tag = "TankBattleCity";

        public static void D(string tag, string msg) {
            Debug.Log(Tag + " - " + tag + ": " + msg);
        }
    }
}