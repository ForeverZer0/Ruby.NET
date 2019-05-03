using System;

namespace RubyNET
{
    public struct ID : IEquatable<ID>
    {
        public readonly UIntPtr id;

        public bool Equals(ID other) => id.Equals(other.id);

        public override bool Equals(object obj) => obj is ID other && Equals(other);

        public override int GetHashCode() => id.GetHashCode();

        public static bool operator ==(ID left, ID right) => left.Equals(right);

        public static bool operator !=(ID left, ID right) => !left.Equals(right);
    }
}