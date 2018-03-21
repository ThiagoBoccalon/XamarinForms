using System.Collections.Generic;
namespace XamarinContacts.Helpers
{
    public class Grouping<K, T> : ObservableCollection
    {
        public K Key { get; set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
