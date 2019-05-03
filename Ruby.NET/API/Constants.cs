using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace RubyNET
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)][SuppressUnmanagedCodeSecurity]
    public unsafe delegate void RubyDataFunc(void* data);

    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static unsafe partial class API
    {
        static API()
        {
            if (UIntPtr.Size == sizeof(double))
            {
                RUBY_Qfalse = 0;
                RUBY_Qtrue = 0x14;
                RUBY_Qnil = 0x08;
                RUBY_Qundef = 0x34;
                RUBY_IMMEDIATE_MASK = 0x07;
                RUBY_FIXNUM_FLAG = 0x01;
                RUBY_FLONUM_MASK = 0x02;
                RUBY_FLONUM_FLAG = 0x02;
                RUBY_SYMBOL_FLAG = 0x0c;
            }
            else
            {
                RUBY_Qfalse = 0;
                RUBY_Qtrue = 2;
                RUBY_Qnil = 4;
                RUBY_Qundef = 6;
                RUBY_IMMEDIATE_MASK = 0x03;
                RUBY_FIXNUM_FLAG = 0x01;
                RUBY_FLONUM_MASK = 0x00;
                RUBY_FLONUM_FLAG = 0x02;
                RUBY_SYMBOL_FLAG = 0x0e;
            }
            RUBY_SPECIAL_SHIFT = 8;
            Qfalse = new VALUE(RUBY_Qfalse);
            Qtrue = new VALUE(RUBY_Qtrue);
            Qnil = new VALUE(RUBY_Qnil);
            Qundef = new VALUE(RUBY_Qundef);

            NULL = (void*) 0;
            RUBY_DEFAULT_FREE = (void*) -1;
        }

        public static readonly void* NULL;
        public static readonly void* RUBY_DEFAULT_FREE;

        public static readonly VALUE Qfalse;
        public static readonly VALUE Qtrue;
        public static readonly VALUE Qnil;
        public static readonly VALUE Qundef;

        public static readonly uint RUBY_Qfalse;
        public static readonly uint RUBY_Qtrue;
        public static readonly uint RUBY_Qnil;
        public static readonly uint RUBY_Qundef;
        public static readonly uint RUBY_IMMEDIATE_MASK;
        public static readonly uint RUBY_FIXNUM_FLAG;
        public static readonly uint RUBY_FLONUM_MASK;
        public static readonly uint RUBY_FLONUM_FLAG;
        public static readonly uint RUBY_SYMBOL_FLAG;
        public static readonly int RUBY_SPECIAL_SHIFT;

        public const int T_NONE = 0x00;
        public const int T_OBJECT = 0x01;
        public const int T_CLASS  = 0x02;
        public const int T_MODULE = 0x03;
        public const int T_FLOAT  = 0x04;
        public const int T_STRING = 0x05;
        public const int T_REGEXP = 0x06;
        public const int T_ARRAY  = 0x07;
        public const int T_HASH   = 0x08;
        public const int T_STRUCT = 0x09;
        public const int T_BIGNUM = 0x0a;
        public const int T_FILE   = 0x0b;
        public const int T_DATA   = 0x0c;
        public const int T_MATCH  = 0x0d;
        public const int T_COMPLEX = 0x0e;
        public const int T_RATIONAL = 0x0f;
        public const int T_NIL = 0x11;
        public const int T_TRUE   = 0x12;
        public const int T_FALSE  = 0x13;
        public const int T_SYMBOL = 0x14;
        public const int T_FIXNUM = 0x15;
        public const int T_UNDEF  = 0x16;
        public const int T_IMEMO  = 0x1a;
        public const int T_NODE   = 0x1b;
        public const int T_ICLASS = 0x1c;
        public const int T_ZOMBIE = 0x1d;
        public const int T_MASK = 0x1f;

        public static string ruby_copyright => GetString("ruby_copyright");
        public static Version ruby_api_version 
        {
            get
            {
                var address = GetAddress("ruby_api_version");
                var major = Marshal.ReadInt32(address);
                var minor = Marshal.ReadInt32(address, sizeof(int));
                var teeny = Marshal.ReadInt32(address, sizeof(int) * 2);
                return new Version(major, minor, teeny);
            }
        }

        public static Version ruby_version => Version.Parse(GetString("ruby_version"));
        
        public static string ruby_engine => GetString("ruby_engine");
        
        public static string ruby_release_date => GetString("ruby_release_date");

        public static int ruby_patch_level => Marshal.ReadInt32(GetAddress("ruby_patchlevel"));
                
        public static string ruby_platform => GetString("ruby_platform");

        public static string ruby_description => GetString("ruby_description");

        public static VALUE rb_stderr => GetValue("rb_stderr");
        public static VALUE rb_stdin => GetValue("rb_stdin");
        public static VALUE rb_stdout => GetValue("rb_stdout");
        
        // Classes
        public static VALUE rb_cArray => GetValue("rb_cArray");
        public static VALUE rb_cBasicObject => GetValue("rb_cBasicObject");
        public static VALUE rb_cBinding => GetValue("rb_cBinding");
        public static VALUE rb_cClass => GetValue("rb_cClass");
        public static VALUE rb_cComplex => GetValue("rb_cComplex");
        public static VALUE rb_cData => GetValue("rb_cData");
        public static VALUE rb_cDir => GetValue("rb_cDir");
        public static VALUE rb_cEncoding => GetValue("rb_cEncoding");
        public static VALUE rb_cEnumerator => GetValue("rb_cEnumerator");
        public static VALUE rb_cFalseClass => GetValue("rb_cFalseClass");
        public static VALUE rb_cFile => GetValue("rb_cFile");
        public static VALUE rb_cFloat => GetValue("rb_cFloat");
        public static VALUE rb_cHash => GetValue("rb_cHash");
        public static VALUE rb_cInteger => GetValue("rb_cInteger");
        public static VALUE rb_cIO => GetValue("rb_cIO");
        public static VALUE rb_cISeq => GetValue("rb_cISeq");
        public static VALUE rb_cMatch => GetValue("rb_cMatch");
        public static VALUE rb_cMethod => GetValue("rb_cMethod");
        public static VALUE rb_cModule => GetValue("rb_cModule");
        public static VALUE rb_cNameErrorMesg => GetValue("rb_cNameErrorMesg");
        public static VALUE rb_cNilClass => GetValue("rb_cNilClass");
        public static VALUE rb_cNumeric => GetValue("rb_cNumeric");
        public static VALUE rb_cObject => GetValue("rb_cObject");
        public static VALUE rb_cProc => GetValue("rb_cProc");
        public static VALUE rb_cRandom => GetValue("rb_cRandom");
        public static VALUE rb_cRange => GetValue("rb_cRange");
        public static VALUE rb_cRational => GetValue("rb_cRational");
        public static VALUE rb_cRegexp => GetValue("rb_cRegexp");
        public static VALUE rb_cRubyVM => GetValue("rb_cRubyVM");
        public static VALUE rb_cStat => GetValue("rb_cStat");
        public static VALUE rb_cString => GetValue("rb_cString");
        public static VALUE rb_cStruct => GetValue("rb_cStruct");
        public static VALUE rb_cSymbol => GetValue("rb_cSymbol");
        public static VALUE rb_cThread => GetValue("rb_cThread");
        public static VALUE rb_cTime => GetValue("rb_cTime");
        public static VALUE rb_cTrueClass => GetValue("rb_cTrueClass");
        public static VALUE rb_cUnboundMethod => GetValue("rb_cUnboundMethod");
        
        // Modules
        public static VALUE rb_mComparable => GetValue("rb_mComparable");
        public static VALUE rb_mEnumerable => GetValue("rb_mEnumerable");
        public static VALUE rb_mErrno => GetValue("rb_mErrno");
        public static VALUE rb_mFileTest => GetValue("rb_mFileTest");
        public static VALUE rb_mGC => GetValue("rb_mGC");
        public static VALUE rb_mKernel => GetValue("rb_mKernel");
        public static VALUE rb_mMath => GetValue("rb_mMath");
        public static VALUE rb_mProcess => GetValue("rb_mProcess");
        public static VALUE rb_mRubyVMFrozenCore => GetValue("rb_mRubyVMFrozenCore");
        public static VALUE rb_mWaitReadable => GetValue("rb_mWaitReadable");
        public static VALUE rb_mWaitWritable => GetValue("rb_mWaitWritable");
        
        // Exceptions
        public static VALUE rb_eArgError => GetValue("rb_eArgError");
        public static VALUE rb_eEncCompatError => GetValue("rb_eEncCompatError");
        public static VALUE rb_eEncodingError => GetValue("rb_eEncodingError");
        public static VALUE rb_eEOFError => GetValue("rb_eEOFError");
        public static VALUE rb_eException => GetValue("rb_eException");
        public static VALUE rb_eFatal => GetValue("rb_eFatal");
        public static VALUE rb_eFloatDomainError => GetValue("rb_eFloatDomainError");
        public static VALUE rb_eFrozenError => GetValue("rb_eFrozenError");
        public static VALUE rb_eIndexError => GetValue("rb_eIndexError");
        public static VALUE rb_eInterrupt => GetValue("rb_eInterrupt");
        public static VALUE rb_eIOError => GetValue("rb_eIOError");
        public static VALUE rb_eKeyError => GetValue("rb_eKeyError");
        public static VALUE rb_eLoadError => GetValue("rb_eLoadError");
        public static VALUE rb_eLocalJumpError => GetValue("rb_eLocalJumpError");
        public static VALUE rb_eMathDomainError => GetValue("rb_eMathDomainError");
        public static VALUE rb_eNameError => GetValue("rb_eNameError");
        public static VALUE rb_eNoMemError => GetValue("rb_eNoMemError");
        public static VALUE rb_eNoMethodError => GetValue("rb_eNoMethodError");
        public static VALUE rb_eNotImpError => GetValue("rb_eNotImpError");
        public static VALUE rb_eRangeError => GetValue("rb_eRangeError");
        public static VALUE rb_eRegexpError => GetValue("rb_eRegexpError");
        public static VALUE rb_eRuntimeError => GetValue("rb_eRuntimeError");
        public static VALUE rb_eScriptError => GetValue("rb_eScriptError");
        public static VALUE rb_eSecurityError => GetValue("rb_eSecurityError");
        public static VALUE rb_eSignal => GetValue("rb_eSignal");
        public static VALUE rb_eStandardError => GetValue("rb_eStandardError");
        public static VALUE rb_eStopIteration => GetValue("rb_eStopIteration");
        public static VALUE rb_eSyntaxError => GetValue("rb_eSyntaxError");
        public static VALUE rb_eSysStackError => GetValue("rb_eSysStackError");
        public static VALUE rb_eSystemCallError => GetValue("rb_eSystemCallError");
        public static VALUE rb_eSystemExit => GetValue("rb_eSystemExit");
        public static VALUE rb_eThreadError => GetValue("rb_eThreadError");
        public static VALUE rb_eTypeError => GetValue("rb_eTypeError");
        public static VALUE rb_eZeroDivError => GetValue("rb_eZeroDivError");

        private static readonly Dictionary<string, VALUE> mapping = new Dictionary<string, VALUE>();
        private static IntPtr module;

        private static void EnsureModule()
        {
            if (!module.Equals(IntPtr.Zero)) 
                return;
            module = NativeLoader.Load(LIBRARY);
            if (module == IntPtr.Zero)
                throw new DllNotFoundException($"Cannot find \"{LIBRARY}\"");
        }
        
        private static VALUE GetValue(string name)
        {
            if (mapping.TryGetValue(name, out var value))
                return value;
            var address = GetAddress(name);
            var v = *(VALUE*) address.ToPointer();
            mapping[name] = v;
            return v;
        }

        private static string GetString(string name)
        {
            var address = GetAddress(name);
            return Util.PtrToStringUTF8(address);
        }
        
        private static IntPtr GetAddress(string name)
        {
            EnsureModule();
            var address = NativeLoader.GetProcAddress(name, module);
            if (address.Equals(IntPtr.Zero))
                throw new InvalidOperationException($"Failed to import \"{name}\"");
            return address;
        }
    }
}