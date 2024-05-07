using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Games_Store.Control
{
    public class ScrollingView : ScrollViewer
    {



        public double MyOffset
        {
            get { return (double)GetValue(ScrollViewer.HorizontalOffsetProperty); }
            set { this.ScrollToHorizontalOffset(value); }
        }

        // Using a DependencyProperty as the backing store for Offset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyOffsetProperty =
            DependencyProperty.Register("MyOffset", typeof(double), typeof(ScrollingView), new PropertyMetadata(new PropertyChangedCallback(OnChange)));

        private static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ScrollingView)d).MyOffset = (double)e.NewValue;
        }
    }
}
