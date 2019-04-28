namespace Problems {

    public static class Extentions {
        public static int IndexOf(this string[] array, string item ) {
            for( int i = 0; i < array.Length; i++) {
                if (array[i] == item)
                    return i;
            }
            return -1;
        }
    }
}