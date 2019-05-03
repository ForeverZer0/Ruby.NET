using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RubyNET;
using static RubyNET.API;

namespace RubyNET
{
    public unsafe class RubyArray : RubyObject, IList<VALUE>
    {
        public RubyArray(VALUE value) : base(value)
        {
        }

        public RubyArray() : base(rb_ary_new())
        {
        }

        public RubyArray(int capacity) : base(rb_ary_new(capacity))
        {
        }

        public RubyArray(IEnumerable<VALUE> values) : base(rb_ary_new(values.ToArray()))
        {
        }

        public RubyArray(params VALUE[] values) : base(rb_ary_new(values))
        {
        }

        public IEnumerator<VALUE> GetEnumerator()
        {
            var length = rb_num2int(rb_funcall(Internal, rb_intern("size")));
            for (var i = 0; i < length; i++)
                yield return rb_ary_entry(Internal, i);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(VALUE item) => rb_ary_push(Internal, item);

        public void Clear() => rb_ary_clear(Internal);

        public bool Contains(VALUE item) => rb_ary_includes(Internal, item).IsTrue;

        public void CopyTo(VALUE[] array, int arrayIndex)
        {
            var length = rb_num2int(rb_funcall(Internal, rb_intern("size")));
            for (var i = 0; i < length; i++, arrayIndex++)
                array[arrayIndex] = rb_ary_entry(Internal, i);
        }

        public bool Remove(VALUE item) => !rb_ary_delete(Internal, item).IsNil;

        public int Count => rb_num2int(rb_funcall(Internal, rb_intern("size")));

        public bool IsReadOnly => IsFrozen;
        
        public int IndexOf(VALUE item) => throw new System.NotImplementedException();

        public void Insert(int index, VALUE item) { throw new System.NotImplementedException(); }

        public void RemoveAt(int index) => rb_ary_delete_at(Internal, index);

        public VALUE this[int index]
        {
            get => rb_ary_entry(Internal, index);
            set => rb_ary_store(Internal, index, value);
        }

        public override void Freeze() => rb_ary_freeze(Internal);

        public override string ToString() => rb_string_value_cstr(rb_ary_to_s(Internal));
    }
}