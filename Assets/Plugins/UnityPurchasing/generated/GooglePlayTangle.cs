#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("5JoT0MaxezspezeYNG6WTwatbXFd3tDf713e1d1d3t7fUKlTfzuXUNl7W6LmaRZ01DBzQun/z42DVtqlZL0SBnD/TWrlII/L8ZLbhr6sidZWulEEL5qcktDpi9ghZ/e0Hsom01Vv8rmBqVeO64aq4EVTX3q0aX8MWAXQfTHZSPWA5ZB4nVz4GHvZcbiA4woTzvPcMx+HgxK9pZvoK4hfoJ3ZppGTli0jbE1B4Hx79ux5aZ5jRvAb2dTVQl/mhwaHlBjm59DisSLvXd7979LZ1vVZl1ko0t7e3trf3D3IY90YS9dJ5mwQyghA1I55FQ7zJVNf+L3UkJJtdiwioaJb5VlSVtqi0IVmssjvSa0BWjtEYFnU6i3zXRjhcVhVPxu2tN3c3t/e");
        private static int[] order = new int[] { 3,1,5,10,12,13,11,13,8,12,10,12,13,13,14 };
        private static int key = 223;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
