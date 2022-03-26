using System.Collections.ObjectModel;

namespace QuickTourXFSample.Views.QuickTourSteps
{
    public partial class QuickTourStep2PopUp : BaseQuickTourPage
    {
        ObservableCollection<string> _mockTodoList = new ObservableCollection<string>() { "My Item" };

        public QuickTourStep2PopUp() : base()
        {
            InitializeComponent();
            ItemsList.ItemsSource = _mockTodoList;
        }

        void OnAddTapped(System.Object sender, System.EventArgs e)
        {
            _mockTodoList.Add("A new item added succesfully!");
        }
    }
}