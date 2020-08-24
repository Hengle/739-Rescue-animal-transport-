#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("odfbfDlQFBbp8qimJSbfYd3W0l7gOZaC9HvJ7mGkC091Fl8COigNUl3/3yZi7ZLwULT3xm17SwkH0l4hJlQB4jZMa80phd6/wOTdUG6pd9nZWlRba9laUVnZWlpb1C3X+78T1LlM51mcz1PNYuiUTozEUAr9kYp3YB6XVEI1/7+t/7McsOoSy4Ip6fUEZ46XSndYt5sDB5Y5IR9srwzbJNyBVPm1XcxxBGEU/BnYfJz/XfU80et2PQUt0wpvAi5kwdfb/jDt+4jSPtWAqx4YFlRtD1yl43Mwmk6iV2vZWnlrVl1Scd0T3axWWlpaXltYwnSfXVBRxttiA4IDEJxiY1RmNaYZXSIVFxKpp+jJxWT4/3Jo/e0a55xl9dzRu58yMFlYWlta");
        private static int[] order = new int[] { 7,10,5,6,10,9,6,9,11,13,12,13,12,13,14 };
        private static int key = 91;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
