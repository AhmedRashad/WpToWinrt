using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WpToWinrt.Common;
using WpToWinrt.Controls;


namespace Samples
{
    public sealed partial class MainPage : Page
    {
        private readonly NavigationHelper _navigationHelper;
        private SampleItem[] _samples;

        public MainPage()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
            this.NavigationCacheMode = NavigationCacheMode.Required;
            InitializeData();
            SamplesListView.ItemsSource = _samples;
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

        private void InitializeData()
        {
            _samples = new SampleItem[]
            {
            new SampleItem(typeof(RatingControlSample),"Rating Control","simple control for star-based rating"),
            new SampleItem(typeof(ExpanderViewSample),"Expander View","shows sub-items similar to the new email app"),

            };
        }

        private void SamplesListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var sample = (SampleItem)e.ClickedItem;
            Frame.Navigate(sample.TargetPage);
        }
    }

    public class SampleItem
    {
        public SampleItem(Type targetPage, string header, string description)
        {
            TargetPage = targetPage;
            Header = header;
            Description = description;
        }

        public Type TargetPage { get; private set; }
        public string Header { get; private set; }
        public string Description { get; private set; }
    }
}
