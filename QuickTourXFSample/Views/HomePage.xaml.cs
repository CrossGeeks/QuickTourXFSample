using System.Windows.Input;
using QuickTourXFSample.Views.QuickTourSteps;
using Xamarin.Forms;

namespace QuickTourXFSample.Views
{
    public partial class HomePage : FlyoutPage
    {
        public ICommand ShowQuickTourCommand { get; }

        public HomePage()
        {
            InitializeComponent();

            var quickTourLauncher = QuickTourBuilder<QuickTourStep1PopUp>
                                      .Initialize()
                                      .Next(new QuickTourStep2PopUp())
                                      .Next(new QuickTourStep3PopUp())
                                      .Build();

            ShowQuickTourCommand = new Command(async () => await quickTourLauncher.LaunchAsync());

            BindingContext = this;
        }


    }
}
