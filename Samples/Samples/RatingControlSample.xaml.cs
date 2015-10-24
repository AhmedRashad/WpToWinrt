using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WpToWinrt.Common;


namespace Samples
{
    public sealed partial class RatingControlSample : Page
    {
        private readonly NavigationHelper _navigationHelper;
        public RatingControlSample()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            _navigationHelper.OnNavigatedFrom(e);
        }

        private void Button_Click_Increase(object sender, RoutedEventArgs e)
        {
            RatingControl.Value += 0.5;
        }

        private void Button_Click_Decrease(object sender, RoutedEventArgs e)
        {
            RatingControl.Value -= 0.10;
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            RatingControl.Value = 0;
            RatingControl.RatingItemCount = 5;
            RatingControl.Orientation = Orientation.Horizontal;
            RatingControl.Width = 250;
            RatingControl.Height = 50;
        }

        private void Button_Click_Flip(object sender, RoutedEventArgs e)
        {
            if (RatingControl.Orientation == Orientation.Horizontal)
            {
                RatingControl.Orientation = Orientation.Vertical;
                RatingControl.Width = 50;
                RatingControl.Height = 250;
            }
            else
            {
                RatingControl.Orientation = Orientation.Horizontal;
                RatingControl.Width = 250;
                RatingControl.Height = 50;
            }
        }

        private void Button_Click_More(object sender, RoutedEventArgs e)
        {
            RatingControl.RatingItemCount += 1;
        }
    }
}
