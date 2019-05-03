using System.Runtime.InteropServices;

namespace RubyNET
{
    public static partial class API
    {
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_obj_freeze(VALUE obj);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_obj_frozen_p(VALUE obj);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_obj_class(VALUE obj);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_obj_equal(VALUE obj1, VALUE obj2);
    }
}