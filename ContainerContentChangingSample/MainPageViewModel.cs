using System;
using System.Collections.Generic;

namespace ContainerContentChangingSample
{
    public class MainPageViewModel
    {
        public List<SampleDataItem> SampleData { get; set; }

        public MainPageViewModel()
        {
            SampleData = new List<SampleDataItem>();
            for (Int32 i = 0; i < 1000; i++)
            {
                String indexString = i.ToString();
                SampleData.Add(new SampleDataItem()
                {
                    Title = "Title " + indexString,
                    Content = "Content " + indexString
                });
            }
        }
    }
}
