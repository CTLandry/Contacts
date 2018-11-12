using Xamarin.Forms;
using System.Windows.Input;

namespace ContactsDemo.Controls
{
    class ClickableListView : ListView
    {
        //Make the listview bindable to a click event in the MVVM pattern

        public ClickableListView()
        {
            this.ItemTapped += OnItemTapped;
        }

        public static BindableProperty ItemClickCommandProperty = BindableProperty.Create(nameof(ItemClickCommand), typeof(ICommand), typeof(ClickableListView), null);

        public ICommand ItemClickCommand
        {
            get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
            set { this.SetValue(ItemClickCommandProperty, value); }
        }


        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
            {
                this.ItemClickCommand.Execute(e.Item);
                this.SelectedItem = null;
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}
