namespace deepdiver.Lib {
    public static class EnumLib {
        public static List<String> GetKeys<T>() where T : Enum {
            return Enum.GetNames(typeof(T)).ToList<String>();
        }
    }
}