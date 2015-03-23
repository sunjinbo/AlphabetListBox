using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AlphabetListBoxTest
{
    public class AlphabetViewModel : BaseModel
    {
        #region Fields
        private bool isShowHeader = false;
        private char headerKey;
        private double headerOffset = 0.0;
        #endregion

        #region Property
        public ObservableCollection<AlphabetListBoxItem> Items { get; set; }

        public bool IsShowHeader
        {
            get
            {
                return isShowHeader;
            }
            private set
            {
                if (isShowHeader != value)
                {
                    isShowHeader = value;
                    NotifyPropertyChanged("IsShowHeader");
                }
            }
        }

        public char HeaderKey
        {
            get
            {
                return headerKey;
            }
            private set
            {
                if (headerKey != value)
                {
                    headerKey = value;
                    NotifyPropertyChanged("HeaderKey");
                }
            }
        }

        public double HeaderOffset
        {
            get
            {
                return headerOffset;
            }
            private set
            {
                if (headerOffset != value)
                {
                    headerOffset = value;
                    NotifyPropertyChanged("HeaderOffset");
                }
            }
        }
        #endregion

        #region Methods
        public void UpdateScrollBarValue(double newValue)
        {
            if (DoubleUtil.IsZero(newValue) || DoubleUtil.AreEqual(newValue, 52.0))
            {
                IsShowHeader = false;
                return;
            }

            IsShowHeader = true;
            AlphabetListBoxItem item = Items[(int)Math.Floor(newValue) + 1];
            if (item.IsKey)
            {
                double offset = (newValue - Math.Floor(newValue)) * 100;
                HeaderOffset = -offset;

                if (offset >= 800)
                {
                    HeaderKey = item.Letter;
                }
                Debug.WriteLine("Move -> " + HeaderOffset);
            }
            else
            {
                HeaderOffset = 0.0;
                Debug.WriteLine("Move -> 0.0");
                HeaderKey = char.ToLower(item.DisplayName[0]);
            }
        }
        #endregion

        #region Ctor
        public AlphabetViewModel()
        {
            Items = new ObservableCollection<AlphabetListBoxItem>();

            List<AlphabetListBoxItem> list = TestBuilder.GetTestData();
            list.ForEach(x => Items.Add(x));
        }
        #endregion
    }
}
