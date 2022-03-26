using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

namespace QuickTourXFSample.Views.QuickTourSteps
{
    public partial class QuickTourStep1PopUp : BaseQuickTourPage, IQuickTourLauncher
    {
        public QuickTourStep1PopUp(): base() => InitializeComponent();

        public Task LaunchAsync() => PopupNavigation.Instance.PushAsync(this, false);
    }
}