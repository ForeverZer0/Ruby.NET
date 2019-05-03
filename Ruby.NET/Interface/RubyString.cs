using System;
using RubyNET;
using static RubyNET.API;

namespace RubyNET
{
    public class RubyString : RubyObject, IEquatable<RubyString>
    {
        public RubyString(VALUE value) : base(value)
        {
        }
        
        public RubyString() : base(rb_str_new(IntPtr.Zero, 0))
        {
        }

        public RubyString(string value) : base(rb_str_new(value))
        {
        }

        public RubyString(IntPtr pointer, int length) : base(rb_str_new(pointer, length))
        {
        }

        public int Count => rb_str_strlen(Internal);

        public bool Equals(RubyString other)
        {
            return !(other is null) && rb_str_equal(Internal, other.Internal).IsTrue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((RubyString) obj);
        }

        public override int GetHashCode() => unchecked((int) rb_str_hash(Internal).ToInt64());
        
        public static bool operator ==(RubyString left, RubyString right) => Equals(left, right);
        public static bool operator !=(RubyString left, RubyString right) => !Equals(left, right);
    }
}