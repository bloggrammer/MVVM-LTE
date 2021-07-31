using System.Collections.Generic;
using System.Linq;

namespace MVVM.LTE.ViewModel
{
    /// <summary>
    /// Represents a dictionary (a collection of keys and values.) that allows duplicate keys
    /// </summary>
    /// <typeparam name="TKey">The key of the value</typeparam>
    /// <typeparam name="TValue">The value</typeparam>
    public class PowerCollection<TKey, TValue> : List<KeyValuePair<TKey, TValue>>
    {
        /// <summary>
        ///  Adds the specified key and value to the PowerCollection.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        public void Add(TKey key, TValue value)
        {
            var element = new KeyValuePair<TKey, TValue>(key, value);
            Add(element);
        }
        /// <summary>
        /// Determines whether the collection contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the collection</param>
        /// <returns>true or false</returns>
        public bool ContainsKey(TKey key) => this.Any(x => x.Key.Equals(key));

        public IEnumerable<TValue> this[TKey key]
        {
            get
            {
                if (ContainsKey(key))
                    return this.Where(x => x.Key.Equals(key)).Select(x => x.Value);
                throw new KeyNotFoundException(
                        string.Format(
                            "The given key {0} was not found in the collection.", key));
            }
        }

        public TValue this[TKey key, TKey fKey]
        {
            get
            {
                if (ContainsKey(key))
                    return this.Where(x => x.Key.Equals(key)).Select(x => x.Value).FirstOrDefault();
                throw new KeyNotFoundException(
                        string.Format(
                            "The given key {0} was not found in the collection.", key));
            }
        }
        /// <summary>
        ///  Gets a collection containing the keys.
        /// </summary>
        public IEnumerable<TKey> Keys => this.Select(x => x.Key);
        /// <summary>
        ///  Gets a collection containing the values.
        /// </summary>
        public IEnumerable<TValue> Values => this.Select(x => x.Value);

    }
}
