using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace QuickTourXFSample.Views.QuickTourSteps
{
    public abstract partial class BaseQuickTourPage : PopupPage
    {
        public BaseQuickTourPage()
        {
            InitializeComponent();
            NextCommand = new Command<BaseQuickTourPage>(async (page) => await Next(page));
            SkipCommand = new Command(async () => await Skip());
        }

        public static readonly BindableProperty ActualStepProperty = BindableProperty.Create(nameof(ActualStep),   typeof(int), typeof(BaseQuickTourPage));
        public static readonly BindableProperty TotalStepsProperty = BindableProperty.Create(nameof(TotalSteps), typeof(int), typeof(BaseQuickTourPage));
        public static readonly BindableProperty NextCommandProperty = BindableProperty.Create(nameof(NextCommand), typeof(ICommand), typeof(BaseQuickTourPage));
        public static readonly BindableProperty NextPageProperty = BindableProperty.Create(nameof(NextPage), typeof(BaseQuickTourPage), typeof(BaseQuickTourPage));
        public static readonly BindableProperty SkipCommandProperty = BindableProperty.Create(nameof(SkipCommand), typeof(ICommand), typeof(BaseQuickTourPage));

        public int ActualStep
        {
            get => (int) GetValue(ActualStepProperty);
            set => SetValue(ActualStepProperty, value);
        }

        public ICommand NextCommand
        {
            get => (ICommand) GetValue(NextCommandProperty);
            set => SetValue(NextCommandProperty, value);
        }

        public BaseQuickTourPage NextPage
        {
            get => (BaseQuickTourPage)GetValue(NextPageProperty);
            set => SetValue(NextPageProperty, value);
        }

        public ICommand SkipCommand
        {
            get => (ICommand)GetValue(SkipCommandProperty);
            set => SetValue(SkipCommandProperty, value);
        }

        public int TotalSteps
        {
            get => (int)GetValue(TotalStepsProperty);
            set => SetValue(TotalStepsProperty, value);
        }

        private async Task Next(BaseQuickTourPage page)
        {
            if(isNavigating)
            {
                return;
            }

            isNavigating = true;

            await PopupNavigation.Instance.PopAsync();

            if (page != null)
            {
                await PopupNavigation.Instance.PushAsync(page);
            }

            isNavigating = false;
        }

        private async Task Skip() => await PopupNavigation.Instance.PopAsync();

        private bool isNavigating = false;
    }
}
