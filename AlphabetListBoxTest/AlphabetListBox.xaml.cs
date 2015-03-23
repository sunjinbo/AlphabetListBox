using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System;

namespace AlphabetListBoxTest
{
    public partial class AlphabetListBox : UserControl
    {
        private AlphabetViewModel viewModel;

        public AlphabetListBox()
        {
            InitializeComponent();

            viewModel = new AlphabetViewModel();
            this.DataContext = viewModel;
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //取得 listBoxMain 中的ScrollBar
            List<ScrollBar> scrollBarList = GetVisualChildCollection<ScrollBar>(AlphabetList);

            foreach (ScrollBar scrollBar in scrollBarList)
            {
                //如果是垂直的ScrollBar加入此事件
                if (scrollBar.Orientation == System.Windows.Controls.Orientation.Vertical)
                {
                    scrollBar.ValueChanged += new RoutedPropertyChangedEventHandler<double>(
                        OnScrollBarValueChanged);
                }
                else //此為橫向的
                {

                }
            }
        }

        private void OnScrollBarValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Debug.WriteLine((sender as ScrollBar).GetValue(ScrollBar.ValueProperty).ToString());
            viewModel.UpdateScrollBarValue(Convert.ToDouble((sender as ScrollBar).GetValue(ScrollBar.ValueProperty)));
        }

        private void OnManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
        }

        private void OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {

        }

        private void OnManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

        }

        public static List<T> GetVisualChildCollection<T>(object parent) where T : UIElement
        {
            List<T> visualCollection = new List<T>();
            GetVisualChildCollection(parent as DependencyObject, visualCollection);
            return visualCollection;
        }

        private static void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : UIElement
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    GetVisualChildCollection(child, visualCollection);
                }
            }
        }
    }
}
