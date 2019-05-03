using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RubyNET
{
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class API
    {
        public const string LIBRARY = "ruby";

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ruby_init();

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ruby_finalize();

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ruby_setup();

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ruby_script(byte[] name);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void* ruby_options(int argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] args);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool ruby_executable_node(void* node, out int state);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)] 
        public static extern unsafe int ruby_exec_node(void* node);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)] 
        public static extern int ruby_cleanup(int state);
        
        public static void ruby_script(string name) => ruby_script(Encode(name));

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void* ruby_xmalloc(int size);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void ruby_xfree(void* data);
        
        [DllImport(LIBRARY, EntryPoint = "ruby_xmalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void* xmalloc(int size);
        
        [DllImport(LIBRARY, EntryPoint = "ruby_xfree", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void xfree(void* data);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rb_p(VALUE value);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool rb_block_given_p();

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern ID rb_intern(byte[] value);

        public static ID rb_intern(string value) => rb_intern(Encode(value));
        
        [DllImport(LIBRARY, EntryPoint = "rb_id2name", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _rb_id2name(ID id);

        public static string rb_id2name(ID id) => Util.PtrToStringUTF8(_rb_id2name(id));

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_id2str(ID id);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_id2sym(ID id);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern double rb_num2dbl(VALUE value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_num2fix(VALUE value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rb_num2int(VALUE value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern long rb_num2ll(VALUE value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rb_num2long(VALUE value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern short rb_num2short(VALUE value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rb_num2uint(VALUE value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong rb_num2ull(VALUE value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong rb_num2ulong(VALUE value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort rb_num2ushort(VALUE value);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_funcall(VALUE recv, ID name, int argc, VALUE[] args);

        public static VALUE rb_funcall(VALUE recv, ID name, params VALUE[] args) =>
            rb_funcall(recv, name, args.Length, args);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_eval_string(byte[] str);

        public static VALUE rb_eval_string(string str) => rb_eval_string(Encode(str));

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_eval_string_protect(byte[] str, out int state);

        public static VALUE rb_eval_string_protect(string str, out int state) => 
            rb_eval_string_protect(Encode(str), out state);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ruby_show_copyright();

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ruby_show_version();

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe VALUE rb_data_object_wrap(VALUE klass, void* sval, RubyDataFunc dmark, RubyDataFunc dfree);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe VALUE rb_data_object_wrap(VALUE klass, void* sval, void* dmark, void* dfree);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_warn(byte[] str, VALUE[] args);

        public static void rb_warn(string str, params VALUE[] args) =>
            rb_warn(Encode(str), new VALUE[0]);
    }
}