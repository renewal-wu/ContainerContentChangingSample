using ContainerContentChangingSample.CustomControls;
using System;
using Windows.UI.Xaml.Controls;


namespace ContainerContentChangingSample
{
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel viewModel { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            viewModel = new MainPageViewModel();
            this.DataContext = viewModel;
        }

        private void OnContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            ContainerContentChangingSampleItem sourceContainer = args.ItemContainer.ContentTemplateRoot as ContainerContentChangingSampleItem;

            if (sourceContainer == null)
            {
                throw new InvalidOperationException("動態載入 GridViewItem，ItemTemplate 必須為 ContainerContentChangingSampleItem 物件。");
            }

            if (args.InRecycleQueue == true)
            {
                sourceContainer.ClearData();
            }
            else if (args.Phase == 0)
            {
                sourceContainer.LoadItem(args.Item as SampleDataItem);
                sourceContainer.ShowTitle();
                args.RegisterUpdateCallback(OnContainerContentChanging);
            }
            else if (args.Phase == 1)
            {
                sourceContainer.ShowContent();
            }

            args.Handled = true;
        }
    }
}
