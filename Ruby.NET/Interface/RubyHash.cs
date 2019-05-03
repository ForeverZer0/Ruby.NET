using System.Collections;
using System.Collections.Generic;
using RubyNET;
using static RubyNET.API;

namespace RubyNET
{
    public class RubyHash : RubyObject, IDictionary<VALUE, VALUE>
    {
        public RubyHash(VALUE value) : base(value)
        {
        }

        public RubyHash() : base(rb_hash_new())
        {
        }

        public void SetDefaultValue(VALUE defaultValue) => rb_hash_set_ifnone(Internal, defaultValue);

        public IEnumerator<KeyValuePair<VALUE, VALUE>> GetEnumerator()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var keys = new RubyArray(rb_hash_keys(Internal));
            foreach (var key in keys)
                yield return new KeyValuePair<VALUE, VALUE>(key, rb_hash_aref(Internal, key));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(KeyValuePair<VALUE, VALUE> item) => rb_hash_aset(Internal, item.Key, item.Value);

        public void Clear() => rb_hash_clear(Internal);

        public bool Contains(KeyValuePair<VALUE, VALUE> item)
        {
            if (rb_hash_has_key(Internal, item.Key).IsFalse)
                return false;
            var value = rb_hash_aref(Internal, item.Key);
            return rb_obj_equal(value, item.Value).IsTrue;
        }

        public void CopyTo(KeyValuePair<VALUE, VALUE>[] array, int arrayIndex)
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var keys = new RubyArray(rb_hash_keys(Internal));
            foreach (var key in keys)
            {
                array[arrayIndex] = new KeyValuePair<VALUE, VALUE>(key, rb_hash_aref(Internal, key));
                arrayIndex++;
            }
        }

        public bool Remove(KeyValuePair<VALUE, VALUE> item)
        {
            if (rb_hash_has_key(Internal, item.Key).IsFalse)
                return false;
            var value = rb_hash_aref(Internal, item.Key);
            if (rb_obj_equal(value, item.Value).IsFalse)
                return false;
            rb_hash_delete(Internal, item.Key);
            return true;
        }

        public int Count => rb_num2int(rb_hash_size(Internal));
        
        public bool IsReadOnly => IsFrozen;

        public void Add(VALUE key, VALUE value) => rb_hash_aset(Internal, key, value);

        public bool ContainsKey(VALUE key) => rb_hash_has_key(Internal, key).IsTrue;

        public bool Remove(VALUE key)
        {
            if (rb_hash_has_key(Internal, key).IsFalse)
                return false;
            rb_hash_delete(Internal, key);
            return true;
        }

        public bool TryGetValue(VALUE key, out VALUE value)
        {
            if (rb_hash_has_key(Internal, key).IsFalse)
            {
                value = Qnil;
                return false;
            }

            value = rb_hash_aref(Internal, key);
            return true;
        }

        public VALUE this[VALUE key]
        {
            get => rb_hash_aref(Internal, key);
            set => rb_hash_aset(Internal, key, value);
        }

        public ICollection<VALUE> Keys => new RubyArray(rb_hash_keys(Internal));

        public ICollection<VALUE> Values
        {
            get
            {
                // ReSharper disable once CollectionNeverUpdated.Local
                var keys = new RubyArray(rb_hash_keys(Internal));
                var values = new RubyArray();
                foreach (var key in keys)
                    values.Add(rb_hash_aref(Internal, key));
                return values;
            }
        }
    }
}