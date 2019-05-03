using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace RubyNET
{
    public static partial class API
    {
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_alias(VALUE klass, byte[] newName, byte[] oldName);

        public static void rb_define_alias(VALUE klass, string newName, string oldName) =>
            rb_define_alias(klass, Encode(newName), Encode(oldName));

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rb_define_alloc_func(VALUE klass, RubyAllocFunc func);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_define_module(byte[] name);

        public static VALUE rb_define_module(string name) => rb_define_module(Encode(name));

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_define_module_under(VALUE outer, byte[] name);
        
        public static VALUE rb_define_module_under(VALUE outer, string name) => 
            rb_define_module_under(outer, Encode(name));
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_define_module_id(ID id);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_define_module_id_under(VALUE outer, ID id);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_define_class(byte[] name, VALUE super);

        public static VALUE rb_define_class(string name, VALUE super) =>
            rb_define_class(Encode(name), super);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_define_class_id(ID name, VALUE super);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern VALUE rb_define_class_under(VALUE outer, byte[] name, VALUE super);
        
        public static VALUE rb_define_class_under(VALUE outer, string name, VALUE super) =>
            rb_define_class_under(outer, Encode(name), super);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_define_class__id_under(VALUE outer, ID name, VALUE super);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_const(VALUE klass, byte[] name, VALUE value);

        public static void rb_define_const(VALUE klass, string name, VALUE value) =>
            rb_define_const(klass, Encode(name), value);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_attr(VALUE klass, byte[] name, int read, int write);

        public static void rb_define_attr(VALUE klass, string name, bool read, bool write) =>
            rb_define_attr(klass, Encode(name), read ? 1 : 0, write ? 1 : 0);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_global_const(byte[] name, VALUE value);

        public static void rb_define_global_const(string name, VALUE value) =>
            rb_define_global_const(Encode(name), value);


        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_variable(byte[] name, ref VALUE value);

        public static void rb_define_variable(string name, VALUE value) => rb_define_variable(Encode(name), ref value);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_readonly_variable(byte[] name, ref VALUE value);

        public static void rb_define_readonly_variable(string name, VALUE value) => rb_define_readonly_variable(Encode(name), ref value);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_method(VALUE klass, byte[] name, Delegate method, int argc);

        public static void rb_define_method(VALUE klass, string name, RubyMethodVarArg method) =>
            rb_define_method(klass, Encode(name), method, -1);
        
        public static void rb_define_method(VALUE klass, string name, RubyMethod method) =>
            rb_define_method(klass, Encode(name), method, 0);
        
        public static void rb_define_method(VALUE klass, string name, RubyMethodArg1 method) =>
            rb_define_method(klass, Encode(name), method, 1);

        public static void rb_define_method(VALUE klass, string name, RubyMethodArg2 method) =>
            rb_define_method(klass, Encode(name), method, 2);
        
        public static void rb_define_method(VALUE klass, string name, RubyMethodArg3 method) =>
            rb_define_method(klass, Encode(name), method, 3);
        
        public static void rb_define_method(VALUE klass, string name, RubyMethodArg4 method) =>
            rb_define_method(klass, Encode(name), method, 4);
        
        public static void rb_define_method(VALUE klass, string name, RubyMethodArg5 method) =>
            rb_define_method(klass, Encode(name), method, 5);
        
        public static void rb_define_method(VALUE klass, string name, RubyMethodArg6 method) =>
            rb_define_method(klass, Encode(name), method, 6);
        
        public static void rb_define_method(VALUE klass, string name, RubyMethodArg7 method) =>
            rb_define_method(klass, Encode(name), method, 7);
        
        public static void rb_define_method(VALUE klass, string name, RubyMethodArg8 method) =>
            rb_define_method(klass, Encode(name), method, 8);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_method_id(VALUE klass, ID name, Delegate method, int argc);

        public static void rb_define_method_id(VALUE klass, ID name, RubyMethodVarArg method) =>
            rb_define_method_id(klass, name, method, -1);
        
        public static void rb_define_method_id(VALUE klass, ID name, RubyMethod method) =>
            rb_define_method_id(klass, name, method, 0);
        
        public static void rb_define_method_id(VALUE klass, ID name, RubyMethodArg1 method) =>
            rb_define_method_id(klass, name, method, 1);

        public static void rb_define_method_id(VALUE klass, ID name, RubyMethodArg2 method) =>
            rb_define_method_id(klass, name, method, 2);
        
        public static void rb_define_method_id(VALUE klass, ID name, RubyMethodArg3 method) =>
            rb_define_method_id(klass, name, method, 3);
        
        public static void rb_define_method_id(VALUE klass, ID name, RubyMethodArg4 method) =>
            rb_define_method_id(klass, name, method, 4);
        
        public static void rb_define_method_id(VALUE klass, ID name, RubyMethodArg5 method) =>
            rb_define_method_id(klass, name, method, 5);
        
        public static void rb_define_method_id(VALUE klass, ID name, RubyMethodArg6 method) =>
            rb_define_method_id(klass, name, method, 6);
        
        public static void rb_define_method_id(VALUE klass, ID name, RubyMethodArg7 method) =>
            rb_define_method_id(klass, name, method, 7);
        
        public static void rb_define_method_id(VALUE klass, ID name, RubyMethodArg8 method) =>
            rb_define_method_id(klass, name, method, 8);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_private_method(VALUE klass, byte[] name, Delegate method, int argc);

        public static void rb_define_private_method(VALUE klass, string name, RubyMethodVarArg method) =>
            rb_define_private_method(klass, Encode(name), method, -1);
        
        public static void rb_define_private_method(VALUE klass, string name, RubyMethod method) =>
            rb_define_private_method(klass, Encode(name), method, 0);
        
        public static void rb_define_private_method(VALUE klass, string name, RubyMethodArg1 method) =>
            rb_define_private_method(klass, Encode(name), method, 1);

        public static void rb_define_private_method(VALUE klass, string name, RubyMethodArg2 method) =>
            rb_define_private_method(klass, Encode(name), method, 2);
        
        public static void rb_define_private_method(VALUE klass, string name, RubyMethodArg3 method) =>
            rb_define_private_method(klass, Encode(name), method, 3);
        
        public static void rb_define_private_method(VALUE klass, string name, RubyMethodArg4 method) =>
            rb_define_private_method(klass, Encode(name), method, 4);
        
        public static void rb_define_private_method(VALUE klass, string name, RubyMethodArg5 method) =>
            rb_define_private_method(klass, Encode(name), method, 5);
        
        public static void rb_define_private_method(VALUE klass, string name, RubyMethodArg6 method) =>
            rb_define_private_method(klass, Encode(name), method, 6);
        
        public static void rb_define_private_method(VALUE klass, string name, RubyMethodArg7 method) =>
            rb_define_private_method(klass, Encode(name), method, 7);
        
        public static void rb_define_private_method(VALUE klass, string name, RubyMethodArg8 method) =>
            rb_define_private_method(klass, Encode(name), method, 8);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_protected_method(VALUE klass, byte[] name, Delegate method, int argc);

        public static void rb_define_protected_method(VALUE klass, string name, RubyMethodVarArg method) =>
            rb_define_protected_method(klass, Encode(name), method, -1);
        
        public static void rb_define_protected_method(VALUE klass, string name, RubyMethod method) =>
            rb_define_protected_method(klass, Encode(name), method, 0);
        
        public static void rb_define_protected_method(VALUE klass, string name, RubyMethodArg1 method) =>
            rb_define_protected_method(klass, Encode(name), method, 1);

        public static void rb_define_protected_method(VALUE klass, string name, RubyMethodArg2 method) =>
            rb_define_protected_method(klass, Encode(name), method, 2);
        
        public static void rb_define_protected_method(VALUE klass, string name, RubyMethodArg3 method) =>
            rb_define_protected_method(klass, Encode(name), method, 3);
        
        public static void rb_define_protected_method(VALUE klass, string name, RubyMethodArg4 method) =>
            rb_define_protected_method(klass, Encode(name), method, 4);
        
        public static void rb_define_protected_method(VALUE klass, string name, RubyMethodArg5 method) =>
            rb_define_protected_method(klass, Encode(name), method, 5);
        
        public static void rb_define_protected_method(VALUE klass, string name, RubyMethodArg6 method) =>
            rb_define_protected_method(klass, Encode(name), method, 6);
        
        public static void rb_define_protected_method(VALUE klass, string name, RubyMethodArg7 method) =>
            rb_define_protected_method(klass, Encode(name), method, 7);
        
        public static void rb_define_protected_method(VALUE klass, string name, RubyMethodArg8 method) =>
            rb_define_protected_method(klass, Encode(name), method, 8);
        
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_singleton_method(VALUE klass, byte[] name, Delegate method, int argc);

        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethodVarArg method) =>
            rb_define_singleton_method(klass, Encode(name), method, -1);
        
        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethod method) =>
            rb_define_singleton_method(klass, Encode(name), method, 0);
        
        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethodArg1 method) =>
            rb_define_singleton_method(klass, Encode(name), method, 1);

        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethodArg2 method) =>
            rb_define_singleton_method(klass, Encode(name), method, 2);
        
        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethodArg3 method) =>
            rb_define_singleton_method(klass, Encode(name), method, 3);
        
        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethodArg4 method) =>
            rb_define_singleton_method(klass, Encode(name), method, 4);
        
        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethodArg5 method) =>
            rb_define_singleton_method(klass, Encode(name), method, 5);
        
        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethodArg6 method) =>
            rb_define_singleton_method(klass, Encode(name), method, 6);
        
        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethodArg7 method) =>
            rb_define_singleton_method(klass, Encode(name), method, 7);
        
        public static void rb_define_singleton_method(VALUE klass, string name, RubyMethodArg8 method) =>
            rb_define_singleton_method(klass, Encode(name), method, 8);
        
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_module_function(VALUE klass, byte[] name, Delegate method, int argc);

        public static void rb_define_module_function(VALUE klass, string name, RubyMethodVarArg method) =>
            rb_define_module_function(klass, Encode(name), method, -1);
        
        public static void rb_define_module_function(VALUE klass, string name, RubyMethod method) =>
            rb_define_module_function(klass, Encode(name), method, 0);
        
        public static void rb_define_module_function(VALUE klass, string name, RubyMethodArg1 method) =>
            rb_define_module_function(klass, Encode(name), method, 1);

        public static void rb_define_module_function(VALUE klass, string name, RubyMethodArg2 method) =>
            rb_define_module_function(klass, Encode(name), method, 2);
        
        public static void rb_define_module_function(VALUE klass, string name, RubyMethodArg3 method) =>
            rb_define_module_function(klass, Encode(name), method, 3);
        
        public static void rb_define_module_function(VALUE klass, string name, RubyMethodArg4 method) =>
            rb_define_module_function(klass, Encode(name), method, 4);
        
        public static void rb_define_module_function(VALUE klass, string name, RubyMethodArg5 method) =>
            rb_define_module_function(klass, Encode(name), method, 5);
        
        public static void rb_define_module_function(VALUE klass, string name, RubyMethodArg6 method) =>
            rb_define_module_function(klass, Encode(name), method, 6);
        
        public static void rb_define_module_function(VALUE klass, string name, RubyMethodArg7 method) =>
            rb_define_module_function(klass, Encode(name), method, 7);
        
        public static void rb_define_module_function(VALUE klass, string name, RubyMethodArg8 method) =>
            rb_define_module_function(klass, Encode(name), method, 8);
        
        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_global_function(byte[] name, Delegate method, int argc);

        public static void rb_define_global_function(string name, RubyMethodVarArg method) =>
            rb_define_global_function(Encode(name), method, -1);
        
        public static void rb_define_global_function(string name, RubyMethod method) =>
            rb_define_global_function(Encode(name), method, 0);
        
        public static void rb_define_global_function(string name, RubyMethodArg1 method) =>
            rb_define_global_function(Encode(name), method, 1);

        public static void rb_define_global_function(string name, RubyMethodArg2 method) =>
            rb_define_global_function(Encode(name), method, 2);
        
        public static void rb_define_global_function(string name, RubyMethodArg3 method) =>
            rb_define_global_function(Encode(name), method, 3);
        
        public static void rb_define_global_function(string name, RubyMethodArg4 method) =>
            rb_define_global_function(Encode(name), method, 4);
        
        public static void rb_define_global_function(string name, RubyMethodArg5 method) =>
            rb_define_global_function(Encode(name), method, 5);
        
        public static void rb_define_global_function(string name, RubyMethodArg6 method) =>
            rb_define_global_function(Encode(name), method, 6);
        
        public static void rb_define_global_function(string name, RubyMethodArg7 method) =>
            rb_define_global_function(Encode(name), method, 7);
        
        public static void rb_define_global_function(string name, RubyMethodArg8 method) =>
            rb_define_global_function(Encode(name), method, 8);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern int rb_define_dummy_encoding(byte[] name);

        public static int rb_define_dummy_encoding(string name) => rb_define_dummy_encoding(Encode(name));

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_class_variable(VALUE klass, byte[] name, VALUE value);

        public static void rb_define_class_variable(VALUE klass, string name, VALUE value) =>
            rb_define_class_variable(klass, Encode(name), value);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        public static extern VALUE rb_define_finalizer(VALUE obj, VALUE block);

        [DllImport(LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        private static extern void rb_define_virtual_variable(byte[] name, RubyVariableGetter getter,
            RubyVariableSetter setter);

        public static void rb_define_virtual_variable(string name, RubyVariableGetter getter,
            RubyVariableSetter setter) => rb_define_virtual_variable(Encode(name), getter, setter);
        
    }
}