using System;
using System.Runtime.InteropServices;

namespace RubyNET
{
    internal static class NativeLoader
    {
        private static readonly PlatformID Platform = Environment.OSVersion.Platform;
        
        public static IntPtr Load(string filename)
        {
            if (Platform == PlatformID.Unix)
                return dlopen($"lib{filename}.so", RTLD_NOW);
            if (Platform == PlatformID.Win32NT)
                return LoadLibrary($"{filename}.dll");
            throw new NotSupportedException("Unsupported operating system.");
        }

        public static IntPtr GetProcAddress(string procName, IntPtr module)
        {
            if (Platform == PlatformID.Unix)
                return dlsym(module, procName);
            return Platform == PlatformID.Win32NT ? GetProcAddress(module, procName) : IntPtr.Zero;
        }

        public static void Free(IntPtr module)
        {
            if (Platform == PlatformID.Unix)
                dlclose(module);
            if (Platform == PlatformID.Win32NT)
                FreeLibrary(module);
        }

        private const int RTLD_NOW = 0x002;
        
        [DllImport("kernel32")]
        private static extern IntPtr LoadLibrary(string fileName);

        [DllImport("kernel32")]
        private static extern IntPtr GetProcAddress(IntPtr module, string procName);

        [DllImport("kernel32")]
        private static extern int FreeLibrary(IntPtr module);

        [DllImport("libdl")]
        private static extern IntPtr dlopen(string fileName, int flags);

        [DllImport("libdl")]
        private static extern IntPtr dlsym(IntPtr handle, string name);

        [DllImport("libdl")]
        private static extern int dlclose(IntPtr handle);
    }
}