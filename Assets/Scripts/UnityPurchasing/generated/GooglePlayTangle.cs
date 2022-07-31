// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("f0LZtW9j8tmN+/4CSBDyj3qgcH1DPvRw+qHZ/s8c5Tm/wnreDApTiyo/2XMsWepqMJyicz3DMSa4Vp0/mc5x1ngRxijVyl9nASjOJsfoe96HkwXkv682mXMZlnzL7t9g3JAU02Nd/0OSN0qefB80BeyuEp5qjNvsJDuN3yKaKOyWPglw4ZgHihoZrKatg5UM5zXRxTFAYwnAxPWGDNYBpmLh7+DQYuHq4mLh4eBBbz3ebOlQTOsxJfkdULMpfJ3uNThd/NF8o9kgJDdeR9PEQteG6j6zHc0VLB8uLfdRRV93FPqP0EPyIvl/3BNALBAm0GLhwtDt5unKZqhmF+3h4eHl4OMixtCQIXR6QtfaO2dYn/POn6TstUt0d59/WejrkeLj4eDh");
        private static int[] order = new int[] { 6,5,4,12,10,10,7,13,10,10,12,11,13,13,14 };
        private static int key = 224;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
