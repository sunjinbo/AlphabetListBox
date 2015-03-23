using System;
using System.ComponentModel;

namespace AlphabetListBoxTest
{
    /// <summary>
    /// Base class of DataModel, implements INotifyPropertyChanged interface
    /// </summary>
    public class BaseModel : INotifyPropertyChanged
    {
        #region Event
        /// <summary>
        /// Represents the method that will handle the PropertyChanged event
        /// raised when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Internal method
        /// <summary>
        /// Sends a notification of a specified property to an binding view.
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <returns>
        /// None
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// ArgumentNullException exception
        /// <exception cref="System.NullReferenceException">
        /// NullReferenceException exception
        /// </exception>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
