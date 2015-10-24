using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WpToWinrt.Common;


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
