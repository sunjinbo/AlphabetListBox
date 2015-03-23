using System;
using System.Collections.Generic;

namespace AlphabetListBoxTest
{
    public class AlphabetListBoxItem : BaseModel, IComparer<AlphabetListBoxItem>, IComparable
    {
        #region Fields
        private bool isKey;
        private char letter;
        private string displayName;
        #endregion

        #region Property
        public bool IsKey
        {
            get
            {
                return isKey;
            }
            private set
            {
                if (isKey != value)
                {
                    isKey = value;
                    NotifyPropertyChanged("IsKey");
                }
            }
        }

        public char Letter
        {
            get
            {
                return letter;
            }
            private set
            {
                if (letter != value)
                {
                    letter = value;
                    NotifyPropertyChanged("Letter");
                }
            }
        }

        public string DisplayName
        {
            get
            {
                return displayName;
            }
            private set
            {
                if (displayName != value)
                {
                    displayName = value;
                    NotifyPropertyChanged("DisplayName");
                }
            }
        }
        #endregion

        #region Ctor
        public AlphabetListBoxItem(char letter)
        {
            this.letter = letter;
            this.isKey = true;
        }

        public AlphabetListBoxItem(string displayName)
        {
            this.isKey = false;
            this.displayName = displayName;
        }
        #endregion

        #region Internal methods
        public int Compare(AlphabetListBoxItem x, AlphabetListBoxItem y)
        {
            return x.displayName.CompareTo(y.displayName);
        }

        public int CompareTo(object obj)
        {
            return this.displayName.CompareTo((obj as AlphabetListBoxItem).DisplayName);
        }
        #endregion
    }
}
