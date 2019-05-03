using System;
using RubyNET;
using static RubyNET.API;

namespace RubyNET
{
    public class RubyObject : IEquatable<RubyObject>
    {
        protected readonly VALUE Internal;

        public RubyObject(VALUE value) { Internal = value; }
        
        public virtual void Freeze() => rb_obj_freeze(Internal);

        public bool IsFrozen => rb_obj_frozen_p(Internal).IsTrue;
        
        public static implicit operator VALUE(RubyObject obj) => obj.Internal;
        
        public bool Equals(RubyObject other) => !(other is null) && rb_obj_equal(Internal, other.Internal).IsTrue;

        public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj is RubyObject other && Equals(other);

        public override int GetHashCode() => Internal.GetHashCode();
        
        public static bool operator ==(RubyObject left, RubyObject right) => Equals(left, right);
        
        public static bool operator !=(RubyObject left, RubyObject right) => !Equals(left, right);
    }
}