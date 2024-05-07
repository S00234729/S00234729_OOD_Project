using Games_Store.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Games_Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
                WindowState = WindowState.Normal;
        }

        private void MinimiseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }



        public bool IsMenuExpanded
        {
            get { return (bool)GetValue(IsMenuExpandedProperty); }
            set { SetValue(IsMenuExpandedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMenuExpanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMenuExpandedProperty =
            DependencyProperty.Register("IsMenuExpanded", typeof(bool), typeof(MainWindow), new PropertyMetadata(true));

        private void btn_NavLeft_Click(object sender, RoutedEventArgs e)
        {
            btn_NavLeft.IsEnabled = false;
            btn_NavRight.Visibility = Visibility.Visible;

            double offset = (double)scrollViewer.GetValue(ScrollingView.MyOffsetProperty);
            DoubleAnimation leftmove = new DoubleAnimation(offset, offset - 246 - 20, new Duration(TimeSpan.FromSeconds(.5))) { AccelerationRatio = .2, DecelerationRatio = .8 };

            leftmove.Completed += Left_Complete;
            scrollViewer.BeginAnimation(ScrollingView.MyOffsetProperty, leftmove);

        }

        private void btn_NavRight_Click(object sender, RoutedEventArgs e)
        {
            btn_NavRight.IsEnabled = false;
            IsMenuExpanded = false;
            btn_NavLeft.Visibility = Visibility.Visible;

            double offset = (double)scrollViewer.GetValue(ScrollingView.MyOffsetProperty);
            DoubleAnimation rightmove = new DoubleAnimation(offset, offset + 246 + 20, new Duration(TimeSpan.FromSeconds(.5))) { AccelerationRatio = .2, DecelerationRatio = .8 };

            rightmove.Completed += Right_Complete;
            scrollViewer.BeginAnimation(ScrollingView.MyOffsetProperty, rightmove);

        }

        private void Right_Complete(object sender, EventArgs e) 
        {
            btn_NavRight.IsEnabled = true;
            if (Convert.ToInt32(scrollViewer.HorizontalOffset) == Convert.ToInt32(scrollViewer.ScrollableWidth)) 
            {
                btn_NavRight.Visibility = Visibility.Collapsed;
            }
        }

        private void Left_Complete(object sender, EventArgs e)
        {
            btn_NavLeft.IsEnabled = true;
            if (Convert.ToInt32(scrollViewer.HorizontalOffset) == 0)
            {
                btn_NavLeft.Visibility = Visibility.Collapsed;
            }
        }



       

    }
}
