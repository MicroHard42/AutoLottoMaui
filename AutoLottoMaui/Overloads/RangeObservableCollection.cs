using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace AutoLottoMaui.Overloads
{
    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool _suppressNotification = false;

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressNotification) {
                base.OnCollectionChanged(e);
                
                    }
        }

        public void AddRange(IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(T));
            CheckReentrancy();

            _suppressNotification = true;

            foreach (T item in list)
            {
                Items.Add(item);
            }
            _suppressNotification = false;

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Items)));
            OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            }
    }
}

