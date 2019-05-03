using System.Runtime.InteropServices;
using System.Security;

namespace RubyNET
{
    [SuppressUnmanagedCodeSecurity]
    public static unsafe partial class API
    {
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_aref(int argc, VALUE *argv, VALUE ary);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_aref1(VALUE ary, VALUE index);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_new();
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_ary_new_capa(int capacity);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_ary_new_from_values(int length, VALUE* args);

        public static VALUE rb_ary_new(int capacity) => rb_ary_new_capa(capacity);
        
        public static VALUE rb_ary_new(params VALUE[] args)
        {
            fixed (VALUE* values = &args[0])
            {
                return rb_ary_new_from_values(args.Length, values);
            }
        }

        public static VALUE rb_ary_new(int argc, VALUE* argv) => rb_ary_new_from_values(argc, argv);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rb_ary_store(VALUE ary, int index, VALUE value);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_subseq(VALUE ary, int start, VALUE length);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_assoc(VALUE ary, VALUE key);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_cat(VALUE ary, VALUE* argv, int argc);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_clear(VALUE ary);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_concat(VALUE ary, VALUE value);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_cmp(VALUE ary1, VALUE ary2);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_delete(VALUE ary, VALUE item);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_delete_at(VALUE ary, int index);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_entry(VALUE ary, int index);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_pop(VALUE ary);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_push(VALUE ary, VALUE obj);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_unshift(VALUE ary, VALUE obj);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_plus(VALUE ary1, VALUE ary2);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_shift(VALUE ary);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_each(VALUE ary);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_includes(VALUE ary, VALUE obj);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_sort(VALUE ary);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_sort_bang(VALUE ary);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_rotate(VALUE ary, int n);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_replace(VALUE copy, VALUE orig);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_reverse(VALUE ary);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_rassoc(VALUE ary, VALUE value);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_dup(VALUE ary);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_join(VALUE ary, VALUE separator);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_to_s(VALUE ary);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_ary_freeze(VALUE ary);


        /*
public static extern VALUE rb_Array
public static extern VALUE rb_ary_behead
public static extern VALUE rb_ary_detransient
public static extern VALUE rb_ary_free
public static extern VALUE rb_ary_memsize
public static extern VALUE rb_ary_modify
public static extern VALUE rb_ary_ptr_use_end
public static extern VALUE rb_ary_ptr_use_start
public static extern VALUE rb_ary_resize
public static extern VALUE rb_ary_resurrect
public static extern VALUE rb_ary_shared_with_p
public static extern VALUE rb_ary_tmp_new
public static extern VALUE rb_ary_tmp_new_from_values
public static extern VALUE rb_ary_to_ary
         */
    }
}