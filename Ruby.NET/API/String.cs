using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RubyNET
{
    public static unsafe partial class API
    {

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rb_string_value_cstr(VALUE *str);

        public static string rb_string_value_cstr(VALUE str)
        {
            var ptr = rb_string_value_cstr(&str);
            return Util.PtrToStringUTF8(ptr);
        }

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_str_new_cstr(byte[] str);

        public static VALUE rb_str_new(string str) => rb_str_new_cstr(Encoding.UTF8.GetBytes(str));

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_str_new(IntPtr ptr, int length);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_str_new_frozen(VALUE original);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rb_str_strlen(VALUE str);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_str_equal(VALUE str1, VALUE str2);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rb_str_hash(VALUE str);
    }
    
    /*

public static extern VALUE rb_str_new_shared
public static extern VALUE rb_str_new_static

public static extern VALUE rb_str2big_gmp
public static extern VALUE rb_str2big_karatsuba
public static extern VALUE rb_str2big_normal
public static extern VALUE rb_str2big_poweroftwo
public static extern VALUE rb_str2inum
public static extern VALUE rb_str_append
public static extern VALUE rb_str_buf_append
public static extern VALUE rb_str_buf_cat
public static extern VALUE rb_str_buf_cat2
public static extern VALUE rb_str_buf_cat_ascii
public static extern VALUE rb_str_buf_new
public static extern VALUE rb_str_buf_new_cstr
public static extern VALUE rb_str_capacity
public static extern VALUE rb_str_cat
public static extern VALUE rb_str_cat2
public static extern VALUE rb_str_cat_cstr
public static extern VALUE rb_str_catf
public static extern VALUE rb_str_cmp
public static extern VALUE rb_str_coderange_scan_restartable
public static extern VALUE rb_str_comparable
public static extern VALUE rb_str_concat
public static extern VALUE rb_str_concat_literals
public static extern VALUE rb_str_conv_enc
public static extern VALUE rb_str_conv_enc_opts
public static extern VALUE rb_str_drop_bytes
public static extern VALUE rb_str_dump
public static extern VALUE rb_str_dup
public static extern VALUE rb_str_dup_frozen
public static extern VALUE rb_str_ellipsize
public static extern VALUE rb_str_encode
public static extern VALUE rb_str_encode_ospath
public static extern VALUE rb_str_eql
public static extern VALUE rb_str_export
public static extern VALUE rb_str_export_locale
public static extern VALUE rb_str_export_to_enc
public static extern VALUE rb_str_format
public static extern VALUE rb_str_free
public static extern VALUE rb_str_freeze
public static extern VALUE rb_str_hash_cmp
public static extern VALUE rb_String
public static extern VALUE rb_str_inspect
public static extern VALUE rb_str_intern
public static extern VALUE rb_str_length
public static extern VALUE rb_str_locktmp
public static extern VALUE rb_str_locktmp_ensure
public static extern VALUE rb_str_memsize
public static extern VALUE rb_str_modify
public static extern VALUE rb_str_modify_expand
public static extern VALUE rb_str_new_with_class
public static extern VALUE rb_str_offset
public static extern VALUE rb_str_plus
public static extern VALUE rb_str_replace
public static extern VALUE rb_str_resize
public static extern VALUE rb_str_resurrect
public static extern VALUE rb_str_scrub
public static extern VALUE rb_str_set_len
public static extern VALUE rb_str_setter
public static extern VALUE rb_str_shared_replace
public static extern VALUE rb_str_split
public static extern VALUE rb_str_sublen
public static extern VALUE rb_str_subpos
public static extern VALUE rb_str_subseq
public static extern VALUE rb_str_substr
public static extern VALUE rb_str_succ
public static extern VALUE rb_str_times
public static extern VALUE rb_str_tmp_new
public static extern VALUE rb_str_to_dbl
public static extern VALUE rb_str_to_inum
public static extern VALUE rb_str_to_str
     */
}