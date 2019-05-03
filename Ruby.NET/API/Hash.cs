using System.Runtime.InteropServices;
using System.Security;

namespace RubyNET
{
    [SuppressUnmanagedCodeSecurity]
    public static unsafe partial class API
    {
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_new();

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_freeze(VALUE hash);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_clear(VALUE hash);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_delete(VALUE hash, VALUE key);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_dup(VALUE hash);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_aref(VALUE hash, VALUE key);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_aset(VALUE hash, VALUE key, VALUE value);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_has_key(VALUE hash, VALUE key);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_keys(VALUE hash);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_values(VALUE hash);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_size(VALUE hash);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_hash_set_ifnone(VALUE hash, VALUE defaultValue);

        /*
public static extern VALUE rb_hash
public static extern VALUE rb_hash_ar_table_p
public static extern VALUE rb_hash_bulk_insert
public static extern VALUE rb_hash_bulk_insert_into_st_table
public static extern VALUE rb_hash_compare_by_id_p
public static extern VALUE rb_hash_delete_entry
public static extern VALUE rb_hash_delete_if
public static extern VALUE rb_hash_fetch
public static extern VALUE rb_hash_foreach
public static extern VALUE rb_hash_lookup
public static extern VALUE rb_hash_lookup2
public static extern VALUE rb_hash_resurrect
public static extern VALUE rb_hash_size_num
public static extern VALUE rb_hash_start
public static extern VALUE rb_hash_stlike_lookup
public static extern VALUE rb_hash_st_table
public static extern VALUE rb_hash_tbl
public static extern VALUE rb_hash_tbl_raw
public static extern VALUE rb_hash_update_by
         */
    }
}