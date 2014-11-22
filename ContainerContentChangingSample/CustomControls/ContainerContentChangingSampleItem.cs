using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ContainerContentChangingSample.CustomControls
{
    [TemplatePartAttribute(Name = "TitleTextBlock", Type = typeof(TextBlock))]
    [TemplatePartAttribute(Name = "ContentTextBlock", Type = typeof(TextBlock))]
    public class ContainerContentChangingSampleItem : Control
    {
        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(String), typeof(ContainerContentChangingSampleItem), new PropertyMetadata(""));

        public String Content
        {
            get { return (String)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(String), typeof(ContainerContentChangingSampleItem), new PropertyMetadata(""));


        public ContainerContentChangingSampleItem()
        {
            DefaultStyleKey = typeof(ContainerContentChangingSampleItem);
        }

        private TextBlock titleTextBlock { get; set; }
        private TextBlock contentTextBlock { get; set; }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            titleTextBlock = base.GetTemplateChild("TitleTextBlock") as TextBlock;
            contentTextBlock = base.GetTemplateChild("ContentTextBlock") as TextBlock;
        }

        public void LoadItem(SampleDataItem sampleItem)
        {
            if (sampleItem != null)
            {
                this.Title = sampleItem.Title;
                this.Content = sampleItem.Content;
            }
        }

        public void ShowTitle()
        {
            if (titleTextBlock != null && !String.IsNullOrEmpty(this.Title))
            {
                titleTextBlock.Text = this.Title;
                titleTextBlock.Opacity = 1.0;
            }
        }

        public void ShowContent()
        {
            if (contentTextBlock != null && !String.IsNullOrEmpty(this.Content))
            {
                contentTextBlock.Text = this.Content;
                contentTextBlock.Opacity = 1.0;
            }
        }

        public void ClearData()
        {
            if (contentTextBlock != null)
            {
                contentTextBlock.Opacity = 0;
            }
            if (titleTextBlock != null)
            {
                titleTextBlock.Opacity = 0;
            }
        }
    }
}
