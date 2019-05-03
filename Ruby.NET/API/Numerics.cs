using System.Runtime.InteropServices;

namespace RubyNET
{
    public static unsafe partial class API
    { 
        //        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        //        public static extern VALUE rb_int2big();
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_int2inum(int v);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_float_new(double value);
    }
}