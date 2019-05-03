using System;
using System.Diagnostics.CodeAnalysis;

namespace RubyNET
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public unsafe struct VALUE : IEquatable<VALUE>
    {
        private readonly UIntPtr value;

        public VALUE(UIntPtr value) => this.value = value;

        public VALUE(uint value) => this.value = new UIntPtr(value);

        public VALUE(ulong value) => this.value = new UIntPtr(value);

        public VALUE(void* value) => this.value = new UIntPtr(value);

        public bool IsTrue => Equals(API.Qtrue);

        public bool IsFalse => Equals(API.Qfalse);

        public bool IsNil => Equals(API.Qnil);

        public bool Equals(VALUE other) => value.Equals(other.value);

        public override bool Equals(object obj) => obj is VALUE other && Equals(other);

        public override int GetHashCode() => value.GetHashCode();

        public static bool operator ==(VALUE left, VALUE right) => left.Equals(right);
        public static bool operator !=(VALUE left, VALUE right) => !left.Equals(right);

        public static implicit operator UIntPtr(VALUE value) => value.value;

        public static explicit operator uint(VALUE value) => unchecked(value.value.ToUInt32());

        public static explicit operator ulong(VALUE value) => value.value.ToUInt64();

        public static explicit operator bool(VALUE value) => API.RTEST(value);

        public void* ToPointer() => value.ToPointer();
    }
}