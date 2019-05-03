using System.Runtime.InteropServices;
using System.Security;

namespace RubyNET
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public unsafe delegate void RubyDataFunc(void* data);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyAllocFunc(VALUE klass);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public unsafe delegate VALUE RubyMethodVarArg(int arc, VALUE* argv, VALUE recv);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyMethod(VALUE recv);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyMethodArg1(VALUE recv, VALUE arg1);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyMethodArg2(VALUE recv, VALUE arg1, VALUE arg2);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyMethodArg3(VALUE recv, VALUE arg1, VALUE arg2, VALUE arg3);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyMethodArg4(VALUE recv, VALUE arg1, VALUE arg2, VALUE arg3, VALUE arg4);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyMethodArg5(VALUE recv, VALUE arg1, VALUE arg2, VALUE arg3, VALUE arg4, VALUE arg5);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyMethodArg6(VALUE recv, VALUE arg1, VALUE arg2, VALUE arg3, VALUE arg4, VALUE arg5, VALUE arg6);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyMethodArg7(VALUE recv, VALUE arg1, VALUE arg2, VALUE arg3, VALUE arg4, VALUE arg5, VALUE arg6, VALUE arg7);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyMethodArg8(VALUE recv, VALUE arg1, VALUE arg2, VALUE arg3, VALUE arg4, VALUE arg5, VALUE arg6, VALUE arg7, VALUE arg8);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate VALUE RubyVariableGetter(ID variable);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public delegate void RubyVariableSetter(VALUE value, ID variable);
}