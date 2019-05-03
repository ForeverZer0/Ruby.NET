using System.Runtime.InteropServices;

namespace RubyNET
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RBasic
    {
        public VALUE flags;
        public readonly VALUE klass;
    }
}