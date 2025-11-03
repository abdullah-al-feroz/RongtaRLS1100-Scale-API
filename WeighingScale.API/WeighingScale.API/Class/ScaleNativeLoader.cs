using System.Runtime.InteropServices;

namespace WeighingScale.API.Class
{
    public static class ScaleNativeLoader
    {
        private static bool _loaded = false;

        public static void EnsureLoaded()
        {
            if (_loaded) return;

            string arch = Environment.Is64BitProcess ? "x64" : "x86";
            string dllPath = Path.Combine(AppContext.BaseDirectory, arch, "rtslabelscale.dll");

            if (!File.Exists(dllPath))
            {
                throw new FileNotFoundException($"Scale DLL not found: {dllPath}");
            }

            IntPtr handle = NativeLibrary.Load(dllPath);
            if (handle == IntPtr.Zero)
            {
                throw new DllNotFoundException($"Failed to load {dllPath}");
            }

            _loaded = true;
        }
    }
}
