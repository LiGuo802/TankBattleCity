namespace util {
    public static class Utils {
        public const double Tolerance = 1E-06;

        public static int GetSafeLevel(int level) {
            if (level > 4) {
                return 4;
            }

            if (level < 1) {
                return 1;
            }

            return level;
        }
    }
}