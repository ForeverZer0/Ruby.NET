using System;
using System.Runtime.InteropServices;

namespace RubyNET
{

    [StructLayout(LayoutKind.Sequential)]
    public struct RData
    {
        public readonly RBasic basic;

        public RubyDataFunc dmark;

        public RubyDataFunc dfree;

        public unsafe void* data;
    }
}