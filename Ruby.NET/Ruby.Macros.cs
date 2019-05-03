using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace RubyNET
{
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public static unsafe partial class API
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* ALLOC<T>() where T : struct => ruby_xmalloc(Marshal.SizeOf<T>());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* ALLOC(Type type) => ruby_xmalloc(Marshal.SizeOf(type));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RTEST(VALUE value) => value != Qfalse && value != Qnil;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VALUE STR2SYM(string value) => rb_id2sym(rb_intern(value));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IMMEDITATE_P(VALUE obj) => ((ulong) obj & RUBY_IMMEDIATE_MASK) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool FIXNUM_P(VALUE obj) => ((ulong) obj & RUBY_FIXNUM_FLAG) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool FLONUM_P(VALUE obj) => ((ulong) obj & RUBY_FLONUM_MASK) == RUBY_FLONUM_FLAG;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SYMBOL_P(VALUE obj) => ((ulong) obj & (ulong) ~(~0 << RUBY_SPECIAL_SHIFT)) == RUBY_SYMBOL_FLAG;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VALUE CLASS_OF(VALUE obj) => rb_obj_class(obj);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string StringValueCStr(VALUE str) => Util.PtrToStringUTF8(rb_string_value_cstr(&str));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VALUE Data_Wrap_Struct(VALUE klass, RubyDataFunc dmark, RubyDataFunc dfree, void* sval)
        {
            return rb_data_object_wrap(klass, sval, dmark, dfree);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VALUE Data_Wrap_Struct(VALUE klass, void* sval) =>
            rb_data_object_wrap(klass, sval, NULL, RUBY_DEFAULT_FREE);
        
        // TODO: Other variations of Data_Wrap_Struct
    }
}