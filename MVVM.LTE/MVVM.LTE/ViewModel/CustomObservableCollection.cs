using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MVVM.LTE.ViewModel
{
    public class CustomObservableCollection<T> : ObservableCollection<T>
    {
        public CustomObservableCollection(IEnumerable<T> collection):base(collection) {  }
        public CustomObservableCollection(List<T> list) :base(list) {  }
        public CustomObservableCollection() :base() {  }
        public void Refresh(T item)
        {
            var index = IndexOf(item);

            RemoveAt(index);
            Insert(index, item);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, IndexOf(item)));
        }

        public void Refresh() => OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
}
