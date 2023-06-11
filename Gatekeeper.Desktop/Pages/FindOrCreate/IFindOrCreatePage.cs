using System;

namespace Gatekeeper.Desktop.Pages
{
    internal interface IFindOrCreatePage
    {
        public object SelectedItem { get; set; }
        public object GetSelectedItem();
    }
}