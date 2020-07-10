#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("LcZXE6mheQr5Eu6blbBlIEHVAdZTCktZWV9HT1kKS0lJT1peS0RJT5sacsZwLhimQpmlN/RPWdVNdE+WLyopqCslKhqoKyAoqCsrKs67gyMXDE0KoBlA3Seo5fTBiQXTeUBxTl5DTENJS15PCkhTCktEUwpaS1heCkVMCl5CTwpeQk9ECktaWkZDSUsfGBseGhkccD0nGR8aGBoTGBseGm9UNWZBerxro+5eSCE6qWutGaCrNbvxNG16wS/HdFOuB8EciH1mf8ZGTwpjREkEGwwaDiwpfy4hOTdrWgUaq+ksIgEsKy8vLSgoGqucMKuZLiw5KH95GzkaOywpfy4gOSBrWlqC9lQIH+AP//Ml/EH+iA4JO92LhvMcVeutf/ONs5MYaNHy/1u0VIt4XV0ES1paRk8ESUVHBUtaWkZPSUtzjS8jVj1qfDs0XvmdoQkRbYn/RZ8Qh94lJCq4IZsLPARe/xYn8Ug8AKxirN0nKysvLyoaSBshGiMsKX9aRk8KeEVFXgppaxo0PScaHBoeGByzZgdSncemsfbZXbHYXPhdGmXreE9GQ0tESU8KRUQKXkJDWQpJT1gsKX83JC48Lj4B+kNtvlwj1N5Bp6o+AfpDbb5cI9TeQacEaozdbWdVpVmrSuwxcSMFuJjSbmLaShK0P99IRk8KWV5LRE5LWE4KXk9YR1kKS2PyXLUZPk+LXb7jBygpKyoriagroTOj9NNhRt8tgQgaKMIyFNJ6I/mBiVu4bXl/64UFa5nS0cla58yJZgpLRE4KSU9YXkNMQ0lLXkNFRApa6kkZXd0QLQZ8wfAlCyTwkFkzZZ8sGiUsKX83OSsr1S4vGikrK9UaN1pGTwppT1heQ0xDSUteQ0VECmtfGRxwGkgbIRojLCl/Liw5KH95GzlETgpJRUROQ15DRURZCkVMCl9ZT7+0UCaObaFx/jwdGeHuJWfkPkP74zNY33ck/1V1sdgPKZB/pWd3J9snLCMArGKs3ScrKy8vKimoKysqdiW3F9kBYwIw4tTkn5Mk83Q2/OEXTh8JP2E/czeZvt3ctrTlepDrcnoiASwrLy8tKCs8NEJeXlpZEAUFXUNMQ0lLXkNFRAprX15CRVhDXlMbGjssKX8uIDkga1paRk8KY0RJBBtQGqgrXBokLCl/NyUrK9UuLikoK6grKiwjAKxirN1JTi8rGqvYGgAsnTGXuWgOOADtJTecZ7Z0SeJhqj1NpSKeCt3hhgYKRVqcFSsapp1p5ZTeWbHE+E4l4VNlHvKIFNNS1UHiXkJFWENeUxs8Gj4sKX8uKTkna1oaqC6RGqgpiYopKCsoKCsoGicsIwYKSU9YXkNMQ0lLXk8KWkVGQ0lTWEtJXkNJTwpZXkteT0dPRF5ZBBoidBqoKzssKX83Ci6oKyIaqCsuGlVrgrLT++BMtg5BO/qJkc4xAOk1DsjB+51a9SVvyw3g20dSx82fPT0KaWsaqCsIGicsIwCsYqzdJysrKzWvqa8xsxdtHdiDsWqkBv6bujjyPBo+LCl/Lik5J2taWkZPCnhFRV4MGg4sKX8uITk3a1paRk8KaU9YXgRqjN1tZ1UidBo1LCl/NwkuMho8eoCg//DO1vojLR2aX18L");
        private static int[] order = new int[] { 51,40,26,14,56,39,41,7,25,15,14,37,26,54,58,36,52,23,40,41,48,38,30,32,55,42,27,52,55,45,57,45,56,42,43,40,41,47,57,48,40,47,47,55,55,59,57,50,48,51,55,57,55,56,56,56,57,57,58,59,60 };
        private static int key = 42;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
